namespace COP4365_001_StockAnalysis_Project_IrizarryCastro
{
    partial class Form_StockViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button_loader1 = new System.Windows.Forms.Button();
            this.button_update1 = new System.Windows.Forms.Button();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.bindingSource_candlestick = new System.Windows.Forms.BindingSource(this.components);
            this.chart_OHLCV = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.openFileDialog_stockticker = new System.Windows.Forms.OpenFileDialog();
            this.comboBox_properties = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_candlestick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_OHLCV)).BeginInit();
            this.SuspendLayout();
            // 
            // button_loader1
            // 
            this.button_loader1.Location = new System.Drawing.Point(266, 427);
            this.button_loader1.Name = "button_loader1";
            this.button_loader1.Size = new System.Drawing.Size(128, 23);
            this.button_loader1.TabIndex = 0;
            this.button_loader1.Text = "Pick a Stock";
            this.button_loader1.UseVisualStyleBackColor = true;
            this.button_loader1.Click += new System.EventHandler(this.button_loader_Click);
            // 
            // button_update1
            // 
            this.button_update1.Location = new System.Drawing.Point(617, 430);
            this.button_update1.Name = "button_update1";
            this.button_update1.Size = new System.Drawing.Size(128, 23);
            this.button_update1.TabIndex = 1;
            this.button_update1.Text = "Update";
            this.button_update1.UseVisualStyleBackColor = true;
            this.button_update1.Click += new System.EventHandler(this.button_update1_Click);
            // 
            // dateTimePicker_start
            // 
            this.dateTimePicker_start.Location = new System.Drawing.Point(12, 430);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_start.TabIndex = 2;
            this.dateTimePicker_start.Value = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.Location = new System.Drawing.Point(777, 431);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_end.TabIndex = 3;
            // 
            // chart_OHLCV
            // 
            this.chart_OHLCV.BorderlineColor = System.Drawing.SystemColors.Window;
            chartArea1.Name = "ChartArea_OHLC";
            chartArea2.AlignWithChartArea = "ChartArea_OHLC";
            chartArea2.Name = "ChartArea_volume";
            this.chart_OHLCV.ChartAreas.Add(chartArea1);
            this.chart_OHLCV.ChartAreas.Add(chartArea2);
            this.chart_OHLCV.DataSource = this.bindingSource_candlestick;
            this.chart_OHLCV.Location = new System.Drawing.Point(12, 8);
            this.chart_OHLCV.Name = "chart_OHLCV";
            series1.ChartArea = "ChartArea_OHLC";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.CustomProperties = "PriceDownColor=Red, PriceUpColor=Lime, LabelValueType=High";
            series1.IsXValueIndexed = true;
            series1.Name = "Series_OHLC";
            series1.XValueMember = "Date";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueMembers = "High,Low,Open,Closed";
            series1.YValuesPerPoint = 4;
            series2.ChartArea = "ChartArea_volume";
            series2.IsXValueIndexed = true;
            series2.Name = "Series_volume";
            series2.XValueMember = "Date";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueMembers = "Volume";
            this.chart_OHLCV.Series.Add(series1);
            this.chart_OHLCV.Series.Add(series2);
            this.chart_OHLCV.Size = new System.Drawing.Size(965, 413);
            this.chart_OHLCV.TabIndex = 5;
            this.chart_OHLCV.Text = "chart1";
            // 
            // openFileDialog_stockticker
            // 
            this.openFileDialog_stockticker.FileName = "openFileDialog1";
            this.openFileDialog_stockticker.Filter = "CVS files (*.csv)|*.csv|All files (*.)|*.|Monthly|*-Month.csv|Weekly|*-Week.csv|D" +
    "aily|*-Day.csv";
            this.openFileDialog_stockticker.FilterIndex = 3;
            this.openFileDialog_stockticker.InitialDirectory = "C:\\Users\\carlos60\\OneDrive - University of South Florida\\Desktop\\Stock_Data";
            this.openFileDialog_stockticker.Multiselect = true;
            this.openFileDialog_stockticker.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_stockticker_FileOk);
            // 
            // comboBox_properties
            // 
            this.comboBox_properties.FormattingEnabled = true;
            this.comboBox_properties.Location = new System.Drawing.Point(447, 431);
            this.comboBox_properties.Name = "comboBox_properties";
            this.comboBox_properties.Size = new System.Drawing.Size(130, 21);
            this.comboBox_properties.TabIndex = 7;
            this.comboBox_properties.Text = "Candlestick Properties";
            this.comboBox_properties.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Patterns_SelectedIndexChanged);
            // 
            // Form_StockViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 485);
            this.Controls.Add(this.comboBox_properties);
            this.Controls.Add(this.chart_OHLCV);
            this.Controls.Add(this.dateTimePicker_end);
            this.Controls.Add(this.dateTimePicker_start);
            this.Controls.Add(this.button_update1);
            this.Controls.Add(this.button_loader1);
            this.Name = "Form_StockViewer";
            this.Text = "Stock Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_candlestick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_OHLCV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_loader1;
        private System.Windows.Forms.Button button_update1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_start;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_OHLCV;
        private System.Windows.Forms.OpenFileDialog openFileDialog_stockticker;
        private System.Windows.Forms.BindingSource bindingSource_candlestick;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn openDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn highDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox comboBox_properties;
    }
}

