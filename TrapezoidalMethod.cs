using System;

namespace Lab_3
{
    internal class TrapezoidalMethod
    {
        private readonly double accuracy = 0.0001;

        public double CalculateIntegral(Function function, double a, double b, uint n, out double error)
        {
            if (!function.IsFeasibleArea(a, b) && function.BreakPoint != BreakPointType.RepairableGap)
                throw new Exception($"Impossible to calculate. [{a}, {b}] of {function} contains non-feasible area.");

            double result = 0;
            double h = (b - a) / n;
            double x0, x1 = a;

            for (int i = 1; i <= n; i++)
            {
                x0 = x1;
                x1 = x0 + h;
                if (function.IsBreakPoint(x0))
                {
                    x0 = CalculateNewX(function, x0);
                }
                else if (function.IsBreakPoint(x1))
                {
                    x1 = CalculateNewX(function, x1);
                }
                result += (function.CalculateValue(x0) + function.CalculateValue(x1)) * (x1 - x0) / 2;
            }
            error = Math.Abs(function.CalculateSecondDerivative(MaxFunctionValue(function, a, b))) * Math.Pow(b - a, 3) / (12 * Math.Pow(n, 2));

            return result;
        }

        private double MaxFunctionValue(Function function, double a, double b)
        {
            double max = function.CalculateSecondDerivative(a);
            double value;
            do
            {
                a += accuracy;
                value = function.CalculateSecondDerivative(a);
                if (value > max)
                    max = a;
            } while (a <= b);

            return max;
        }

        private double CalculateNewX(Function function, double x) => (function.CalculateValue(x + accuracy) + function.CalculateValue(x - accuracy)) / 2;
    }
}
