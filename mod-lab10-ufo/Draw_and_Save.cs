using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScottPlot;
using ScottPlot.Colormaps;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using ScottPlot.DataSources;

namespace mod_lab10_ufo
{
    public class Draw_and_Save
    {
        public static void StartPoint_and_Last_DrawArc(Graphics g, int X_start, int Y_start, int X_end, int Y_end, int Radius)
        {
            g.FillEllipse(new SolidBrush(System.Drawing.Color.Blue), X_start - 10, Y_start - 10, 20, 20);

            // Создаем перо с черным цветом и толщиной 3 пикселя
            Pen blackPen = new Pen(System.Drawing.Color.Black, 4);

            // Координаты центра эллипса и его размеры
            float centerX = X_end; // X-координата центра
            float centerY = Y_end; // Y-координата центра
            float width = Radius * 2;   // Ширина эллипса
            float height = Radius * 2;  // Высота эллипса

            // Начальный угол и угол обзора для дуги
            float startAngle = 0; // Начальный угол в градусах
            float sweepAngle = 360; // Угол обзора в градусах

            // Рисуем дугу
            g.DrawArc(blackPen, centerX - width / 2, centerY - height / 2, width, height, startAngle, sweepAngle);
        }

        private static void Create_Plot(List<double> Radius_with_N, List<double> N_in_Radius)
        {
            Plot plot = new Plot();
            plot.Add.Scatter(Radius_with_N, N_in_Radius);
            plot.ShowLegend();
            plot.YLabel("Количество членов ряда");
            plot.XLabel("Радиус зоны попадания");
            plot.SavePng("../../../dia.png", 1280, 720);
        }

        public static void SAVE_GRAFICS_IMAGE(int X_start, int Y_start, int X_end, int Y_end)
        {
            List<double> Radius_with_N = new List<double>(); //Радиус
            List<double> N_in_Radius = new List<double>(); //Попали

            Checking_cycles(ref Radius_with_N, ref N_in_Radius, X_start, Y_start, X_end, Y_end);

            Create_Plot(Radius_with_N, N_in_Radius);
        }

        private static void Checking_cycles(ref List<double> Radius_with_N, ref List<double> N_in_Radius, int X_start, int Y_start, int X_end, int Y_end)
        {
            List<double> Radius_with_last_N = new List<double>();
            List<double> last_N_in_Radius = new List<double>();
            
            int N = 15;
            int R = 352;

            double STEP = 1;
            double angle = Counting_Functions.OWN_ARCTANG(X_start, Y_start, X_end, Y_end);

            for (double r = 10; r < R; r = r + 4.455)
            {
                int old_n = 0;

                double distant = Counting_Functions.OWN_DISTANT(X_start, Y_start, X_end, Y_end);
                double old_d = distant + 1;

                double X1 = X_start;
                double Y1 = Y_start;

                for (int n = 1; n < N; n++)
                {

                    if ((distant > r) && (old_d > distant))
                    {
                        if (old_d > distant)
                        {
                            old_d = distant;
                        }

                        X1 += STEP * Counting_Functions.OWN_COS(angle, n);
                        Y1 -= STEP * Counting_Functions.OWN_SIN(angle, n);

                        distant = Counting_Functions.OWN_DISTANT(X1, Y1, X_end, Y_end);

                        old_n = n;

                    }
                    else if ((r >= distant) && (old_d > distant))
                    {
                        Radius_with_last_N.Add((int)r);
                        last_N_in_Radius.Add(old_n + 1);
                        break;
                    }

                }
            }

            Radius_with_N = new List<double>(Radius_with_last_N);
            N_in_Radius = new List<double>(last_N_in_Radius);
        }
    }
}
