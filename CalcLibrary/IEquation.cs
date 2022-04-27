
using System;

namespace CalcLibrary
{
    public interface IEquation 
    {
        double GetGradient();

        double GetYValue(double xValue);
    }

}