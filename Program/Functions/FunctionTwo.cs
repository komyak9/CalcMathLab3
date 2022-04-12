using System;

namespace Lab_3
{
    internal class FunctionTwo : Function
    {
        public FunctionTwo() => breakPointType = BreakPointType.NoGap;

        public override double CalculateSecondDerivative(double x) => -1 / (4 * Math.Pow(x, 3 / 2));

        public override double CalculateValue(double x) => Math.Sqrt(x);

        public override bool IsBreakPoint(double x) => false;

        public override bool IsFeasibleArea(double a, double b) => a >= 0 && b >= 0;

        public override string ToString() => "y = sqrt(x)";
    }
}
