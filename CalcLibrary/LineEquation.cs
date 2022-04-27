using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary
{
    public class LineEquation : IEquation
    {
        private double GradientM;
        private Point StartPoint;
        public LineEquation(Point start, Point end)
        {
            GradientM = (end.Y - start.Y) / (end.X - start.X);
            StartPoint = start;
        }

        public double GetGradient()
        {
            return GradientM;
        }

        public double GetYValue(double xValue)
        {
            // Straight line equation
            return GradientM * (xValue - StartPoint.X) + StartPoint.Y;
        }
    }
}
