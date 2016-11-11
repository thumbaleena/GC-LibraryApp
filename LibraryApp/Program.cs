using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<book> Library = new List<book>();
            string bookFile = "../../bookList.txt";
            StreamReader bookReader = new StreamReader(bookFile);
            string bookData = bookReader.ReadToEnd().TrimEnd();
            int menuChoice1 = 0;
            int menuChoice2 = 1;
            string input;
            List<book> results = new List<book>();
            var bookRecords = bookData.Split('\n');
            bookReader.Close();

            Console.WriteLine("Welcome to the Library.  What would you like to do?");
            Console.WriteLine("1. View all books available");
            Console.WriteLine("2. Search books");
            Console.WriteLine();
            Console.Write("Enter a number selection: ");
            menuChoice1 = int.Parse(Console.ReadLine());

            switch (menuChoice1)
            {
                case 1:
                    foreach (var record in bookRecords)
                    {
                        var rc = record.Split(',');

                        Library.Add(new book(rc[0], rc[1], rc[2], rc[3], bool.Parse(rc[4]), DateTime.Parse(rc[5]),
                            int.Parse(rc[6]), float.Parse(rc[7]), float.Parse(rc[8])));
                    }
                    break;
           //     case 2:

            }



            #region Search
            Console.WriteLine("Please make a menu selection to search by:");
            Console.WriteLine("1. Title");
            Console.WriteLine("2. Category");
            Console.WriteLine("3. Author Last Names");
            Console.WriteLine("4. Author First Names");
            Console.WriteLine();
            menuChoice2 = int.Parse(Console.ReadLine());

            switch (menuChoice2)
            {
                case 1:
                    Console.Write("Search titles for: ");
                    input = Console.ReadLine();
                    results = Library.FindAll(delegate (book bk) { return bk.Title.Contains(input); });
                    for (int i = 0; i < results.Count; i++)
                    {
                        Console.WriteLine(results[i]);
                    }
                    break;

                case 2:
                    Console.Write("Search categories for: ");
                    input = Console.ReadLine();
                    results = Library.FindAll(delegate (book bk) { return bk.Category.Contains(input); });
                    for (int i = 0; i < results.Count; i++)
                    {
                        Console.WriteLine(results[i]);
                    }
                    break;

                case 3:
                    Console.Write("Search author last names for: ");
                    input = Console.ReadLine();
                    results = Library.FindAll(delegate (book bk) { return bk.AuthorLast.Contains(input); });
                    for (int i = 0; i < results.Count; i++)
                    {
                        Console.WriteLine(results[i]);
                    }
                    break;

                case 4:
                    Console.Write("Search author first names for: ");
                    input = Console.ReadLine();
                    results = Library.FindAll(delegate (book bk) { return bk.AuthorFirst.Contains(input); });
                    for (int i = 0; i < results.Count; i++)
                    {
                        Console.WriteLine(results[i]);
                    }
                    break;

                default:
                    Console.Write("Invalid input, please try again:  ");
                    menuChoice2 = int.Parse(Console.ReadLine());
                    break;
            }
            #endregion
        }
    }
}
