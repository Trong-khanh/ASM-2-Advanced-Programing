using System;

namespace BookAsM2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter library name: ");
            var libName = Console.ReadLine();
            Console.Clear();
            var univLib = new Library(libName);
            univLib.Hello();
            Console.ReadKey();
            Console.Clear();
            univLib.ShowMenu();
            var option = Console.ReadLine();
            do
            {
                switch (option)
                {
                    case "1":
                        univLib.ShowBookList();
                        break;
                    case "2":
                        univLib.AddBook();
                        break;
                    case "3":
                        var searchedBooks = univLib.SearchBooksByTitle();
                        univLib.ShowBookList(searchedBooks);
                        break;
                    case "4":
                        univLib.UpdateOrDeleteBook();
                        break;
                    case "5":
                        univLib.LendBook();
                        break;
                    case "6":
                        univLib.ReceiveBook();
                        break;
                    case "7":
                        univLib.UpdateStudent();
                        break;
                    case "8":
                        univLib.ShowBookLoanList();
                        break;
                    case "9":
                        univLib.FindMostFrequentBorrower();
                        break;
                    case "10":
                        return;
                    default:
                        Console.WriteLine("Invalid option, please enter again.");
                        break;
                }

                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                Console.Clear();
                univLib.ShowMenu();
                option = Console.ReadLine();
            } while (true);
        }
    }
}