using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COP4365_001_StockAnalysis_Project_IrizarryCastro // Defines namespace
{
    public partial class Form_StockViewer : Form // Defines Form_StockViewer class
    {
        // The following variables are initialized here in order to hold values of multiple functions
        private List<Candlestick> candlesticks = null; // Declares a list made up of candlesticks
        private BindingList<Candlestick> boundCandlesticks = null; // Declares a binding list made up of candlesticks

        /// <summary>
        /// Constructor for the form class 
        /// </summary>
        public Form_StockViewer() // Constructor definition
        {
            InitializeComponent(); // Initializes the components of the Form_StockViewer
            // Initializes previously defined candlestick list and binding candlestick list
            candlesticks = new List<Candlestick>(1024); // Initializes candlestick list with a max capacity of 1024
            boundCandlesticks = new BindingList<Candlestick>(); // Initializes binding list
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
        /// Upon Reading a "Good File" the function will call the following function:
        /// GoReadFile(); Reads data from a given file
        /// FilterByDateRange(); Filters given data by the date range given
        /// Normalize(); Normalizes given data //////////////////////////////////////////////
        /// DisplayData(); Displays data on form
        /// </summary>
        private void openFileDialog_stockticker_FileOk(object sender, CancelEventArgs e) // Event handler for file selection in OpenFileDialog
        {
            GoReadFile(); //Reads data from a given file

            FilterByDateRange(); // Filters given data by the date range given

            DisplayData(); //Displays data on form
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
                        Candlestick cs = new Candlestick(line); // Creates a new candlestick object for each line
                        candlesticks.Add(cs); // Adds created candlestick to candlesticks list
                    }

                    resultingList = candlesticks; // resulting list holds list of candlesticks
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

            Normalize(); //Calls normalize function prior to display

            bindingSource_candlestick.DataSource = boundCandlesticks; // bindingSource_candlestick.DataSource is set to the created bound candlesticks

            chart_OHLCV.Series["Series_OHLC"].Points.DataBind(boundCandlesticks, "Date", "High,Low,Open,Close", ""); // Binding data to OHLC series
            chart_OHLCV.Series["Series_volume"].Points.DataBind(boundCandlesticks, "Date", "Volume", ""); // Binding volume data to volume series

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
    }
}
