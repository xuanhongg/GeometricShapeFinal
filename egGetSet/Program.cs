using System;

namespace egGetSet
{
    class Person
    {
        private string name; //field
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Person myObj = new Person();
            myObj.Name = "Pink";
            Console.WriteLine(myObj.Name);
        }
    }
}
