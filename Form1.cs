using System.Numerics;

namespace lab10
{
    public partial class Form1 : Form
    {
        private readonly IterativeLineDrawer _drawer;

        public Form1()
        {
            InitializeComponent();

            _drawer = new IterativeLineDrawer(
                new SystemParameters
                {
                    StartPoint = new PointD
                    {
                        X = (double)StartPointXInput.Value,
                        Y = (double)StartPointYInput.Value
                    },
                    EndPoint = new PointD
                    {
                        X = (double)EndPointXInput.Value,
                        Y = (double)EndPointYInput.Value
                    },
                    Step = (double)StepInput.Value
                },
                (uint)PrecisionInput.Value,
                (double)EpsilonInput.Value,
                1500
            );

            Timer.Enabled = false;
        }

        private void SimulationPanel_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.ScaleTransform(2, 2);

            graphics.FillEllipse(Brushes.ForestGreen, CenteredRectangle(_drawer.Parameters.StartPoint.ToPointF(), 4, 4));
            graphics.FillEllipse(Brushes.DarkSlateGray, CenteredRectangle(_drawer.CurrentPoint.ToPointF(), 4, 4));

            var radiusBrush = new SolidBrush(Color.FromArgb(50, Color.OrangeRed));
            graphics.FillEllipse(radiusBrush, CenteredRectangle(_drawer.Parameters.EndPoint.ToPointF(), (float)_drawer.Epsilon, (float)_drawer.Epsilon));
            graphics.FillEllipse(Brushes.OrangeRed, CenteredRectangle(_drawer.Parameters.EndPoint.ToPointF(), 4, 4));
        }

        private static RectangleF CenteredRectangle(PointF center, float width, float height)
        {
            var topLeft = new PointF(center.X - width / 2, center.Y - height / 2);
            return new RectangleF(topLeft, new SizeF(width, height));
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var status = _drawer.Next();

            Timer.Enabled = status switch
            {
                DrawingStatus.InNeighbourhood => false,
                DrawingStatus.OutOfReact => false,
                DrawingStatus.Continue => true,
                _ => throw new ArgumentOutOfRangeException()
            };

            SimulationPanel.Invalidate();
        }

        private void StartSimulationButton_Click(object sender, EventArgs e)
        {
            _drawer.InitializeState();
            Timer.Enabled = true;

            StartSimulationButton.Enabled = false;
            StartPointXInput.Enabled = false;
            StartPointYInput.Enabled = false;
            EndPointXInput.Enabled = false;
            EndPointYInput.Enabled = false;
            PrecisionInput.Enabled = false;
            EpsilonInput.Enabled = false;
            StepInput.Enabled = false;
        }

        private void StartAnalysisButton_Click(object sender, EventArgs e)
        {
            var precisions = Enumerable
                .Range(2, 99)
                .Select(Convert.ToUInt32)
                .ToArray();

            var results = Analyzer.AnalyzeEpsilonAndPrecisionConnection(
                _drawer.Parameters,
                precisions
            );

            ScottPlot.Plot plot = new();
            plot.Add.Scatter(precisions.Select(Convert.ToDouble).ToArray(), results.ToArray());
            plot.Title("Зависимость между точностью расчётов и радиусом зоны попадания в конечную точку");
            plot.XLabel("Число членов суммы в формулах");
            plot.YLabel("Достаточный радиус зоны попадания");

            plot.SavePng("dia.png", 400, 300);

            MessageBox.Show(
                "Исследование проведено! Файл сохранён",
                "Исследование",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            Timer.Enabled = false;

            StartSimulationButton.Enabled = true;
            StartPointXInput.Enabled = true;
            StartPointYInput.Enabled = true;
            EndPointXInput.Enabled = true;
            EndPointYInput.Enabled = true;
            PrecisionInput.Enabled = true;
            EpsilonInput.Enabled = true;
            StepInput.Enabled = true;
        }

        private void StartPointXInput_ValueChanged(object sender, EventArgs e)
        {
            _drawer.Parameters.StartPoint.X = (double)StartPointXInput.Value;
            SimulationPanel.Invalidate();
        }

        private void StartPointYInput_ValueChanged(object sender, EventArgs e)
        {
            _drawer.Parameters.StartPoint.Y = (double)StartPointYInput.Value;
            SimulationPanel.Invalidate();
        }

        private void EndPointXInput_ValueChanged(object sender, EventArgs e)
        {
            _drawer.Parameters.EndPoint.X = (double)EndPointXInput.Value;
            SimulationPanel.Invalidate();
        }

        private void EndPointYInput_ValueChanged(object sender, EventArgs e)
        {
            _drawer.Parameters.EndPoint.Y = (double)EndPointYInput.Value;
            SimulationPanel.Invalidate();
        }

        private void EpsilonInput_ValueChanged(object sender, EventArgs e)
        {
            _drawer.Epsilon = (double)EpsilonInput.Value;
            SimulationPanel.Invalidate();
        }

        private void PrecisionInput_ValueChanged(object sender, EventArgs e)
        {
            _drawer.Precision = (uint)PrecisionInput.Value;
        }

        private void StepInput_ValueChanged(object sender, EventArgs e)
        {
            _drawer.Parameters.Step = (double)StepInput.Value;
        }
    }
}

public static class Analyzer
{
    public static IEnumerable<double> AnalyzeEpsilonAndPrecisionConnection(
        SystemParameters parameters,
        IEnumerable<uint> precisionSamples
    ) => precisionSamples.Select(precision => FindBestFittingEpsilon(parameters, precision));

    private static double FindBestFittingEpsilon(SystemParameters parameters, uint precision)
    {
        var upperBound = 75.0;
        var lowerBound = 0.001;

        for (var i = 0; ; i++)
        {
            var epsilon = (upperBound + lowerBound) / 2;
            var drawer = new IterativeLineDrawer(parameters, precision, epsilon, 1000);

            Console.WriteLine(epsilon);

            switch (IsReachingEndPoint(drawer), i >= 15)
            {
                case (true, true):
                    return epsilon;
                case (true, false):
                    upperBound = epsilon;
                    break;
                default:
                    lowerBound = epsilon;
                    break;
            }
        }
    }

    private static bool IsReachingEndPoint(IterativeLineDrawer drawer)
    {
        drawer.InitializeState();

        while (true)
        {
            var status = drawer.Next();

            if (status is DrawingStatus.InNeighbourhood)
                return true;

            if (status is DrawingStatus.OutOfReact)
                return false;
        }
    }
}

public abstract record DrawingStatus
{
    private DrawingStatus() { }

    public record Continue(PointD Next) : DrawingStatus;

    public record OutOfReact : DrawingStatus;

    public record InNeighbourhood : DrawingStatus;
}

public sealed class IterativeLineDrawer
{
    public SystemParameters Parameters;
    public uint Precision;
    public double Epsilon;

    private double _angle;
    private PointD _currentPoint;
    private readonly double _outOfReachDistance;

    public PointD CurrentPoint => _currentPoint;

    public IterativeLineDrawer(
        SystemParameters parameters,
        uint precision,
        double epsilon,
        double outOfReachDistance)
    {
        Parameters = parameters;
        Precision = precision;
        Epsilon = epsilon;
        _outOfReachDistance = outOfReachDistance;

        InitializeState();
    }

    public DrawingStatus Next()
    {
        if (CurrentPointInNeighbourhood())
            return new DrawingStatus.InNeighbourhood();

        if (CurrentPointOutOfReach())
            return new DrawingStatus.OutOfReact();

        _currentPoint.X += Parameters.Step * TaylorSeriesFunctions.Cos(_angle, Precision);
        _currentPoint.Y -= Parameters.Step * TaylorSeriesFunctions.Sin(_angle, Precision);

        return new DrawingStatus.Continue(_currentPoint);
    }

    private double CalculateAngle() =>
        TaylorSeriesFunctions.Arctan((Parameters.StartPoint.Y - Parameters.EndPoint.Y) / (Parameters.EndPoint.X - Parameters.StartPoint.X), Precision);

    public void InitializeState()
    {
        _currentPoint = Parameters.StartPoint;
        _angle = CalculateAngle();
    }

    private static double Distance(PointD first, PointD second) =>
        Math.Sqrt(TaylorSeriesFunctions.Pow(first.X - second.X, 2) + TaylorSeriesFunctions.Pow(first.Y - second.Y, 2));

    private bool CurrentPointOutOfReach() =>
        Distance(_currentPoint, Parameters.EndPoint) >= _outOfReachDistance;

    private bool CurrentPointInNeighbourhood() =>
        Distance(_currentPoint, Parameters.EndPoint) <= Epsilon;
}

public record struct PointD(double X, double Y)
{
    public PointF ToPointF() => new((float)X, (float)Y);
}

public struct SystemParameters
{
    public PointD StartPoint;
    public PointD EndPoint;
    public double Step;
}

public static class TaylorSeriesFunctions
{
    public static double Sin(double x, uint n)
    {
        var sum = 0.0;
        var term = x;
        var xSquared = x * x;

        for (var i = 1u; i <= n; i++)
        {
            if (i != 1u)
            {
                term *= -xSquared;
                term /= (2 * i - 2) * (2 * i - 1);
            }

            sum += term;
        }

        return sum;
    }

    public static double Cos(double x, uint n)
    {
        var sum = 0.0;
        var term = 1.0;
        var xSquared = x * x;

        for (var i = 1u; i <= n; i++)
        {
            if (i != 1u)
            {
                term *= -xSquared;
                term /= (2 * i - 3) * (2 * i - 2);
            }

            sum += term;
        }

        return sum;
    }

    public static double Arctan(double x, uint n)
    {
        var sum = 0.0;
        var term = x;
        var xSquared = x * x;

        for (var i = 1u; i <= n; i++)
        {
            if (i != 1u)
            {
                term *= -xSquared * (2 * i - 3);
                term /= 2 * i - 1;
            }

            sum += term;
        }

        return sum;
    }

    public static T Pow<T>(T x, uint n) where T : INumber<T>
    {
        var value = T.One;

        for (var i = 1u; i <= n; i++)
        {
            value *= x;
        }

        return value;
    }
}