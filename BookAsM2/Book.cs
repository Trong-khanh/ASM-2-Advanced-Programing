using System;

namespace BookAsM2
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }

        public void InputInfo()
        {
            Console.WriteLine("Enter book information.");
            Console.Write("Book title: ");
            Title = Console.ReadLine();
            Console.Write("Author name: ");
            Author = Console.ReadLine();
            Console.Write("Category name: ");
            Category = Console.ReadLine();
            Console.Write("Quantity: ");
            Quantity = int.Parse(Console.ReadLine());
            while (Quantity < 0)
            {
                Console.WriteLine("Invalid quantity value, please enter another.");
                Quantity = int.Parse(Console.ReadLine());
            }
        }

        public override string ToString()
        {
            return $"Book ID: {BookId}, Title: {Title}, Author: {Author}, Category: {Category}, Quantity: {Quantity}";
        }

        public void ShowBookOnBorrow()
        {
            Console.WriteLine($"Book on loan: ID {BookId}, Title: {Title}, Author, {Author}, Category: {Category}");
        }
    }
}