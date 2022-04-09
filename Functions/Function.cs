namespace Lab_3
{
    internal abstract class Function
    {
        protected BreakPointType breakPointType;

        public abstract double CalculateValue(double x);

        public abstract double CalculateSecondDerivative(double x);

        public abstract bool IsFeasibleArea(double a, double b);

        public abstract bool IsBreakPoint(double x);

        public BreakPointType BreakPoint
        {
            get { return breakPointType; }
        }


    }
}
