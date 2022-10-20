using System;
using System.Linq;

namespace BookAsM2
{
    public class BookBorrow
    {
        public Book BookInBorrow = new Book();
        public Student StudentBorrower = new Student();

        public BookBorrow()
        {
        }

        public BookBorrow(Student studentBorrower, Book bookInBorrow)
        {
            StudentBorrower = studentBorrower;
            BookInBorrow = bookInBorrow;
        }

        public int BorrowId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public void InputIssueDate(Student student)
        {
            //IssueDate = DateTime.Now;
            Console.Write("Enter issue date (dd/MM/yyyy): ");
            var dateInput = Console.ReadLine().Split('/');
            IssueDate = new DateTime(int.Parse(dateInput[2]), int.Parse(dateInput[1]), int.Parse(dateInput[0]));
            if (student.BookBorrows.Any())
                while (IssueDate < student.BookBorrows.Last().ReturnDate)
                {
                    Console.Write(
                        "Issue date must not conflict with other previous borrowing time.\nPlease enter again: ");
                    dateInput = Console.ReadLine().Split('/');
                    IssueDate = new DateTime(int.Parse(dateInput[2]), int.Parse(dateInput[1]), int.Parse(dateInput[0]));
                }

            Console.Write("Enter the loan term for the book (in days): ");
            var duration = uint.Parse(Console.ReadLine());
            DueDate = IssueDate.AddDays(duration);
            Console.WriteLine($"Issue date: {IssueDate.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Due date: {DueDate.ToString("dd/MM/yyyy")}");
        }

        public void InputReturnDate()
        {
            Console.Write("Enter return date (dd/MM/yyyy): ");
            var dateInput = Console.ReadLine().Split('/');
            ReturnDate = new DateTime(int.Parse(dateInput[2]), int.Parse(dateInput[1]), int.Parse(dateInput[0]));
            while (ReturnDate < IssueDate)
            {
                Console.Write("The return date must not be before the issue data.\nPlease enter again: ");
                dateInput = Console.ReadLine().Split('/');
                ReturnDate = new DateTime(int.Parse(dateInput[2]), int.Parse(dateInput[1]), int.Parse(dateInput[0]));
            }
        }

        public void ShowTimeLine()
        {
            if (ReturnDate == DateTime.MinValue)
                Console.WriteLine($"Borrowing ID: {BorrowId}, Issue date: {IssueDate.ToString("dd/MM/yyyy")}," +
                                  $" Due date: {DueDate.ToString("dd/MM/yyyy")}, Return date: NOT YET");
            else
                Console.WriteLine($"Borrowing ID: {BorrowId}, Issue date: {IssueDate.ToString("dd/MM/yyyy")}," +
                                  $" Due date: {DueDate.ToString("dd/MM/yyyy")}, Return date: {ReturnDate.ToString("dd/MM/yyyy")}");
        }
    }
}