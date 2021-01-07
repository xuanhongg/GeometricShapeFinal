using System;

namespace egNestedClass
{
    public class Outer_class
    {
        public int number = 20;
        public Inner_class Inner {get; set;}
        public Outer_class()
        {
            this.Inner = Inner_class(this);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
