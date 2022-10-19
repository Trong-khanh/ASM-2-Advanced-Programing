using System;
using System.Collections.Generic;
using System.Linq;

namespace BookAsM2
{
    public class Library
    {
        public List<BookBorrow> BookLoans = new List<BookBorrow>();
        public List<Book> Books = new List<Book>();
        public List<Student> StudentBorrowers = new List<Student>();

        public Library(string libraryName)
        {
            LibraryName = libraryName;
        }

        public string LibraryName { get; set; }

        public void Hello()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"WELCOME TO {LibraryName.ToUpper()} LIBRARY!!!");
            Console.WriteLine("----------------------------------------------");
        }

        public void ShowMenu()
        {
            Console.WriteLine("1. View current book list.");
            Console.WriteLine("2. Add a new book title.");
            Console.WriteLine("3. Search books by title.");
            Console.WriteLine("4. Update/Delete a book title by ID.");
            Console.WriteLine("5. Lend a book to a student.");
            Console.WriteLine("6. Receive a borrowed book from a student.");
            Console.WriteLine("7. Update information of student borrowers.");
            Console.WriteLine("8. View list of book loans.");
            Console.WriteLine("9. Find the student who borrows books the most often.");
            Console.WriteLine("10. Exit the program.");
            Console.Write("Enter your option: ");
        }

        public void AddBook()
        {
            try
            {
                var newBook = new Book();
                if (Books.Any())
                    newBook.BookId = Books.Last().BookId + 1;
                else newBook.BookId = 1;
                newBook.InputInfo();
                Books.Add(newBook);
                Console.WriteLine("Added successfully!");
                Console.WriteLine("---------------------------");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Please enter a number.\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.Message);
            }
        }

        public void ShowBookList()
        {
            if (Books.Any())
            {
                Console.WriteLine("List of books available:");
                foreach (var book in Books)
                    Console.WriteLine(book.ToString());
            }
            else
            {
                Console.WriteLine("There are no books available.");
            }

            Console.WriteLine("***********************************");
        }

        public void ShowBookList(List<Book> books)
        {
            foreach (var book in books)
                Console.WriteLine(book.ToString());
        }
        
        public List<Book> SearchBooksByTitle()
        {
            Console.WriteLine("Enter book title to be looked up.");
            var searchKeyWord = Console.ReadLine();
            return Books.Where(b => b.Title.ToLower().Contains(searchKeyWord.ToLower())).ToList();
        }
        
        private Book FindBookById()
        {
            Console.Write("Enter book ID: ");
            var bookId = int.Parse(Console.ReadLine());
            var bookInList = Books.FirstOrDefault(b => b.BookId == bookId);
            while (bookId < 0 || bookInList == null || bookInList.Quantity == 0)
            {
                Console.WriteLine("This book does not exist or out of stock, please enter another book ID.");
                bookId = int.Parse(Console.ReadLine());
                bookInList = Books.FirstOrDefault(b => b.BookId == bookId);
            }

            return bookInList;
        }
        
        private bool IsBookExisted(int idToCheck)
        {
            var bookInList = Books.FirstOrDefault(b => b.BookId == idToCheck);
            if (bookInList == null)
                return false;
            return true;
        }
        
        private bool IsStudentExisted(string idToCheck)
        {
            var studentInList = StudentBorrowers.FirstOrDefault(b => b.StudentId.Equals(idToCheck));
            if (studentInList == null)
                return false;
            return true;
        }

        private void UpdateBook(Book bookToUpdate)
        {
            bookToUpdate.InputInfo();
            Console.WriteLine("Updated successfully!");
            Console.WriteLine("---------------------------");
        }
        
        private void DeleteBook(Book bookToDelete)
        {
            Books.Remove(bookToDelete);
            Console.WriteLine("Deleted successfully!");
            Console.WriteLine("---------------------------");
        }
        
        public void UpdateOrDeleteBook()
        {
            ShowBookList();
            Console.Write("Enter a book ID: ");
            var bookId = int.Parse(Console.ReadLine());
            while (!IsBookExisted(bookId))
            {
                Console.WriteLine("This book does not exist, please enter another ID.");
                bookId = int.Parse(Console.ReadLine());
            }

            var bookInList = Books.FirstOrDefault(b => b.BookId == bookId);
            Console.WriteLine(bookInList.ToString());
            Console.WriteLine("Type 'u' for update, 'd' for delete.");
            var choice = Console.ReadLine();
            while (!choice.Equals("u", StringComparison.InvariantCultureIgnoreCase)
                   && !choice.Equals("d", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Invalid command, please enter again.");
                choice = Console.ReadLine();
            }

            if (choice.Equals("u", StringComparison.InvariantCultureIgnoreCase))
                UpdateBook(bookInList);
            else DeleteBook(bookInList);
        }
        
    }
}