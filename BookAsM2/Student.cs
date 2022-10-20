using System;
using System.Collections.Generic;
using System.Linq;

namespace BookAsM2
{
    public class Student : Person
    {
        public List<BookBorrow> BookBorrows = new List<BookBorrow>();

        public Student(string studentId)
        {
            StudentId = studentId;
        }

        public Student()
        {
        }

        public string StudentId { get; set; }

        public override void InputInfo()
        {
            Console.Write("First name: ");
            FirstName = Console.ReadLine();
            Console.Write("Last name: ");
            LastName = Console.ReadLine();
            Console.Write("Phone number: ");
            PhoneNumber = Console.ReadLine();
            while (PhoneNumber.Any(char.IsLetter))
            {
                Console.WriteLine("Invalid phone number, please enter another.");
                PhoneNumber = Console.ReadLine();
            }

            Console.Write("Email address: ");
            EmailAddress = Console.ReadLine();
            while (!EmailAddress.Contains("@"))
            {
                Console.WriteLine("Invalid email address, please enter another.");
                EmailAddress = Console.ReadLine();
            }
        }

        public override string ToString()
        {
            return
                $"Student ID: {StudentId}, Name: {FirstName} {LastName}, Phone: {PhoneNumber}, Email: {EmailAddress}";
        }
    }
}