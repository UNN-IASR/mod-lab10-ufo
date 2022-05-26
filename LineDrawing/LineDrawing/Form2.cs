using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LineDrawing
{
    public partial class Form2 : Form
    {
        public Form2(List<double> points)
        {
            InitializeComponent();
            chart1.Series.Add(new Series());

            chart1.Series[0].IsVisibleInLegend = false;
            chart1.Series[1].IsVisibleInLegend = false;

            chart1.ChartAreas[0].AxisY.Title = "Радиус зоны попадания";
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 5;
            chart1.ChartAreas[0].AxisY.MajorGrid.Interval = 0.5;

            chart1.ChartAreas[0].AxisX.Title = "Количество членов ряда";
            chart1.ChartAreas[0].AxisX.Minimum = 2;
            chart1.ChartAreas[0].AxisX.Maximum = 10;
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 1;


            chart1.Series[0].Color = Color.Red;
            chart1.Series[1].Color = Color.Blue;
            chart1.Series[0].ChartType = SeriesChartType.Line;
            chart1.Series[1].ChartType = SeriesChartType.Point;

            for (int i = 0; i < points.Count; i++)
            {
                chart1.Series[0].Points.AddXY(i + 2, Math.Round(points[i], 1));
                chart1.Series[1].Points.AddXY(i + 2, Math.Round(points[i], 1));
            }
        }
    }
}
