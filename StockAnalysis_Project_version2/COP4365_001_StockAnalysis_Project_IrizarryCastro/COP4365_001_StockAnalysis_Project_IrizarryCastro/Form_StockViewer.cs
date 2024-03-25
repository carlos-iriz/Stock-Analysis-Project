using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace COP4365_001_StockAnalysis_Project_IrizarryCastro // Defines namespace
{
    public partial class Form_StockViewer : Form // Defines Form_StockViewer class
    {
        // The following variables are initialized here in order to hold values of multiple functions
        private List<Candlestick> candlesticks = null; // Declares a list of candlesticks that will be populated by smart candlesticks
        private BindingList<Candlestick> boundCandlesticks = null; // Declares a binding list made up of candlesticks

        // Default constructor for form
        public Form_StockViewer()
        {
            InitializeComponent();
            candlesticks = new List<Candlestick>(1024); // Creates list of candlesticks
            boundCandlesticks = new BindingList<Candlestick>(); // Creates list of  bound candlesticks
        }

        /// <summary>
        /// Constructor for the form specifically in the situation where a child form is created        
        /// </summary>
        /// <param name="pathName">String that contains path for input csv file</param>
        /// <param name="startDate">Value for what date user wants to start displaying their csv data</param>
        /// <param name="endDate">Value for what date user wants to end displaying their csv data</param>
        public Form_StockViewer(string pathName, DateTime startDate, DateTime endDate)
        {
            InitializeComponent();
            candlesticks = new List<Candlestick>(1024); //Creates list of candlesticks
            boundCandlesticks = new BindingList<Candlestick>(); //Creates Binding List of candlesticks 

            dateTimePicker_start.Value = startDate; //Start date pulled from parent form
            dateTimePicker_end.Value = endDate; //End date pulled from parent form
            candlesticks = GoReadFile(pathName); //Reads in file and returns list of candlesticks
            FilterByDateRange(); //Filters list of candlesticks by the date range
            DisplayData(); //Display data
        }

        /// <summary>
        /// Event handler for Pick a Stock button on form (button_loader1)
        /// </summary>
        private void button_loader_Click(object sender, EventArgs e) // Event handler for Pick a Stock click (button_loader1)
        {
            openFileDialog_stockticker.ShowDialog(); // Allows button to open file dialog when pressed
        }

        /// <summary>
        /// Event handler for file selection in the OpenFileDialog.
        /// Upon Reading a "Good File" the function will call the following function to read and display the form:
        /// GoReadFile(); Reads data from a given file
        /// FilterByDateRange(); Filters given data by the date range given
        /// DisplayData(); Displays data on 
        /// The function will look through the files in the path and create forms for each file selected
        /// </summary>
        /// 
        private void openFileDialog_stockticker_FileOk(object sender, CancelEventArgs e)
        {
            DateTime startDate = dateTimePicker_start.Value; // Sets start date to dateTimePicker_start.value
            DateTime endDate = dateTimePicker_end.Value; // Sets end date to dateTimePicker_end.Value

            int numberOfFiles = openFileDialog_stockticker.FileNames.Count(); //Saves number of files in OpenFileDialog
            for (int i = 0; i < numberOfFiles; ++i) //Loops through each file found in the input
            {
                string pathName = openFileDialog_stockticker.FileNames[i]; //path is set for a specific file
                string ticker = Path.GetFileNameWithoutExtension(pathName); //Name of file is saved

                Form_StockViewer form_StockViewer; //Creates Form_StockViewer object 
                form_StockViewer = this;

                if (i == 0) //Code for Parent form (Will the first in the list of files)
                {
                    // Calls functions that will read and display the data form the file
                    form_StockViewer = this;
                    GoReadFile();
                    FilterByDateRange();
                    DisplayData();
                    form_StockViewer.Text = "Parent: " + ticker; //Sets name of the form to the ticker
                    //Displays the created form
                    form_StockViewer.Show();
                    form_StockViewer.BringToFront();
                }

                else
                {
                    //Calls form constructor that will read and display the data of the selected file and put that in its own form
                    form_StockViewer = new Form_StockViewer(pathName, startDate, endDate);
                    form_StockViewer.Text = "Child: " + ticker; //Sets name of created form to the ticker
                    //Displays the created form
                    form_StockViewer.Show();
                    form_StockViewer.SendToBack();
                }
            }
        }

        /// <summary>
        /// Method to normalize the chart based on a range of 2% above or below the max and min values
        /// </summary>
        /// <param name="candlesticks">list of candlesticks</param>
        private void Normalize(List<Candlestick> candlesticks) // Method to normalize chart
        {
            double maxHigh = (double)candlesticks.Max(cs => cs.high); // Sets max
            double minLow = (double)candlesticks.Min(cs => cs.low); // Sets min

            //Normalize should have 2% of the max and min value displayed on chart ( 102% for max, 98% for min)
            maxHigh = Math.Ceiling(maxHigh * 1.02); // Ceiling maximum high
            minLow = Math.Floor(minLow * .98); // Floor minimum low

            // Set the maximum and minimum values of the Y axis
            chart_OHLCV.ChartAreas["ChartArea_OHLC"].AxisY.Maximum = maxHigh; // Setting max to Y axis
            chart_OHLCV.ChartAreas["ChartArea_OHLC"].AxisY.Minimum = minLow; // Setting min to Y axis
        }

        /// <summary>
        /// Overloaded method to call Normalize using previously defined "candlesticks"
        /// </summary>
        private void Normalize() // Overloaded method of normalize
        {
            Normalize(candlesticks); // Calling Normalize method using previously defined candlesticks
        }

        /// <summary>
        /// Method reads in data from a given CSV file
        /// </summary>
        /// <param name="filename">User selected CSV file</param>
        /// <returns>List of candlesticks.</returns>
        private List<Candlestick> GoReadFile(string filename) // Method take in data from a given file
        {
            const string referenceString = "\"Date\",\"Open\",\"High\",\"Low\",\"Close\",\"Volume\""; // Defines "referenceString" to establish "columns" from data
            List<Candlestick> resultingList = new List<Candlestick>(1024); // Initializes resulting list where we store the data given from the file
            
            using (StreamReader sr = new StreamReader(filename)) // StreamReader reads data from file
            {
                candlesticks.Clear(); // Clears candlestick list to ensure we are creating a completely new data set
                string line = sr.ReadLine(); // Reads first line from file

                if (true || line == referenceString) // Checks if header corresponds to the referenceString
                {
                    Console.WriteLine("Header row: " + line); // Writes header row to console
                    while ((line = sr.ReadLine()) != null) // Loop until end of file
                    {
                        SmartCandlestick scs = new SmartCandlestick(line); // Creates a new smartcandlestick object for each line
                        CalcProperties(scs); //Calculates additonal properties of smartcandlestick
                        resultingList.Add(scs); // Adds created SmartCandlestick to candlesticks list
                    }
                }

                else
                {
                    Text = "Bad File" + filename; // Prints bad file to user in case of bad file
                }
            }
            return resultingList;  // Returning the list of candlesticks taken from reading in the file 
        }

        /// <summary>
        /// Overloaded method to call GoReadFile using a given file from openFileDialog_stockticker
        /// </summary>
        private void GoReadFile() // Reads data from a given file from openFileDialog_stockticker
        {
            candlesticks = GoReadFile(openFileDialog_stockticker.FileName); // GoReadFile is called and candlesticks is set equal to return value
        }

        /// <summary>
        /// Method filters a given list of candlesticks by start and end date
        /// </summary>
        /// <param name="unfilteredList">List of unfiltered candlesticks</param>
        /// <param name="startDate">User selected start date of the range</param>
        /// <param name="endDate">User selected end date of the range</param>
        /// <returns>Filtered list of candlesticks</returns>
        private List<Candlestick> FilterByDateRange(List<Candlestick> unfilteredList, DateTime startDate, DateTime endDate) // Method to filter list of candlesticks by given date range
        {
            List<Candlestick> filteredList = unfilteredList.Where(cs => cs.date >= startDate && cs.date <= endDate).ToList(); // Filters candlesticks based on date range given

            return filteredList; // Returns the filtered list
        }

        /// <summary>
        /// Overloaded method to filter candlesticks based on DateTimePicker user input
        /// </summary>
        private void FilterByDateRange() // Overloaded method to filter candlesticks using dateTimePicker.value (start and end)
        {
            // Get the start and end dates from the DateTimePicker controls
            DateTime startDate = dateTimePicker_start.Value; // Sets start date to dateTimePicker_start.value
            DateTime endDate = dateTimePicker_end.Value; // Sets end date to dateTimePicker_end.Value

            // Sets filteredList to return value of orignal function using obtained start and end date from their respective dateTimePicker
            List<Candlestick> filteredList = FilterByDateRange(candlesticks, startDate, endDate);

            boundCandlesticks = new BindingList<Candlestick>(filteredList); // boundCandlesticks is made out of the created filtered list
        }

        /// <summary>
        /// Method displays candlestick data using a given filtered list of candlesticks
        /// </summary>
        /// <param name="filteredList">Filtered list of candlesticks</param>
        /// <returns>Filtered list</returns>
        private List<Candlestick> DisplayData(List<Candlestick> filteredList) // Method to display candlestick data
        {
            boundCandlesticks = new BindingList<Candlestick>(filteredList); // boundCandlesticks is set to a binding list made of the filteredList

            Normalize(); //Calls normalize function prior to binding

            bindingSource_candlestick.DataSource = boundCandlesticks; // bindingSource_candlestick.DataSource is set to the created bound candlesticks

            //Members of the OHLC and Volume charts are set for the display
            chart_OHLCV.Series["Series_OHLC"].XValueMember = "Date";
            chart_OHLCV.Series["Series_OHLC"].YValueMembers = "High,Low,Open,Close";
            chart_OHLCV.Series["Series_volume"].XValueMember = "Date";
            chart_OHLCV.Series["Series_volume"].YValueMembers = "Volume";

            UpdateComboBoxWithPatterns(filteredList); //Updates the combobox in the form with the calculated patterns in each smartcandlestick

            return filteredList; // Returns filtered list
        }

        /// <summary>
        /// Overloaded method takes in data from dateTimePicker start and end vales to call function
        /// </summary>
        private void DisplayData() // Overloaded method takes in data from dateTimePicker start and end vales to call function
        {
            List<Candlestick> filteredList = FilterByDateRange(candlesticks, dateTimePicker_start.Value, dateTimePicker_end.Value); // Filters candlestick data from given form data
            DisplayData(filteredList); // Calling DisplayData method using filtered list
        }

        /// <summary>
        /// Method to update candlestick data based on the user's updated date selection
        /// </summary>
        /// <param name="candlesticks">List of candlesticks</param>
        /// <param name="startDate">Start of selected range</param>
        /// <param name="endDate">End of selected range</param>
        /// <returns>Filtered list of candlesticks</returns>
        private List<Candlestick> UpdateData(List<Candlestick> candlesticks, DateTime startDate, DateTime endDate) // Method to update candlestick data based on the user's updated date selection
        {
            List<Candlestick> filteredList = FilterByDateRange(candlesticks, startDate, endDate); // Filters candlesticks based on selected range
            UpdateComboBoxWithPatterns(filteredList); //Updates the combobox in the form with the calculated patterns in each smartcandlestick

            return DisplayData(filteredList); // Returns display data return value when given the selected filtered list
        }

        /// <summary>
        /// Event handler for the "Update" button click
        /// </summary>
        private void button_update1_Click(object sender, EventArgs e) // Event handler for Update click
        {
            DateTime startDate = dateTimePicker_start.Value; // Gets start date from dateTimePicker_start.Value
            DateTime endDate = dateTimePicker_end.Value; // Gets end date from dateTimePicker_end.Value

            UpdateData(candlesticks, startDate, endDate); // Updates candlesticks for user display
        }

        /// <summary>
        /// Adds patterns to dictionary inside of smartcandlestick. Method of the form so the smart candlestick
        /// has more flexibility with regards to the patterns that can be added to it.
        /// </summary>
        /// <param name="scs">Smartcandlestick<param>
        private void CalcProperties(SmartCandlestick scs)
        {
            // Calcuates Bullish property of smartcandlestick 
            scs.Dictionary_Patterns["IsBullish"] = scs.close > scs.open;

            // Calcuates Bearish property of smartcandlestick 
            scs.Dictionary_Patterns["IsBearish"] = scs.open > scs.close;

            // Calcuates Neutral property of smartcandlestick 
            scs.Dictionary_Patterns["IsNeutral"] = scs.open == scs.close;

            // Calcuates Marubozu property of smartcandlestick 
            scs.Dictionary_Patterns["IsMarubozu"] = scs.BodyRange != 0 && scs.Range / scs.BodyRange >= 2;

            // Calcuates Hammer property of smartcandlestick 
            scs.Dictionary_Patterns["IsHammer"] = scs.LowerTail >= 2 * scs.BodyRange && scs.UpperTail <= scs.BodyRange / 2;

            // Calcuates Doji property of smartcandlestick 
            scs.Dictionary_Patterns["IsDoji"] = Math.Abs((double)(scs.close - scs.open)) <= 0.05 * (double)scs.Range;

            // Calcuates Dragonfly and Gravestone Doji property of smartcandlestick 
            //
            if (scs.Dictionary_Patterns["IsDoji"] == true) //If the smartcandlestick is a Doji it can be the following two patterns as well
            {
                // Equation to calculate Dragonfly Doji

                decimal avgPrice = (scs.open + scs.high + scs.close) / 3; // Calculation for avg price between open, high, and close

                // Percent difference acts as a measure for the clossness between the low price and average price
                decimal percentDiff = Math.Abs((scs.low - avgPrice) / avgPrice) * 100;

                // If percentDiff is greater than the threshold the Dragonfly doji is valid
                bool signiDiff = percentDiff > 0.1m;

                // Dragonfly Doji is true if the open, high, and close prices are either equal or close in price
                // If all the values are within 2% of each other the candlestick is a Dragonfly Doji
                scs.Dictionary_Patterns["IsDragonflyDoji"] = 
                                      (Math.Abs((double)(scs.open - scs.high)) <= 0.2 * (double)scs.Range) &&
                                      (Math.Abs((double)(scs.high - scs.close)) <= 0.2 * (double)scs.Range) &&
                                      (Math.Abs((double)(scs.open - scs.close)) <= 0.2 * (double)scs.Range) &&
                                      (signiDiff);

                // Calcuates Gravestone Doji property of smartcandlestick 

                avgPrice = (scs.open + scs.low + scs.close) / 3; // Calculates the avg price between open, low, and close

                // Percent difference acts as a measure for the clossness between the high price and average price
                percentDiff = Math.Abs((scs.high - avgPrice) / avgPrice) * 100;

                // If percentDiff is greater than the threshold the Dragonfly doji is valid
                signiDiff = percentDiff > 0.1m;

                // Gravestone Doji is true if the open, close, and low prices are either equal or close in price
                // If all the values are within 2% of each other the candlestick is a Gravestone Doji

                scs.Dictionary_Patterns["IsGravestoneDoji"] = 
                                        (Math.Abs((double)(scs.open - scs.low)) <= 0.2 * (double)scs.Range) &&
                                        (Math.Abs((double)(scs.low - scs.close)) <= 0.2 * (double)scs.Range) &&
                                        (Math.Abs((double)(scs.open - scs.close)) <= 0.2 * (double)scs.Range) &&
                                        (signiDiff);

            }
            else //If not already a doji these values will automatically be false
            {
                scs.Dictionary_Patterns["IsDragonflyDoji"] = false;
                scs.Dictionary_Patterns["IsGravestoneDoji"] = false;
            }
        }

        /// <summary>
        /// Function will populate combobox with the patterns found in the smartcandlestick and has
        /// functionality which allows for the combobox to be reset between every form update
        /// </summary>
        /// <param name="ListCandlesticks">List of candlesticks, will pull a smartcandlestick to look at dictionary</param>
        private void UpdateComboBoxWithPatterns(List<Candlestick> ListCandlesticks)
        {
            chart_OHLCV.Annotations.Clear(); // Clears any annotations present in chart prior to call

            if(comboBox_properties.SelectedIndex == -1) //Resets comboBox to display original text when reset
            {
                comboBox_properties.Text = "Candlestick Properties";
            }

            if (ListCandlesticks.Count != 0) //Checks if list is empty
            {
                comboBox_properties.Items.Clear(); //Clears prior combobox entries
                SmartCandlestick scs = (SmartCandlestick)ListCandlesticks[0]; //Pulls 1st smartcandlestick to look at its dictionary
                foreach (string key in scs.Dictionary_Patterns.Keys) //Will loop through each of the keys from the dictionary
                {
                    comboBox_properties.Items.Add(key); // Adds keys in dictionary to combobox
                }
            }
        }
        /// <summary>
        /// Upon selecting a combobox pattern the function will display arrows where a pattern is located
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_Patterns_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart_OHLCV.Annotations.Clear(); //Clears previous annotations in case of update
            for (int i = 0; i < boundCandlesticks.Count; i++) //Loops through all candlesticks in display
            {
                SmartCandlestick scs = (SmartCandlestick)boundCandlesticks[i]; //specific smartcandlestick from list
                DataPoint dataPoint = chart_OHLCV.Series[0].Points[i]; // specific datapoint in chart
                if (scs != null)
                {
                    ArrowAnnotation arrow = new ArrowAnnotation(); //Creates new arrow annotation
                    // Specifications for dimensions of annotation arrow
                    arrow.ArrowSize = 4;
                    arrow.Height = 10;
                    arrow.Width = 0;
                    arrow.BackColor = Color.Black;
                    arrow.AnchorOffsetY = 10;
                    arrow.ArrowStyle = ArrowStyle.Simple;

                    if (scs.Dictionary_Patterns[comboBox_properties.SelectedItem.ToString()]) //sets arrow to candlestick with specified pattern
                    {
                        arrow.SetAnchor(dataPoint); //Sets arrow to location of candlestick
                        chart_OHLCV.Annotations.Add(arrow); // Adds arrow to chart
                    }
                }
            }
        }

    }
}



