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
            int menuChoice = 1;
            string input;
            List<book> results = new List<book>();
            var bookRecords = bookData.Split('\n');
           foreach (var record in bookRecords)
            {
                var rc = record.Split(',');

                Library.Add(new book(rc[0],rc[1],rc[2],rc[3],bool.Parse(rc[4]),DateTime.Parse(rc[5]),int.Parse(rc[6]),float.Parse(rc[7]),float.Parse(rc[8])));
            }
            bookReader.Close();
            Console.WriteLine("Please make a menu selection to search by:");
            Console.WriteLine("1. Title");
            Console.WriteLine("2. Category");
            Console.WriteLine();
            menuChoice = int.Parse(Console.ReadLine());

            switch (menuChoice)
            {
                case 1:
                Console.Write("Search titles for: ");
                input = Console.ReadLine();
                results = Library.FindAll(delegate(book bk) { return bk.Title.Contains(input); });
                for (int i = 0; i < results.Count; i++)
                {
                    Console.WriteLine(results[i]);
                }
                    break;

                case 2:
                Console.Write("Search categories for: ");
                input = Console.ReadLine();
                results = Library.FindAll(delegate(book bk) { return bk.Category.Contains(input); });
                for (int i = 0; i < results.Count; i++)
                {
                    Console.WriteLine(results[i]);
                }
                    break;

                default:
                    Console.Write("Invalid input, please try again:  ");
                    menuChoice = int.Parse(Console.ReadLine());
                    break;
            }
        }
    }
}
/*            for (int i = 0; i < Library.Count; i++)
            {
                Console.WriteLine(Library[i]);
            }*/
