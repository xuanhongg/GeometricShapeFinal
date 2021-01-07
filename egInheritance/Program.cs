using System;

namespace egInheritance
{
    class Vehicle
    {
        public string brand = "Ford";
        public void honk()
        {
            Console.WriteLine("Tuut, tuut!");
        }
    }
    class Car : Vehicle //Derived class
    {
        public string modelName = "Mustang"; //Car field
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();
            myCar.honk();
            Console.WriteLine(myCar.brand + "" + myCar.modelName);
        }
    }
}
