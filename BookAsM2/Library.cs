using System;
using System.Collections.Generic;
using System.Linq;

namespace BookAsM2
{
    public class Library
    {
        public List<BookBorrow> BookBorrows = new List<BookBorrow>();
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

        public void LendBook()
        {
            if (!Books.Any())
            {
                Console.WriteLine("Currently there are no books to be lent to students");
            }
            else
            {
                Console.WriteLine("Enter information student");
                Console.WriteLine("Student Id: ");
                var studentId = Console.ReadLine();
                if (IsStudentExisted(studentId))
                {
                    Console.WriteLine("Data about this student is already available: ");
                    var studentInList = StudentBorrowers.FirstOrDefault(b => b.StudentId.Equals(studentId));
                    Console.WriteLine(studentInList.ToString());
                    if (studentInList.BookBorrows.Last().ReturnDate == DateTime.MinValue)
                    {
                        Console.WriteLine("This student has 1 unreturned book which has to be returned before" +
                                          $"{studentInList.BookBorrows.Last().DueDate.AddDays(1).ToString("dd/MM/yyyy")}");
                        studentInList.BookBorrows.Last().BookInBorrow.ShowBookOnBorrow();
                    }
                    else
                    {
                        try
                        {
                            var borrowBook = FindBookById();
                            Console.WriteLine(borrowBook.ToString());
                            borrowBook.Quantity--;
                            var newBookBorrow = new BookBorrow(studentInList, borrowBook);
                            newBookBorrow.BorrowId = BookBorrows.Last().BorrowId + 1;
                            newBookBorrow.InputIssueDate(studentInList);
                            BookBorrows.Add(newBookBorrow);
                            studentInList.BookBorrows.Add(newBookBorrow);
                            Console.WriteLine("The book has been successfully lent.");
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(" please enter a number.\n" + ex.Message);
                        }
                    }
                }
                else
                {
                    var newStudent = new Student(studentId);
                    newStudent.InputInfo();
                    try
                    {
                        StudentBorrowers.Add(newStudent);
                        var borrowBook = FindBookById();
                        Console.WriteLine(borrowBook.ToString());
                        borrowBook.Quantity--;
                        var newBorrowBook = new BookBorrow(newStudent, borrowBook);
                        if (BookBorrows.Any())
                            newBorrowBook.BorrowId = BookBorrows.Last().BorrowId + 1;
                        else newBorrowBook.BorrowId = 1;
                        newBorrowBook.InputIssueDate(newStudent);
                        BookBorrows.Add(newBorrowBook);
                        newStudent.BookBorrows.Add(newBorrowBook);
                        Console.WriteLine("The book has been successfully lent.");
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Please enter a number.\n" + ex.Message);
                        StudentBorrowers.Remove(newStudent);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error " + ex.Message);
                    }
                }
            }
        }

        public void ReceiveBook()
        {
            Console.WriteLine("Enter student information: ");
            Console.WriteLine("Student ID");
            var studentId = Console.ReadLine();
            var studentInList = StudentBorrowers.FirstOrDefault(b => b.StudentId.Equals(studentId));
            while (studentInList == null || studentInList.BookBorrows.Last().ReturnDate != DateTime.MinValue)
            {
                Console.Write(" This student has returned or not borrowed a book before.\n please enter other ID:");
                studentId = Console.ReadLine();
                studentInList = StudentBorrowers.FirstOrDefault(b => b.StudentId == studentId);
            }

            Console.WriteLine("This student has 1 unreturned book.");
            studentInList.BookBorrows.Last().ShowTimeLine();
            Console.WriteLine(studentInList.ToString());
            studentInList.BookBorrows.Last().InputReturnDate();
            studentInList.BookBorrows.Last().BookInBorrow.Quantity++;

            foreach (var br in BookBorrows)
                if (br.BorrowId == studentInList.BookBorrows.Last().BorrowId)
                {
                    br.ReturnDate = studentInList.BookBorrows.Last().ReturnDate;
                    br.BookInBorrow.Quantity = studentInList.BookBorrows.Last().BookInBorrow.Quantity;
                }

            foreach (var b in Books)
                if (b.BookId == studentInList.BookBorrows.Last().BorrowId)
                    b.Quantity = studentInList.BookBorrows.Last().BookInBorrow.Quantity;
            if (studentInList.BookBorrows.Last().ReturnDate > studentInList.BookBorrows.Last().DueDate)
                Console.WriteLine("This student has returned the book after the due date " +
                                  $"({studentInList.BookBorrows.Last().DueDate.ToString("dd/MM/yyyy")}).\n" +
                                  "The amount of the fine to be paid is 10000VND.");
            else Console.WriteLine("This student has returned the book on time.");
        }

        public void UpdateStudent()
        {
            Console.WriteLine("Enter student ID:");
            var studentId = Console.ReadLine();
            while (!IsStudentExisted(studentId))
            {
                Console.WriteLine("This student does not exist, please enter other ID.");
                studentId = Console.ReadLine();
            }

            var studentInList = StudentBorrowers.FirstOrDefault(b => b.StudentId.Equals(studentId));
            Console.WriteLine(studentInList.ToString());
            studentInList.InputInfo();
            Console.WriteLine("Update successfully");
        }

        public void ShowBookLoanList()
        {
            if (!BookBorrows.Any())
            {
                Console.WriteLine("No one has ever borrowed a book here");
            }
            else
            {
                Console.WriteLine("Information books borrowing");
                foreach (var br in BookBorrows)
                {
                    br.ShowTimeLine();
                    Console.WriteLine(br.StudentBorrower.ToString());
                    br.BookInBorrow.ShowBookOnBorrow();
                }
            }
        }

        public void FindMostFrequentBorrower()
        {
            if (!StudentBorrowers.Any())
            {
                Console.WriteLine("No one has evere borrowed a book here.");
            }
            else
            {
                var maxBookBorrow = 1;
                foreach (var s in StudentBorrowers)
                    if (s.BookBorrows.Count >= maxBookBorrow)
                        maxBookBorrow = s.BookBorrows.Count;
                Console.WriteLine("The student (s) who borrow(s) books the most often is/are");
                foreach (var s in StudentBorrowers)
                    if (s.BookBorrows.Count == maxBookBorrow)
                        Console.WriteLine(s.ToString());
            }
        }
    }
}