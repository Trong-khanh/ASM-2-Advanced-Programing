using System;
using System.Collections.Generic;
using System.Linq;

namespace BookAsM2
{
    public class Library
    {
        public List<Book> Books = new List<Book>();
        public List<Borrowbooks> BorrowbooksList = new List<Borrowbooks>();
        public List<Student> Students = new List<Student>();

        public Library(string libraryName)
        {
            LibraryName = libraryName;
        }

        public string LibraryName { get; set; }

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

        public void addBook()
        {
            try
            {
                var newBook = new Book();
                if (Books.Any())
                    newBook.BoookId = Books.Last().BoookId + 1;
                else newBook.BoookId = 1;
                newBook.InputInformation();
                Books.Add(newBook);
                Console.WriteLine("Add successfully!!");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Please enter number .\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
        }
    }
}