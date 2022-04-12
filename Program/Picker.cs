using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_3
{
    internal class Picker
    {
        private readonly List<Function> functions = new List<Function>
            {
                new FunctionOne(), new FunctionTwo(), new FunctionThree(), new FunctionFour()
            };

        public Function PickEquation()
        {
            Console.WriteLine("Please, select function: ");
            for (int i = 0; i < functions.Count(); i++)
            {
                Console.WriteLine($"\t{i + 1}: {functions[i]}");
            }
            Console.Write("Your choice: ");

            return functions[int.Parse(Console.ReadLine()) - 1];
        }

        public double PickA()
        {
            Console.Write("Please, input a: ");

            return double.Parse(Console.ReadLine());
        }

        public double PickB()
        {
            Console.Write("Please, input b: ");

            return double.Parse(Console.ReadLine());
        }

        public uint PickN()
        {
            Console.Write("Please, input n: ");

            return uint.Parse(Console.ReadLine());
        }
    }
}
