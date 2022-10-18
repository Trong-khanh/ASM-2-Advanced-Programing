using System;

namespace BookAsM2
{
    public class Borrowbooks
    {
        public int BorrowId { get; set; }
        public Student BorrowStudent = new Student();
        public Book BookOnBorrows = new Book();
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDateTime { get; set; }

        public Borrowbooks()
        {
        }

        public Borrowbooks(Student borrowStudent, Book bookOnBorrows)
        {
            BorrowStudent = borrowStudent;
            BookOnBorrows = bookOnBorrows;
        }

        public void InputIssueDate()
        {
            IssueDate = DateTime.Now;
            Console.WriteLine("Enter the time to borrow the book");
            int duration = int.Parse(Console.ReadLine());
            DueDate = IssueDate.AddDays(duration);
        }
    }
}