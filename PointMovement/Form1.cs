using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointMovement
{
  public partial class MainForm : Form
  {
    private Thread thread;
    public MainForm()
    {
      InitializeComponent();
      Value.Enabled = false;
      Precision.Enabled = false;
    }

    public void WithAngle(object obj)
    {
      int[] arr = obj as int[];
      int x2 = arr[0], y2 = arr[1], value = arr[2], precision = arr[3];
      int x1 = 0, y1 = 0;
      double x = 0, y = 0;
      int step = 5;

      Pen pen = new Pen(Color.Black, 2);
      Pen pen2 = new Pen(Color.Red, 5);
      Pen pen3 = new Pen(Color.Blue, 5);


      double angle = Math.Atan(Math.Abs(y2 - y1) / (double)Math.Abs(x2 - x1)) * 180 / Math.PI;
      double distance = Math.Sqrt(Math.Pow(y2 - y1, 2) + Math.Pow(x2 - x1, 2));
      double sin = Sin(angle, precision);
      double cos = Cos(angle, precision);

      Graphics graphics = CreateGraphics();
      graphics.TranslateTransform(Width / 2 + 20, Height / 2 - 10);
      graphics.ScaleTransform(0.5f, 0.5f);
      graphics.DrawEllipse(pen3, x2 - value / 2, y2 - value / 2, value * 2, value * 2);

      while (distance > value)
      {
        Thread.Sleep(50);
        x += step * cos;
        y += step * sin;
        graphics.DrawLine(pen, new Point(x1, y1), new Point(x2, y2));
        graphics.DrawEllipse(pen2, new Rectangle((int)x, (int)y, 1, 1));
        double previousDistance = distance;
        distance = Math.Sqrt(Math.Pow(y2 - y, 2) + Math.Pow(x2 - x, 2));

        if (previousDistance < distance)
        {
          MessageBox.Show("Промах!");
          return;
        }
      }
      MessageBox.Show("Попадание!");
    }

    public void LineEquation(object obj)
    {
      int[] arr = obj as int[];
      int x1 = 0, y1 = 0;
      int x2 = arr[0], y2 = arr[1];
      double k = ((double)(y2 - y1)) / (x2 - x1);
      double b = y1 - k * x1;

      Graphics graphics = CreateGraphics();
      Pen pen = new Pen(Color.Black, 2);
      Pen pen2 = new Pen(Color.Red, 5);
      graphics.TranslateTransform(Width / 2 + 20, Height / 2 - 10);

      for (int x = x1; x <= x2; ++x)
      {
        Thread.Sleep(30);
        graphics.DrawLine(pen, new Point(x1, y1), new Point(x2, y2));
        graphics.DrawEllipse(pen2, new RectangleF(x, (float)(k*x + b), 1, 1));
        graphics.FillEllipse(new SolidBrush(Color.Red), new RectangleF(x, (float)(k * x + b), 1, 1));
      }
    }

    private double Sin(double angle, int precision)
    {
      double sin = 0;
      for (int i = 0; i < precision; ++i)
      {
        int factorial = 1;
        for (int j = 0; j < 2 * (i + 1); ++j)
        {
          if (i == 0) break;
          factorial *= (j + 1);
        }

        if (i % 2 == 0)
        {
          sin += Math.Pow(angle / 180 * Math.PI, 2 * i + 1) / factorial;
        }
        else
        {
          sin -= Math.Pow(angle / 180 * Math.PI, 2 * i + 1) / factorial;
        }
      }
      return sin;
    }

    private double Cos(double angle, int precision)
    {
      double cos = 0;
      for (int i = 0; i < precision; ++i)
      {
        int factorial = 1;
        for (int j = 0; j < 2 * i; ++j)
        {
          factorial *= (j + 1);
        }

        if (i % 2 == 0)
        {
          cos += Math.Pow(angle / 180 * Math.PI, 2 * i) / factorial;
        }
        else
        {
          cos -= Math.Pow(angle / 180 * Math.PI, 2 * i) / factorial;
        }
      }
      return cos;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (x2.Text== "" || y2.Text == "" || Value.Text == "" || Precision.Text == "")
      {
        MessageBox.Show("Нерпавильно введены данные");
        return;
      }

      if (!AngleRB.Checked)
      {
        thread = new Thread(LineEquation);
        thread.Start(new int[] { Int32.Parse(x2.Text), Int32.Parse(y2.Text) });
      }
      else
      {
        thread = new Thread(WithAngle);
        thread.Start(new int[] { Int32.Parse(x2.Text), Int32.Parse(y2.Text),
                                 Int32.Parse(Value.Text), Int32.Parse(Precision.Text) });
      }
    }


    private void x2_KeyPress(object sender, KeyPressEventArgs e)
    {
      char number = e.KeyChar;

      if (!Char.IsDigit(number))
      {
        e.Handled = true;
      }
    }

    private void y2_KeyPress(object sender, KeyPressEventArgs e)
    {
      char number = e.KeyChar;

      if (!Char.IsDigit(number))
      {
        e.Handled = true;
      }
    }

    private void AngleRB_CheckedChanged(object sender, EventArgs e)
    {
      if (AngleRB.Checked)
      {
        Value.Enabled = true;
        Precision.Enabled = true;
      }
      else
      {
        Value.Enabled = false;
        Precision.Enabled = false;
      }
    }

    private void Precision_KeyPress(object sender, KeyPressEventArgs e)
    {
      char number = e.KeyChar;

      if (!Char.IsDigit(number))
      {
        e.Handled = true;
      }
    }

    private void Value_KeyPress(object sender, KeyPressEventArgs e)
    {
      char number = e.KeyChar;

      if (!Char.IsDigit(number))
      {
        e.Handled = true;
      }
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (thread != null)
      {
        thread.Join();
      }
    }
  }
}
