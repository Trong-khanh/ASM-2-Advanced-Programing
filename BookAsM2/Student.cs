using System;
using System.Collections.Generic;
using System.Linq;

namespace BookAsM2
{
    public class Student : Person
    {
        public List<Book> Books = new List<Book>();

        public Student(string studentId)
        {
            studentId = StudentId;
        }

        public Student()
        {
        }

        public string StudentId { get; set; }
        //Đây là phương thức ghi đè được sử dụng để nhập tất cả các giá trị thuộc tính của lớp Sinh viên

        public override void InputInformation()
        {
            Console.Write("First name: ");
            FirstName = Console.ReadLine();
            Console.Write("Last name: ");
            LastName = Console.ReadLine();
            Console.Write("Phone number: ");
            PhoneNumber = Console.ReadLine();

            while (PhoneNumber.Any(char.IsLetter))
            {
                Console.WriteLine("Phone number is number, please enter others");
                Console.ReadLine();
            }

            Console.WriteLine("Email");
            Email = Console.ReadLine();
        }

        public override string ToString()
        {
            return $"Student: {StudentId},FullName: {FirstName} {LastName}, " +
                   $"PhoneNumber: {PhoneNumber}, Email: {Email} ";
        }
    }
}