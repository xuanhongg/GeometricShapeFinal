using System;

namespace egPartialClass
{
    public class Article
    {
        private string Author_name;
        private int Total_articles;
        public Article (string a, int t)
        {
            this.Author_name = a;
            this.Total_articles = t;
        }
        public void Display()
        {
            Console.WriteLine("Author is " + Author_name);
            Console.WriteLine("Total number articles is " + Total_articles);
        }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            Article newAuthor = new Article("Pink", 2);
            newAuthor.Display();
        }
    }
}
