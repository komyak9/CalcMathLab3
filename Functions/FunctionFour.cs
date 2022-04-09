using System;

namespace Lab_3
{
    internal class FunctionFour : Function
    {
        public FunctionFour() => breakPointType = BreakPointType.Infinity;

        public override double CalculateSecondDerivative(double x) => 2 / Math.Pow(x, 3);

        public override double CalculateValue(double x) => 1 / x;

        public override bool IsBreakPoint(double x) => x == 0;

        public override bool IsFeasibleArea(double a, double b) => a * b > 0;

        public override string ToString() => "y = 1 / x";
    }
}
