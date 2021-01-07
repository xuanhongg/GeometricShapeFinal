using System;

namespace egOverloading
{
    class Program
    {
        static double PlusMethod(double x, double y)
        {
            return x + y;
        }
        static double SubtractMethod(double x, double y)
        {
            return x - y;
        }
        static double MultiMethod(double x, double y)
        {
            return x * y;
        }
        static double DivideMethod(double x, double y)
        {
            return x/y;
        }

        static void Main(string[] args)
        {
            double myNum1 = PlusMethod(4.3, 4.5);
            double myNum2 = SubtractMethod(4.3, 4.5);
            double myNum3 = MultiMethod(4.3, 4.5);
            double myNum4 = DivideMethod(4.3, 4.5);
            Console.WriteLine("Sum: " + myNum1);
            Console.WriteLine("Subtraction: " + myNum2);
            Console.WriteLine("Multiplication: " + myNum3);
            Console.WriteLine("Division: " + myNum4);

        }
    }
}
