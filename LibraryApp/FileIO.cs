using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    static class FileIO
    {
        public static void ReadAndInitializeBooks()
        {
            string bookFile = "../../bookList.txt";
            StreamReader bookReader = new StreamReader(bookFile);
            string bookData = bookReader.ReadToEnd().TrimEnd();
            List<Book> results = new List<Book>();
            var bookRecords = bookData.Split('\n');
            bookReader.Close();
            foreach (var record in bookRecords)
            {
                var rc = record.Split(',');

                Library.TheLibrary.AllBooks.Add(new Book(rc[0], rc[1], rc[2], rc[3], bool.Parse(rc[4]),/* DateTime.Parse(rc[5]),
                    int.Parse(rc[6]), float.Parse(rc[7]), float.Parse(rc[8]),*/rc[9])); //

            }
        }
        public static void ReadAndInitializeUsers()
        {
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
        }
        public static void ReadAndInitializeRecords()
        {
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
                Library.TheLibrary.AllRecords.Add(new Record(UserInterface.SearchForUser(rc[0]), searchedBook, Convert.ToDateTime(rc[2]), Convert.ToDateTime(rc[3]), Convert.ToDateTime(rc[4]), int.Parse(rc[5]), float.Parse(rc[6]),bool.Parse(rc[7])));
            }
        }

        public static void WriteLineToFile(Book book)
        {
            //Nonfiction,Just Google It,Doctor,Kamel,false,11/11/2016,0,0.0,0.0

        }
        public static void WriteLineToFile(User user)
        {
            //Tomjk@acdmail.com,Tom,Krueger,false,Boss Moves,100

        }
        public static void WriteLineToFile(Record record)
        {
            //Tomjk@acdmail.com, My Life, 11/11/2016, 11/25/2016, 0, 0.0

        }
    }
}
