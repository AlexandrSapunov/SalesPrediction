namespace SalesPrediction
{
    partial class ChartWindow
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartLastYear = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartCurrentYear = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.buttonDrawChart = new System.Windows.Forms.Button();
            this.buttonPredict = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartLastYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCurrentYear)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartLastYear
            // 
            chartArea1.Name = "ChartArea1";
            this.chartLastYear.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartLastYear.Legends.Add(legend1);
            this.chartLastYear.Location = new System.Drawing.Point(12, 12);
            this.chartLastYear.Name = "chartLastYear";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartLastYear.Series.Add(series1);
            this.chartLastYear.Size = new System.Drawing.Size(950, 350);
            this.chartLastYear.TabIndex = 0;
            this.chartLastYear.Text = "chart1";
            // 
            // chartCurrentYear
            // 
            chartArea2.Name = "ChartArea1";
            this.chartCurrentYear.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartCurrentYear.Legends.Add(legend2);
            this.chartCurrentYear.Location = new System.Drawing.Point(12, 418);
            this.chartCurrentYear.Name = "chartCurrentYear";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartCurrentYear.Series.Add(series2);
            this.chartCurrentYear.Size = new System.Drawing.Size(950, 350);
            this.chartCurrentYear.TabIndex = 1;
            this.chartCurrentYear.Text = "chart2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxYear);
            this.groupBox1.Controls.Add(this.buttonDrawChart);
            this.groupBox1.Controls.Add(this.buttonPredict);
            this.groupBox1.Controls.Add(this.buttonLoad);
            this.groupBox1.Location = new System.Drawing.Point(976, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 756);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Данные";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Год";
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Location = new System.Drawing.Point(9, 53);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(384, 21);
            this.comboBoxYear.TabIndex = 3;
            // 
            // buttonDrawChart
            // 
            this.buttonDrawChart.Location = new System.Drawing.Point(6, 672);
            this.buttonDrawChart.Name = "buttonDrawChart";
            this.buttonDrawChart.Size = new System.Drawing.Size(386, 35);
            this.buttonDrawChart.TabIndex = 2;
            this.buttonDrawChart.Text = "Отрисовать";
            this.buttonDrawChart.UseVisualStyleBackColor = true;
            this.buttonDrawChart.Click += new System.EventHandler(this.buttonDrawChart_Click);
            // 
            // buttonPredict
            // 
            this.buttonPredict.Location = new System.Drawing.Point(209, 713);
            this.buttonPredict.Name = "buttonPredict";
            this.buttonPredict.Size = new System.Drawing.Size(183, 33);
            this.buttonPredict.TabIndex = 1;
            this.buttonPredict.Text = "Прогноз";
            this.buttonPredict.UseVisualStyleBackColor = true;
            this.buttonPredict.Click += new System.EventHandler(this.buttonPredict_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(5, 713);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(198, 33);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.Text = "Загрузить данные";
            this.buttonLoad.UseVisualStyleBackColor = true;
            // 
            // ChartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1387, 780);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chartCurrentYear);
            this.Controls.Add(this.chartLastYear);
            this.Name = "ChartWindow";
            this.Text = "ChartWindow";
            ((System.ComponentModel.ISupportInitialize)(this.chartLastYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCurrentYear)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartLastYear;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCurrentYear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonDrawChart;
        private System.Windows.Forms.Button buttonPredict;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxYear;
    }
}