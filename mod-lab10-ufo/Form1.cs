using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScottPlot;
using ScottPlot.Colormaps;

namespace mod_lab10_ufo
{
    public partial class Form1 : Form
    {
        public int X_start, Y_start;
        public int X_end, Y_end;
        public double X, Y;

        public int Radius;
        public int Step;
        public int N;

        public double Distanction;
        public double Angle;

        public Form1()
        {
            InitializeComponent();
        }

        private void Initialization_DATA()
        {
            X_start = 1300;
            Y_start = 300;

            X_end = 1600;
            Y_end = 150;

            X = X_start;
            Y = Y_start;

            Distanction = Counting_Functions.OWN_DISTANT(X_start, Y_start, X_end, Y_end);

            Angle = Counting_Functions.OWN_ARCTANG(X_start, Y_start, X_end, Y_end);

            Radius = 100;
            Step = 10;
            N = 6;
        } 

        private void Form1_Load(object sender, EventArgs e)
        {
            Initialization_DATA();

            this.Location = new Point(25, 25);
            this.Width = 1800;
            this.Height = 900;
            timer1.Enabled = true;
            timer1.Interval = 10;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Part_1(Graphics g)
        {
            Draw_and_Save.StartPoint_and_Last_DrawArc(g, X_start, Y_start, X_end, Y_end, Radius);
            g.FillEllipse(new SolidBrush(System.Drawing.Color.Red), (float)(X - 7.5), (float)(Y - 7.5), 15, 15);
            timer1.Enabled = false;
            Draw_and_Save.SAVE_GRAFICS_IMAGE(X_start, Y_start, X_end, Y_end);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.ScaleTransform(0.8f, 0.8f);

            if (Distanction <= Radius)
            {
                Part_1(g);
            }
            else
            {
                Part_2(g);
            }
        }

        private void Part_2(Graphics g)
        {
            Draw_and_Save.StartPoint_and_Last_DrawArc(g, X_start, Y_start, X_end, Y_end, Radius);

            X += Step * Counting_Functions.OWN_COS(Angle, N);
            Y -= Step * Counting_Functions.OWN_SIN(Angle, N);

            g.FillEllipse(new SolidBrush(System.Drawing.Color.Purple), (float)(X - 7.5), (float)(Y - 7.5), 15, 15);

            Distanction = Math.Sqrt(Math.Pow(X_end - X, 2) + Math.Pow(Y_end - Y, 2));
        }
    }
}
