using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4365_001_StockAnalysis_Project_IrizarryCastro
{
    public class Candlestick // Defines Candlestick class
    {
        // The following contains all the properties for the Candlestick class
        public decimal open { get; set; } // Open price property
        public decimal high { get; set; } // High price property
        public decimal low { get; set; } // Low price property
        public decimal close { get; set; } // Close price property
        public ulong volume { get; set; } // Volume property
        public DateTime date { get; set; } // Date propery

        public Candlestick() { } //Default Constructor /////ADDED

        /// <summary>
        /// Constructor to convert data input from a CSV file into candlesticks.
        /// Definition of constructor for Candlestick class, takes in data from CSV file and
        /// converts into candlesticks format
        /// </summary>
        /// <param name="RowOfData">Takes in a row of data from a given CSV file</param>
        public Candlestick(string RowOfData) // Constructor function definition for candlestick class
        {
            char[] separators = new char[] { ',', ' ', '"' }; // Defines which separators will be used to split data from CSV's RowOfData 
            string[] subs = RowOfData.Split(separators, StringSplitOptions.RemoveEmptyEntries); // Splits RowOfData into sub-strings in subs

            // Get date string to parse it into DateTime
            string dateString = subs[0]; // Takes dateString from subs[0]
            date = DateTime.Parse(dateString); // Parses obtained dateString and stores in date property

            decimal temp; // Temp variable for parse

            //TryParse is used in the following section to parse all the data into the corresponding member variables of the candlestick class

            bool success = decimal.TryParse((subs[1]), out temp); // Open price is parsed
            if (success) open = Math.Round(temp, 2); // Assigns open price to candlestick instance

            success = decimal.TryParse((subs[2]), out temp); // High price is parsed
            if (success) high = Math.Round(temp, 2); // Assigns high price to candlestick instance

            success = decimal.TryParse((subs[3]), out temp); // Low price is parsed
            if (success) low = Math.Round(temp, 2); // Assigns low price to candlestick instance

            success = decimal.TryParse((subs[4]), out temp); // Close price is parsed
            if (success) close = Math.Round(temp, 2); // Assigns close price to candlestick instance

            ulong tempVolume; // Temp variable for parsing volume
            success = ulong.TryParse((subs[6]), out tempVolume); // Volume is parsed
            if (success) volume = tempVolume; // Assigns volume to candlestick instance
        }
    }
}
