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
        static string bookFile = "../../bookList.txt";
        static string userFile = "../../userList.txt";
        static string recordFile = "../../checkoutRecords.txt";
        public static void ReadAndInitializeBooks()
        {
            StreamReader bookReader = new StreamReader(bookFile);
            string bookData = bookReader.ReadToEnd().TrimEnd();
            List<Book> results = new List<Book>();
            List<string> bookRecords = bookData.Split('\n').ToList();
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

        private static void WriteBookFile()
        {
            StreamWriter sw = new StreamWriter(bookFile);

            foreach(Book bk in Library.TheLibrary.AllBooks)
            {
                sw.WriteLine(bk.ToFileFormat());
            }
            sw.Close();
        }
        private static void WriteRecordFile()
        {
            StreamWriter sw = new StreamWriter(recordFile);

            foreach (Record record in Library.TheLibrary.AllRecords)
            {
                sw.WriteLine(record.ToFileFormat());
            }
            sw.Close();
        }
        private static void WriteUserFile()
        {
            StreamWriter sw = new StreamWriter(userFile);

            foreach (User user in Library.TheLibrary.AllUsers)
            {
                sw.WriteLine(user.ToFileFormat());
            }
            sw.Close();
        }

        //writing a book overwrites a book if there is one with the same title already in it.
        public static void WriteBookToFile(Book book)
        {
            int lineNumber = Library.TheLibrary.SearchForBook(book.Title);
            if (lineNumber == -1)
            {
                Library.TheLibrary.AllBooks.Add(book);
            }
            else if (lineNumber < -1) throw new FormatException("Line: " + lineNumber + "is not -1 or a positive number.");
            else Library.TheLibrary.AllBooks[lineNumber] = book;

            WriteBookFile();
            //Nonfiction,Just Google It,Doctor,Kamel,false,11/11/2016,0,0.0,0.0
            
        }
        public static void WriteRecordToFile(Record record)
        {
            Library.TheLibrary.AllRecords.Add(record);
            WriteRecordFile();
        }
        public static void WriteUserToFile(User user)
        {
            int lineNumber = Library.TheLibrary.SearchForUser(user.Email);
            if (lineNumber == -1)
            {
                Library.TheLibrary.AllUsers.Add(user);
            }
            else if (lineNumber < -1) throw new FormatException("Line: " + lineNumber + "is not -1 or a positive number.");
            else Library.TheLibrary.AllUsers[lineNumber] = user;

            WriteUserFile();
        }
    }
}
