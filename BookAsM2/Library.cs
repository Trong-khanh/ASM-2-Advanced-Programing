using System;
using System.Collections.Generic;
using System.Linq;

namespace BookAsM2
{
    public class Library
    {
        public string LibraryName { get; set; }
        public List<Book> Books = new List<Book>();
        public List<Borrowbooks> BorrowbooksList = new List<Borrowbooks>();
        public List<Student> StudentsBorrows = new List<Student>();

        public Library(string libraryName)
        {
            LibraryName = libraryName;
        }



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

        public void ShowListBook()
        {
            if (Books.Any())
            {
                Console.WriteLine("List books is available: ");
                foreach (Book book in Books)
                    Console.WriteLine((book.ToString()));
            }
            else
                Console.WriteLine("There are no books available.");
        }

        public void ShowBookList(List<Book> books)
        {
            foreach (Book book in books)
            {
                Console.WriteLine(book.ToString());
            }
        }

        //check the existence of a book and a student in its list.
        private bool IsBookExistend(int checkId)
        {
            Book bookInlist = Books.FirstOrDefault(b => b.BoookId == checkId);
            if (bookInlist == null)
                return false;
            return true;
        }

        private bool IsStudentExistend(string checkId)
        {
            Student studentInList = StudentsBorrows.FirstOrDefault
                (b => b.StudentId.Equals(checkId));
            if (studentInList == null)
                return false;
            return true;
        }

        //update or delete information of book
        private void UpdateBook(Book bookToUpdate)
        {
            bookToUpdate.InputInformation();
            Console.WriteLine("Update successfully");
        }

        private void DeleteBook(Book bookToDelete)
        {
            Books.Remove(bookToDelete);
            Console.WriteLine("Delete successfully");
        }
    }
}