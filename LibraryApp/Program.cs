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
            List<Book> results = new List<Book>();
            var bookRecords = bookData.Split('\n');
            bookReader.Close();
            
            
            //Read Book File
            foreach (var record in bookRecords)
            {
                var rc = record.Split(',');

                Library.TheLibrary.AllBooks.Add(new Book(rc[0], rc[1], rc[2], rc[3], bool.Parse(rc[4]),/* DateTime.Parse(rc[5]),
                    int.Parse(rc[6]), float.Parse(rc[7]), float.Parse(rc[8]),*/rc[9])); //

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
                Library.TheLibrary.AllUsers.Add(new User(rc[0], rc[1], rc[2], bool.Parse(rc[3]), UserInterface.SearchForTitle(rc[1]), float.Parse(rc[5]))); //trouble with rc[4] because the data type is "book".  what would be the best way to pass the object?
            }

            List<Record> Records = new List<Record>();
            string recordFile = "../../checkoutRecords.txt";
            StreamReader recordReader = new StreamReader(recordFile);
            string recordData = recordReader.ReadToEnd().TrimEnd();
            List<Record> recordResults = new List<Record>();
            var recordRecords = recordData.Split('\n');
            recordReader.Close();
            foreach (var record in recordRecords)
            {
                var rc = record.Split(',');
                Book searchedBook;
                searchedBook = Library.TheLibrary.AllBooks.Find(delegate (Book bk) { return bk.Title.Contains(rc[1]); });
                Library.TheLibrary.AllRecords.Add(new Record(UserInterface.SearchForUser(rc[0]), searchedBook, Convert.ToDateTime(rc[2]), Convert.ToDateTime(rc[3]), int.Parse(rc[4]), float.Parse(rc[5]))); 
            }


        UserInterface.RunGUI();
        }

    }
}
