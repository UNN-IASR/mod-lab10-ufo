using System;
using System.Drawing;
using System.Windows.Forms;

namespace UFOGraph {
    public partial class LineModeling : Form {
        public LineModeling() {
            InitializeComponent();
            this.Invalidate();
        }

        int Fact(int x) {
            if (x == 0)
                return 1;
            else
                return x * Fact(x - 1);
        }

        double Tsin(int n, double x) {
            double sin = 0.0;
            for(int i = 1; i < n + 1; i++)
                sin += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / Fact(2 * i - 1);

            return sin;
        }

        double Tcos(int n, double x) {
            double cos = 0.0;
            for(int i = 1; i < n + 1; i++)
                cos += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 2) / Fact(2 * i - 2);

            return cos;
        }

        double Tatn(int n, double x) {
            double atn = 0;
            for (int i = 1; i < n + 1; i++)
                atn += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / (2 * i - 1);

            return atn;
        }

        void LineModeling_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            Pen line = new Pen(Color.Red, 2);
            Pen dot = new Pen(Color.Black, 2);

            double x1 = 10;
            double y1 = 10;
            double x2 = 400;
            double y2 = 370;
            double step = 1;
            int dim = 12;

            g.DrawEllipse(dot, (int)x1, (int)y1, 2, 2);
            g.DrawEllipse(dot, (int)x2, (int)y2, 2, 2);

            double a = Math.Abs(x1 - x2);
            double b = Math.Abs(y1 - y2);
            double value = a + b;
            double angle = -Tatn(dim, b / a);
            double distance = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));

            while (distance <= value) {
                y1 -= step * Tsin(dim, angle);
                x1 += step * Tcos(dim, angle);
                g.DrawEllipse(line, (int)x1, (int)y1, 1, 1);
                a = Math.Abs(x1 - x2);
                b = Math.Abs(y1 - y2);
                distance = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
                if (distance < value)
                    value = distance;
            }

            g.DrawString("Error: " + value.ToString("0.000"), new Font("Times New Roman", 18), Brushes.Black, new PointF(Width - Width / 3, 100));
        }
    }
}
