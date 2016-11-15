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
            new Library("YadaAddress", "THELIBRARY", new TimeSpan(14, 0, 0, 0), .50f, .10f); //Creating a new Library to work with.. The Library will be stored in "Library.TheLibrary"


            string bookFile = "../../bookList.txt";
            StreamReader bookReader = new StreamReader(bookFile);
            string bookData = bookReader.ReadToEnd().TrimEnd();
            List<book> results = new List<book>();
            var bookRecords = bookData.Split('\n');
            bookReader.Close();
            
            
            //Read Book File
            foreach (var record in bookRecords)
            {
                var rc = record.Split(',');

                Library.TheLibrary.AllBooks.Add(new book(rc[0], rc[1], rc[2], rc[3], bool.Parse(rc[4]), DateTime.Parse(rc[5]),
                    int.Parse(rc[6]), float.Parse(rc[7]), float.Parse(rc[8])));

            }

            //Read User File
            List<User> Users = new List<User>();
            string userFile = "../../userList.txt";
            StreamReader userReader = new StreamReader(userFile);
            string userData = userReader.ReadToEnd().TrimEnd();
            List<User> userResults = new List<User>();
            var userRecords = userData.Split('\n');
            userReader.Close();
            foreach (var user in userRecords)
            {
                var rc = user.Split(',');
                book rentedBook = SearchForTitle(rc[4]);
                Library.TheLibrary.AllUsers.Add(new User(rc[0], rc[1], rc[2], bool.Parse(rc[3]), rentedBook, float.Parse(rc[5]))); //trouble with rc[4] because the data type is "book".  what would be the best way to pass the object?
            }

            UserInterface.RunGUI();
        }


        private static book SearchForTitle()
        {
            string input;
            book searchedBook;
            UserInterface.GetInput(out input, "Search titles for: ");
            searchedBook = Library.TheLibrary.AllBooks.Find(delegate (book bk) { return bk.Title.Contains(input); });

            return searchedBook;
        }
        private static book SearchForTitle(string TitleToSearch)
        {
            book searchedBook;
            
            searchedBook = Library.TheLibrary.AllBooks.Find(delegate (book bk) { return bk.Title.Contains(TitleToSearch); });

            return searchedBook;
        }
    }
}
