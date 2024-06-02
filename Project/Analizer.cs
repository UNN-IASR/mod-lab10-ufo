using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;
using ScottPlot;

namespace Project
{
    internal class Analizer
    {
        public PointF P_start { get; }
        public PointF P_end { get; }
        public int Start_n { get; }
        public int End_n { get; }
        public int Count_steps { get; }
        public List<double> Vicinity_list { get; private set; }

        public Analizer(PointF p_start, PointF p_end, int start_n, int end_n, int count_steps)
        {
            P_start = p_start;
            P_end = p_end;
            Start_n = start_n;
            End_n = end_n;
            Count_steps = count_steps;

            Vicinity_list = new List<double>();

            Start();
        }

        private void Start()
        {
            int directionX = P_start.X < P_end.X ? 1 : -1;
            int directionY = P_start.Y < P_end.Y ? 1 : -1;

            double step = Step(P_start, P_end, Count_steps);

            for (int i = Start_n; i <= End_n; i++)
            {
                PointF p_start = P_start;
                PointF p_end = P_end;

                double angl = MathTrigonometry.Atan(Math.Abs(p_start.Y - p_end.Y) / Math.Abs(p_start.X - p_end.X), i);
                double dist = Distance(p_start, p_end);

                for (int j = 0; j < Count_steps; j++)
                {
                    p_start.X += (float)(directionX * step * MathTrigonometry.Cos(angl, i));
                    p_start.Y += (float)(directionY * step * MathTrigonometry.Sin(angl, i));

                    dist = Distance(p_start, p_end);
                }

                Vicinity_list.Add(dist);
            }

            CreateChart(Start_n, End_n, Vicinity_list);
        }

        private void CreateChart(int start_n, int end_n, List<double> vicinity_list)
        {
            string path = "";

            double[] ints = new double[end_n - start_n + 1];
            int addI = start_n;
            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = addI;
                addI++;
            }

            Plot plt = new Plot();
            plt.AddScatter(ints, vicinity_list.ToArray());

            plt.SaveFig(path + "firstImg.png");
        }

        private float Distance(PointF p1, PointF p2)
        {
            return (float)Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        private double Step(PointF p_start, PointF p_end, int countSteps)
        {
            float dist = Distance(p_start, p_end);
            return dist / countSteps;
        }
    }
}
