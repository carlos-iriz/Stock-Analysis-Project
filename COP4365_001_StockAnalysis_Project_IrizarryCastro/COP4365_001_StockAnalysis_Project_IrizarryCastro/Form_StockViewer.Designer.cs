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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button_loader1 = new System.Windows.Forms.Button();
            this.button_update1 = new System.Windows.Forms.Button();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.dataGridView_1 = new System.Windows.Forms.DataGridView();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lowDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource_candlestick = new System.Windows.Forms.BindingSource(this.components);
            this.chart_OHLCV = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.openFileDialog_stockticker = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_candlestick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_OHLCV)).BeginInit();
            this.SuspendLayout();
            // 
            // button_loader1
            // 
            this.button_loader1.Location = new System.Drawing.Point(728, 116);
            this.button_loader1.Name = "button_loader1";
            this.button_loader1.Size = new System.Drawing.Size(128, 23);
            this.button_loader1.TabIndex = 0;
            this.button_loader1.Text = "Pick a Stock";
            this.button_loader1.UseVisualStyleBackColor = true;
            this.button_loader1.Click += new System.EventHandler(this.button_loader_Click);
            // 
            // button_update1
            // 
            this.button_update1.Location = new System.Drawing.Point(728, 172);
            this.button_update1.Name = "button_update1";
            this.button_update1.Size = new System.Drawing.Size(128, 23);
            this.button_update1.TabIndex = 1;
            this.button_update1.Text = "Update";
            this.button_update1.UseVisualStyleBackColor = true;
            this.button_update1.Click += new System.EventHandler(this.button_update1_Click);
            // 
            // dateTimePicker_start
            // 
            this.dateTimePicker_start.Location = new System.Drawing.Point(694, 12);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_start.TabIndex = 2;
            this.dateTimePicker_start.Value = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.Location = new System.Drawing.Point(694, 67);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_end.TabIndex = 3;
            // 
            // dataGridView_1
            // 
            this.dataGridView_1.AutoGenerateColumns = false;
            this.dataGridView_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateDataGridViewTextBoxColumn,
            this.openDataGridViewTextBoxColumn,
            this.highDataGridViewTextBoxColumn,
            this.lowDataGridViewTextBoxColumn,
            this.closeDataGridViewTextBoxColumn,
            this.volumeDataGridViewTextBoxColumn});
            this.dataGridView_1.DataSource = this.bindingSource_candlestick;
            this.dataGridView_1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_1.Name = "dataGridView_1";
            this.dataGridView_1.Size = new System.Drawing.Size(642, 201);
            this.dataGridView_1.TabIndex = 4;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            // 
            // openDataGridViewTextBoxColumn
            // 
            this.openDataGridViewTextBoxColumn.DataPropertyName = "open";
            this.openDataGridViewTextBoxColumn.HeaderText = "open";
            this.openDataGridViewTextBoxColumn.Name = "openDataGridViewTextBoxColumn";
            // 
            // highDataGridViewTextBoxColumn
            // 
            this.highDataGridViewTextBoxColumn.DataPropertyName = "high";
            this.highDataGridViewTextBoxColumn.HeaderText = "high";
            this.highDataGridViewTextBoxColumn.Name = "highDataGridViewTextBoxColumn";
            // 
            // lowDataGridViewTextBoxColumn
            // 
            this.lowDataGridViewTextBoxColumn.DataPropertyName = "low";
            this.lowDataGridViewTextBoxColumn.HeaderText = "low";
            this.lowDataGridViewTextBoxColumn.Name = "lowDataGridViewTextBoxColumn";
            // 
            // closeDataGridViewTextBoxColumn
            // 
            this.closeDataGridViewTextBoxColumn.DataPropertyName = "close";
            this.closeDataGridViewTextBoxColumn.HeaderText = "close";
            this.closeDataGridViewTextBoxColumn.Name = "closeDataGridViewTextBoxColumn";
            // 
            // volumeDataGridViewTextBoxColumn
            // 
            this.volumeDataGridViewTextBoxColumn.DataPropertyName = "volume";
            this.volumeDataGridViewTextBoxColumn.HeaderText = "volume";
            this.volumeDataGridViewTextBoxColumn.Name = "volumeDataGridViewTextBoxColumn";
            // 
            // bindingSource_candlestick
            // 
            this.bindingSource_candlestick.DataSource = typeof(COP4365_001_StockAnalysis_Project_IrizarryCastro.Candlestick);
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
            legend1.Name = "Legend1";
            this.chart_OHLCV.Legends.Add(legend1);
            this.chart_OHLCV.Location = new System.Drawing.Point(12, 219);
            this.chart_OHLCV.Name = "chart_OHLCV";
            series1.ChartArea = "ChartArea_OHLC";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.CustomProperties = "PriceDownColor=Red, PriceUpColor=Lime, LabelValueType=High";
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Series_OHLC";
            series1.XValueMember = "Date";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueMembers = "High,Low,Open,Closed";
            series1.YValuesPerPoint = 4;
            series2.ChartArea = "ChartArea_volume";
            series2.Legend = "Legend1";
            series2.Name = "Series_volume";
            series2.XValueMember = "Date";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueMembers = "Volume";
            this.chart_OHLCV.Series.Add(series1);
            this.chart_OHLCV.Series.Add(series2);
            this.chart_OHLCV.Size = new System.Drawing.Size(965, 245);
            this.chart_OHLCV.TabIndex = 5;
            this.chart_OHLCV.Text = "chart1";
            // 
            // openFileDialog_stockticker
            // 
            this.openFileDialog_stockticker.FileName = "openFileDialog1";
            this.openFileDialog_stockticker.Filter = "CVS files (*.csv)|*.csv|All files (*.)|*.|Monthly|*-Month.csv|Weekly|*-Week.csv|D" +
    "aily|*-Day.csv";
            this.openFileDialog_stockticker.InitialDirectory = "C:\\Users\\carlos60\\OneDrive - University of South Florida\\Desktop\\Stock_Data";
            this.openFileDialog_stockticker.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_stockticker_FileOk);
            // 
            // Form_StockViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 485);
            this.Controls.Add(this.chart_OHLCV);
            this.Controls.Add(this.dataGridView_1);
            this.Controls.Add(this.dateTimePicker_end);
            this.Controls.Add(this.dateTimePicker_start);
            this.Controls.Add(this.button_update1);
            this.Controls.Add(this.button_loader1);
            this.Name = "Form_StockViewer";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_candlestick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_OHLCV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_loader1;
        private System.Windows.Forms.Button button_update1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_start;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
        private System.Windows.Forms.DataGridView dataGridView_1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_OHLCV;
        private System.Windows.Forms.OpenFileDialog openFileDialog_stockticker;
        private System.Windows.Forms.BindingSource bindingSource_candlestick;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn openDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn highDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
    }
}

