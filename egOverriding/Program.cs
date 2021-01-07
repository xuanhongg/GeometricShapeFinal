using System;

namespace egOverriding
{
    class Animal
    {
        public void animalSound()
        {
            Console.WriteLine("The animal makes a sound");
        }
        public string Name { get; set; }   
        public void Drink();
        public virtual void Eat();
        public void Go();
    }
    class Pig: Animal
    {
        public void animalSound()
        {
            Console.WriteLine("The pig says: wee wee");
        }
        public new string Name { get; set; }
        public void Drink();  
        public override void   Eat();    
        public new void Go();     
    }
    class Dog: Animal
    {
        public void animalSound()
        {
            Console.WriteLine("The dog says: bow bow");
        }
        public new string Name { get; set; }
        public void Drink();  
        public override void   Eat();    
        public new void Go();     
    }
    class Program
    {
        static void Main(string[] args)
        {
            Animal myAnimal = new Animal();
            Animal myPig = new Pig();
            Pig myPig1 = new Pig();
            myAnimal.animalSound();
            myPig.animalSound();
            myPig1.animalSound();
        }
    }
}
