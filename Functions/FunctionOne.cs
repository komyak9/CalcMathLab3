using System;

namespace Lab_3
{
    internal class FunctionOne : Function
    {
        public FunctionOne() => breakPointType = BreakPointType.RepairableGap;

        public override double CalculateSecondDerivative(double x) => ((Math.Pow(x, 2) - 2) * Math.Sin(x) + 2 * x * Math.Cos(x)) / Math.Pow(x, 3);

        public override double CalculateValue(double x) => Math.Sin(x) / x;

        public override bool IsFeasibleArea(double a, double b) => true;

        public override bool IsBreakPoint(double x) => x == 0;

        public override string ToString() => "y = sin(x) / x";
    }
}
