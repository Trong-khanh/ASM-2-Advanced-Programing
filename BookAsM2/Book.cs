using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace BookAsM2
{
    public class Book
    {
        public int BoookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }

        public void InputInformation()
        {
            Console.WriteLine("Enter information");
            Console.Write("Title");
            Title = Console.ReadLine();
            Console.WriteLine("Name Author");
            Author = Console.ReadLine();
            Console.WriteLine("Category");
            Category = Console.ReadLine();
            Console.WriteLine("Quantity");
            Quantity = int.Parse(Console.ReadLine());
            while (Quantity < 0)
            {
                Console.WriteLine("Quantity must be greater than 0");
                Quantity = int.Parse(Console.ReadLine());
            }
        }

        public override string ToString()
        {
            return $"BookId : {BoookId}, Title: {Title}," +
                   $" Author: {Author}, Category: {Category}, Quantity: {Quantity}";
        }

        public void ShowBook()
        {
            Console.WriteLine($"Book : Id {BoookId}, Title: {Title}, Author: {Author}, Category: {Category}");
        }
    }
}