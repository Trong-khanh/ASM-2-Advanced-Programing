using System;
using System.Runtime.InteropServices;

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
        }
    }
}