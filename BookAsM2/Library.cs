using System;
using System.Collections.Generic;

namespace BookAsM2
{
    public class Library
    {
        public string LibraryName { get; set; }
        public List<Book> Books = new List<Book>();
        public List<Student> Students = new List<Student>();
        public List<Borrowbooks> BorrowbooksList = new List<Borrowbooks>();
        public Library(string libraryName) => LibraryName = libraryName;

        //display menus of library.
        public void ShowMenu()
        {
            Console.WriteLine("1. View current book list ");
            Console.WriteLine("2. Add a new book title.");
            Console.WriteLine("3. Search book by title.");
            Console.WriteLine("4. Update/delete a book name  by id. ");
            Console.WriteLine("5. Lend a book to student.");
            Console.WriteLine("6. Receive a borrowed book from a student.");
            Console.WriteLine("7. Update information borrowers");
            Console.WriteLine("8. View list of book borrows");
            Console.WriteLine("9. Find student who borrows books the most often ");
            Console.WriteLine("10. exit the program ");
            Console.WriteLine("Enter your choose");
        }
    }
}