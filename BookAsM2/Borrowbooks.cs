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

        //method which is used to input the issue date and calculate the due date of a book borrowing.
        public void InputIssueDate()
        {
            IssueDate = DateTime.Now;
            Console.WriteLine("Enter the time to borrow the book");
            var duration = int.Parse(Console.ReadLine());
            DueDate = IssueDate.AddDays(duration);
        }

        //method which is used to input the return date of a book borrowing.
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

        //This is the two methods which are used to show the time line and the status of borrowing and returning a book
        public override string ToString()
        {
            return $"BorrowID: {BorrowId},IssueDate: {IssueDate.ToString("dd/MM/yyyy")}," +
                   $"Due date: {DueDate.ToString("dd/MM/yy")}, Return date: Not Yet";
        }

        public void ShowTimLine()
        {
            if (ReturnDateTime == DateTime.MinValue)
                Console.WriteLine($"Borrow Id: {BorrowId}, IssueDate: {IssueDate.ToString("dd/MM/yyyy")}" +
                                  $" Due Date: {DueDate.ToString("dd/MM/yyyy")}, Return date: Not Yet");
            else
                Console.WriteLine($"Borrow Id: {BorrowId},IssueDate: {IssueDate.ToString("dd/MM/yyyy")}" +
                                  $" Due date: {DueDate.ToString("dd/MM/yyyy")}, Return date: {ReturnDateTime.ToString("dd/MM/yyyy")}");
        }
    }
}