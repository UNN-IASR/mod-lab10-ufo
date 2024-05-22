namespace Lab10_ufo
{
    partial class FormUfo
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.btnStart = new System.Windows.Forms.Button();
            this.picBoxGraph = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnStop = new System.Windows.Forms.Button();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(11, 652);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(152, 46);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Старт";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // picBoxGraph
            // 
            this.picBoxGraph.Location = new System.Drawing.Point(11, 10);
            this.picBoxGraph.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picBoxGraph.Name = "picBoxGraph";
            this.picBoxGraph.Size = new System.Drawing.Size(1082, 638);
            this.picBoxGraph.TabIndex = 1;
            this.picBoxGraph.TabStop = false;
            this.picBoxGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.picBoxGraph_Paint);
            // 
            // timer
            // 
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(179, 652);
            this.btnStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(143, 46);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Стоп";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // chart
            // 
            chartArea2.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisX.Title = "Радиус точки";
            chartArea2.AxisY.Title = "Члены ряда";
            chartArea2.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea2);
            this.chart.Location = new System.Drawing.Point(508, 391);
            this.chart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart.Name = "chart";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Name = "Точность";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(585, 257);
            this.chart.TabIndex = 5;
            this.chart.Text = "chart1";
            title2.Name = "Title1";
            title2.Text = "Точность расчетов";
            this.chart.Titles.Add(title2);
            this.chart.Visible = false;
            // 
            // FormUfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 708);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.picBoxGraph);
            this.Controls.Add(this.btnStart);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormUfo";
            this.Text = "FormUfo";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox picBoxGraph;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
    }
}
