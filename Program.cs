using System;

namespace Lab_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TrapezoidalMethod trapezoidalMethod = new TrapezoidalMethod();
            Picker picker = new Picker();
            double result;
            double error;

            while (true)
            {
                try
                {
                    result = trapezoidalMethod.CalculateIntegral(picker.PickEquation(), picker.PickA(), picker.PickB(), picker.PickN(), out error);
                    Console.WriteLine($"\nIntegral value: {result}");
                    Console.WriteLine($"Error: δ <= {error}");
                    Console.WriteLine($"Repair: {trapezoidalMethod.BreakPointRepairMessage}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                Console.Write("\nContinue? 'yes'/'no': ");
                if (Console.ReadLine() != "yes")
                    break;
            }

        }
    }
}
