using System;

namespace Lab_3
{
    internal class FunctionThree : Function
    {
        public FunctionThree() => breakPointType = BreakPointType.Jump;

        public override double CalculateSecondDerivative(double x) => 0;

        public override double CalculateValue(double x) => Math.Sign(x);

        public override bool IsBreakPoint(double x) => x == 0;

        public override bool IsFeasibleArea(double a, double b) => a * b > 0;

        public override string ToString() => "y = sign(x)";
    }
}
