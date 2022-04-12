using System;

namespace Lab_3
{
    internal class TrapezoidalMethod
    {
        private readonly double accuracy = 0.0001;
        private string breakPointRepairMessage;

        public double CalculateIntegral(Function function, double a, double b, uint n, out double error)
        {
            breakPointRepairMessage = "No repair.";
            if (!function.IsFeasibleArea(a, b) && function.BreakPoint != BreakPointType.RepairableGap)
                throw new Exception($"Impossible to calculate. [{a}, {b}] of {function} contains non-feasible area.");
            else if (!function.IsFeasibleArea(a, b) && function.BreakPoint == BreakPointType.RepairableGap)
                breakPointRepairMessage = "Break point repair was made during the calculation. It was a repairable gap.";

            double result = 0;
            double h = (b - a) / n;
            double x0, x1 = a;
            double y0 = 0, y1 = 0;

            for (int i = 1; i <= n; i++)
            {
                x0 = x1;
                x1 = x0 + h;

                y0 = function.CalculateValue(x0);
                y1 = function.CalculateValue(x1);

                if (function.IsBreakPoint(x0))
                    y0 = CalculateNewY(function, x0);
                else if (function.IsBreakPoint(x1))
                    y1 = CalculateNewY(function, x1);

                result += (y0 + y1) * (x1 - x0) / 2;
            }
            if (a == 0)
                a += accuracy;
            if (b == 0)
                b -= accuracy;
            error = Math.Abs(function.CalculateSecondDerivative(MaxFunctionValue(function, a, b))) * Math.Pow(b - a, 3) / (12 * Math.Pow(n, 2));

            return result;
        }

        private double MaxFunctionValue(Function function, double a, double b)
        {
            double maxY = function.CalculateSecondDerivative(a);
            double maxX = a;
            double value;
            do
            {
                value = function.CalculateSecondDerivative(a);
                if (value > maxY)
                {
                    maxY = value;
                    maxX = a;
                }
                a += accuracy;
            } while (a <= b);

            return maxX;
        }

        private double CalculateNewY(Function function, double x)
        {
            return (function.CalculateValue(x + accuracy) + function.CalculateValue(x - accuracy)) / 2;
        }

        public string BreakPointRepairMessage
        {
            get { return breakPointRepairMessage; }
        }

    }
}
