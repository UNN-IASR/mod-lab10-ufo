using System.ComponentModel.Design.Serialization;

namespace UFO
{
    public partial class MainForm : Form
    {
        PointF start_point, end_point, move_point;
        SolidBrush brush = new SolidBrush(Color.DarkRed);
        Pen pen = new Pen(Color.DarkGreen, 4);
        int radius_point = 3;
        int rad = 3;
        int n = 2;
        int step = 5;
        double angle;
        double distance;
        float scale = 0.5f;
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            start_point = new PointF(20, 20);
            end_point = new PointF(this.ClientSize.Width*2 - 30, this.ClientSize.Height*2 - 30);
            move_point = new PointF(start_point.X, start_point.Y);

            angle = Atan(Math.Abs(end_point.Y - start_point.Y) / Math.Abs(end_point.X - start_point.X), n);
            distance = Math.Pow(this.Width*2 + this.Height * 2,2);
            //while (rad < 50)
            //{
                //math_func();
            //}
            timer1.Start();
        }
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            math_func();
            Graphics g = e.Graphics;
            g.ScaleTransform(scale, scale);
            g.FillEllipse(brush, start_point.X - radius_point, start_point.Y - radius_point, 2*radius_point, 2*radius_point);
            g.FillEllipse(brush, end_point.X - radius_point, end_point.Y - radius_point, 2*radius_point, 2*radius_point);
            g.DrawEllipse(pen, end_point.X - rad, end_point.Y - rad, 2*rad, 2*rad);
            g.DrawLine(pen, start_point, move_point);

        }

        void math_func()
        {
            if (Math.Pow((move_point.X - end_point.X), 2) + Math.Pow((move_point.Y - end_point.Y), 2) < Math.Pow(rad, 2))
            {
                StreamWriter f = new StreamWriter("result.txt", true);
                f.WriteLine(n.ToString() + "  " + rad.ToString());
                f.Close();
                n = 2;
                rad++;
                angle = Atan(Math.Abs(end_point.Y - start_point.Y) / Math.Abs(end_point.X - start_point.X), n);
                move_point = start_point;
                distance = (float)Math.Pow(this.Width * 2 + this.Height * 2, 2);
                return;
            }

            double new_distance = Math.Pow((end_point.X - move_point.X), 2) + Math.Pow((end_point.Y - move_point.Y), 2);
            if (new_distance < distance)
            {
                distance = new_distance;
            }
            else
            {
                n++;
                move_point = start_point;
                angle = Atan(Math.Abs(end_point.Y - start_point.Y) / Math.Abs(end_point.X - start_point.X), n);
                distance = (float)Math.Pow(this.Width * 2 + this.Height * 2, 2);
                return;
            }
            move_point.X += step * Cos(angle, n);
            move_point.Y += step * Sin(angle, n);
        }

        double Fact(int n)
        {
            if (n <= 1) return 1;
            else return n * Fact(n - 1);
        }
        float Sin(double x, int n)
        {
            double answer = 0;
            for (int i = 1; i < n + 1; i++)
            {
                answer += ((Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1)) / Fact(2 * i - 1));
            }
            return (float)answer;
        }

        float Cos(double x, int n)
        {
            double answer = 0;
            for (int i = 1; i < n + 1; i++)
            {
                answer += ((Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 2)) / Fact(2 * i - 2));
            }
            return (float)answer;
        }

        float Atan(double x, int n)
        {
            double answer = 0;
            for (int i = 1; i < n + 1; i++)
            {
                answer += ((Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1)) / (2 * i - 1));
            }
            return (float)answer;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
