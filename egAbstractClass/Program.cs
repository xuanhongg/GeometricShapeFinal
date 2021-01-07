using System;

namespace egAbstractClass
{
    abstract class Animal
    {
        public abstract void animalSound();
        public void sleep()
        {
            Console.WriteLine("Zzz");
        }
    }
    class Pig: Animal
    {
        public override void animalSound()
        {
            Console.WriteLine("The Pig says: wee wee");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Pig myPig = new Pig(); //Create a Pig object
            myPig.animalSound();
            myPig.sleep();
        }
    }
}
