using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScottPlot.WinForms;

namespace src_lab10
{
    public partial class Form1 : Form
    {

        public Point P1=new Point(-1,-1), P2=new Point(-1,-1);
        public int mode = 1, n = 5, ind=0;
        public double eps = 1;
        ScottPlot.WinForms.FormsPlot fp;
        public int[] ns = new int[20];
        public double[] epss = new double[20];
        public bool isingraph = false;

        public Form1()
        {
            InitializeComponent();

            fp = new ScottPlot.WinForms.FormsPlot() { Dock = DockStyle.Fill };
            Controls.Add(fp);
            fp.Visible = false;

            pictureBox1.BackgroundImage = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            
            DrawPlace();

            Graphics gr = Graphics.FromImage(pictureBox1.Image);
            gr.SmoothingMode = SmoothingMode.HighQuality;
            this.DoubleBuffered = true;
            gr.Dispose();
        }

        private void DrawPlace() {
            Graphics g = Graphics.FromImage(pictureBox1.BackgroundImage);

            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1));
            g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), new Rectangle(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1));

            g.Dispose();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (P1.X < 0 || P2.X < 0 ||P1.Y <0 || P2.Y <0) MessageBox.Show("Создайте две точки!");
            else {
                pictureBox1.Invalidate();
                pictureBox1.Enabled = false;
                
                //Line(P1.X,P1.Y,P2.X,P2.Y); //the 1st suggested method
                LineDrawing();

                pictureBox1.Enabled = true;
            }
        }

        private void LineDrawing() {
            double angle = Math.Atan((double)(P2.Y - P1.Y) / (P2.X - P1.X)), sign = (double)(P2.X - P1.X) / Math.Abs(P2.X - P1.X);
            double distance = Math.Sqrt(Math.Pow((double)(P2.Y - P1.Y),2) + Math.Pow((double)(P2.X - P1.X), 2)), mindist = distance;
            double step = 20;
            double x = P1.X, y = P1.Y;
            
            while (mindist > eps ) 
            {
                x += step * sign*Cos(angle); 
                y += step * sign*Sin(angle);
                DrawPoint(Round(x), Round(y));
                distance = Math.Sqrt(Math.Pow((double)(P2.Y - y), 2) + Math.Pow((double)(P2.X - x), 2));
                if (mindist > distance) mindist = distance;
                if (distance > mindist) break;        
            }

            if (isingraph)
            {
                ns[ind] = n;
                if(eps==20 || epss[ind]>mindist) epss[ind] = mindist;
            }
        }

        static double Factorial(int numb)
        {
            double res = 1;
            for (double i = numb; i > 1; i--)
                res *= i;
            return res;
        }

        private double Sin(double angle) {
            double sum = 0;
            for(int i=1; i<=n; i++) {
                sum += Math.Pow(-1, i - 1) * Math.Pow(angle, 2 * i - 1) / Factorial(2 * i - 1);
            }
            return sum;
        }

        private double Cos(double angle)
        {
            double sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += Math.Pow(-1, i - 1) * Math.Pow(angle, 2 * i - 2) / Factorial(2 * i - 2);
            }
            return sum;
        }

        private double Atan(double num) //
        {
            double sum = 0;
            if (Math.Abs(num) >= 1) {
                sum += Math.PI * Math.Sqrt(Math.Pow(num, 2)) / (2 * num);
                for (int i = 0; i <= n-1; i++)
                {
                    sum -= Math.Pow(-1, i) * Math.Pow(num, -2 * i - 1) / (2 * i + 1);
                }
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    sum += Math.Pow(-1, i - 1) * Math.Pow(num, 2 * i - 1) / (2 * i - 1);
                }  
            }
            return sum;
        }

        private void Line(int x1, int y1, int x2, int y2)
        {
            double k = (double)(y2 - y1) / (x2 - x1);
            double b = y1 - k * x1;
            for (int x = Math.Min(x1,x2); x <= Math.Max(x1,x2); x++) { 
            
            DrawPoint(x, Round(k * x + b));
            }
        }

        private int Round(double num)
        {
            if ((num - (int)num) >= 0.5) return (int)num + 1;
            else return (int)num;
        }

        private void DrawPoint(int x, int y) {
            Graphics gr = Graphics.FromImage(pictureBox1.Image);
            pictureBox1.Invalidate();
            gr.FillEllipse(new SolidBrush(Color.Black), new Rectangle(x+2 , y+2 , 3, 3));

            gr.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
                fp.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
                pictureBox1.Visible = false;

            isingraph = true;

            P1.X = -pictureBox1.Width + 10; P1.Y = -pictureBox1.Height +10;
            P2.X = 2*pictureBox1.Width -10 ; P2.Y = 2*pictureBox1.Height -10 ;

            for(int i=1; i<=20; i++){
                n = i;
                for (int j=20; j>=1;j--) {
                    eps = j;
                    LineDrawing();
                }
                ind++;
            }

            fp.Plot.Add.Scatter(epss, ns);
            fp.Plot.XLabel("Точность попадания");
            fp.Plot.YLabel("Количество членов ряда");

            fp.Refresh();
            fp.Plot.SavePng("dia.png", 1280, 720);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int X = e.X, Y=e.Y;

            if (mode == 1) { mode = 2; P1.X = X; P1.Y = Y; }
            else { mode = 1; P2.X = X; P2.Y = Y; }

            start_points();
        }

        private void start_points() {
            pictureBox1.Image.Dispose();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gr = Graphics.FromImage(pictureBox1.Image);

            pictureBox1.Invalidate();

            if(P1.X>=0 && P1.Y>=0)gr.FillEllipse(new SolidBrush(Color.Black), new Rectangle(P1.X - 2, P1.Y - 2, 5, 5));
            if (P2.X >= 0 && P2.Y >= 0) { 
                gr.FillEllipse(new SolidBrush(Color.Black), new Rectangle(P2.X - 2, P2.Y - 2, 5, 5));
                gr.DrawEllipse(new Pen(new SolidBrush(Color.Black)), new Rectangle(Round(P2.X - eps), Round(P2.Y - eps), (int)(2 * eps), (int)(2 * eps)));
            }

            gr.Dispose();
        }
    }
}
