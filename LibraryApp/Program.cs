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
            var bookRecords = bookData.Split('\n');
           foreach (var record in bookRecords)
            {
                var rc = record.Split(',');

                Library.Add(new book(rc[0],rc[1],rc[2],rc[3],bool.Parse(rc[4]),DateTime.Parse(rc[5]),int.Parse(rc[6]),float.Parse(rc[7]),float.Parse(rc[8])));
            }
            bookReader.Close();
            for (int i = 0; i < Library.Count; i++)
            {
                Console.WriteLine(Library[i]);
            }
            // calculate overdue fees


        }
    }
}

