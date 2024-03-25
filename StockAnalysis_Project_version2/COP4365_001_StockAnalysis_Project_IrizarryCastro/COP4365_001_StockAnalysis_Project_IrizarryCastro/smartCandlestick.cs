using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4365_001_StockAnalysis_Project_IrizarryCastro
{
    internal class SmartCandlestick : Candlestick
    {
        // Additional properties for SmartCandlestick
        public decimal Range { get; set; } //Range Property
        public decimal BodyRange { get; set; } //Body Range Property
        public decimal TopPrice { get; set; } //Top Price Property
        public decimal BottomPrice { get; set; } //Bottom Price Property
        public decimal UpperTail { get; set; } //Upper Tail Property
        public decimal LowerTail { get; set; } //Lower Tail Property

        public Dictionary<string, bool> Dictionary_Patterns { get; set; } //Empty dictionary to place additional patterns

        /// <summary>
        /// Uses base class contructor (candlestick) to create a smartcandlestick
        /// </summary>
        /// <param name="rowOfData">Takes in string with file data just like candlestick constructor</param>
        public SmartCandlestick(string rowOfData) : base(rowOfData)
        {
            ComputeExtraProperties();
        }

        /// <summary>
        /// Constructor that takes in a candlestick to create a smartcandlestick
        /// </summary>
        /// <param name="cs">Candlestick</param>
        public SmartCandlestick(Candlestick cs)
	    {
            open = cs.open;
            high = cs.high;
            low = cs.low;
            close = cs.close;
            volume = cs.volume;
            date = cs.date;
            ComputeExtraProperties();
	    }

        /// <summary>
        /// Method to calculate additional properties of smartcandlestick
        /// </summary>
        private void ComputeExtraProperties()
        {
            Range = Math.Abs(high - low);
            TopPrice = Math.Max(open, close);
            BottomPrice = Math.Min(open, close);
            BodyRange = Math.Abs(TopPrice - BottomPrice);
            UpperTail = Math.Abs(high - TopPrice);
            LowerTail = Math.Abs(BottomPrice - low);
            Dictionary_Patterns = new Dictionary<string, bool>(); // Init empty dictionary 
        }
    }
}
