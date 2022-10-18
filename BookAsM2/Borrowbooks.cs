using System;

namespace BookAsM2
{
    public class Borrowbooks
    {
        public Book BookOnBorrows = new Book();
        public Student BorrowStudent = new Student();

        public Borrowbooks()
        {
        }

        public Borrowbooks(Student borrowStudent, Book bookOnBorrows)
        {
            BorrowStudent = borrowStudent;
            BookOnBorrows = bookOnBorrows;
        }

        public int BorrowId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDateTime { get; set; }

        public void InputIssueDate()
        {
            IssueDate = DateTime.Now;
            Console.WriteLine("Enter the time to borrow the book");
            var duration = int.Parse(Console.ReadLine());
            DueDate = IssueDate.AddDays(duration);
        }

        public void InputTheReturnDate()
        {
            Console.WriteLine(" Enter the return date: ");
            var dateInput = Console.ReadLine().Split('/');
            ReturnDateTime = new DateTime(int.Parse(dateInput[2]), int.Parse(dateInput[1]),
                int.Parse(dateInput[0])
            );
            while (ReturnDateTime < IssueDate)
            {
                Console.WriteLine("Erro return date, please enter another: ");
                dateInput = Console.ReadLine().Split('/');
                ReturnDateTime = new DateTime(int.Parse(dateInput[2]), int.Parse(dateInput[1]),
                    int.Parse(dateInput[0]));
            }
        }
    }
}