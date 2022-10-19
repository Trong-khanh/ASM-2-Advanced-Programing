using System;

namespace BookAsM2
{
    public class Book
    {
        public int BoookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }

        public void InputInformation()
        {
            Console.WriteLine("Enter information");
            Console.Write("Name");
            Name = Console.ReadLine();
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
            return $"BookId : {BoookId}, Name: {Name}," +
                   $" Author: {Author}, Category: {Category}, Quantity: {Quantity}";
        }

        public void ShowBookBorrow()
        {
            Console.WriteLine($"Book : Id {BoookId}, Name: {Name}" +
                              $", Author: {Author}, Category: {Category}");
        }
    }
}