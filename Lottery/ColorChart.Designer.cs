namespace Lottery
{
    partial class ColorChart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lottoChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.numUD_Start = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numUD_End = new System.Windows.Forms.NumericUpDown();
            this.cbb_End = new System.Windows.Forms.ComboBox();
            this.cbb_Start = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.lottoChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_Start)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_End)).BeginInit();
            this.SuspendLayout();
            // 
            // lottoChart
            // 
            chartArea2.Name = "ChartArea1";
            this.lottoChart.ChartAreas.Add(chartArea2);
            legend2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            legend2.Name = "Legend1";
            this.lottoChart.Legends.Add(legend2);
            this.lottoChart.Location = new System.Drawing.Point(12, 36);
            this.lottoChart.Name = "lottoChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "Series1";
            this.lottoChart.Series.Add(series2);
            this.lottoChart.Size = new System.Drawing.Size(955, 307);
            this.lottoChart.TabIndex = 0;
            this.lottoChart.Text = "chart1";
            this.lottoChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lottoChart_MouseMove);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 349);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(955, 252);
            this.dataGridView1.TabIndex = 1;
            // 
            // numUD_Start
            // 
            this.numUD_Start.Location = new System.Drawing.Point(677, 7);
            this.numUD_Start.Name = "numUD_Start";
            this.numUD_Start.Size = new System.Drawing.Size(50, 21);
            this.numUD_Start.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(833, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "까지";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(892, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(733, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "부터";
            // 
            // numUD_End
            // 
            this.numUD_End.Location = new System.Drawing.Point(777, 7);
            this.numUD_End.Name = "numUD_End";
            this.numUD_End.Size = new System.Drawing.Size(50, 21);
            this.numUD_End.TabIndex = 7;
            // 
            // cbb_End
            // 
            this.cbb_End.FormattingEnabled = true;
            this.cbb_End.Location = new System.Drawing.Point(612, 7);
            this.cbb_End.Name = "cbb_End";
            this.cbb_End.Size = new System.Drawing.Size(57, 20);
            this.cbb_End.TabIndex = 8;
            // 
            // cbb_Start
            // 
            this.cbb_Start.FormattingEnabled = true;
            this.cbb_Start.Location = new System.Drawing.Point(510, 6);
            this.cbb_Start.Name = "cbb_Start";
            this.cbb_Start.Size = new System.Drawing.Size(57, 20);
            this.cbb_Start.TabIndex = 9;
            this.cbb_Start.Text = "1";
            // 
            // ColorChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 613);
            this.Controls.Add(this.cbb_Start);
            this.Controls.Add(this.cbb_End);
            this.Controls.Add(this.numUD_End);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numUD_Start);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lottoChart);
            this.Name = "ColorChart";
            this.Text = "ColorChart";
            this.Load += new System.EventHandler(this.ColorChart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lottoChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_Start)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_End)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart lottoChart;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.NumericUpDown numUD_Start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numUD_End;
        private System.Windows.Forms.ComboBox cbb_End;
        private System.Windows.Forms.ComboBox cbb_Start;
    }
}