using System;

namespace egInterface
{
    interface IAnimal
    {
        void animalSound(); //interface class doesnt have a body
    }
    class Pig: IAnimal
    {
        public void animalSound()
        {
            Console.WriteLine("The pig says: wee wee");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Pig myPig = new Pig();
            myPig.animalSound();
            
        }
    }
}
