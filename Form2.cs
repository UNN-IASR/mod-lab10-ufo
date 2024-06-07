using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace mipis10 {
    public partial class Form2 : Form {
        public Form2(List<double> list1, List<double> list2) {
            InitializeComponent();
            Draw(list1, list2);
        }

        public void Draw(List<double> list1, List<double> list2) {

            double[] x = list1.ToArray();
            double[] y = list2.ToArray();

            var pane = graph.GraphPane;
            pane.CurveList.Clear();
            pane.XAxis.Title.Text = "Количество членов ряда";
            pane.YAxis.Title.Text = "Погрешность";


            var curve = pane.AddCurve("Погрешность", x, y, Color.Red, SymbolType.Square);

            curve.Line.IsAntiAlias = true;

            pane.AxisChange();
        }
    }
}
