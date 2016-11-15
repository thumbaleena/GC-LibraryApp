using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public static class UserInterface
    {
        static string input;
        static int menuChoice;
        static string Welcome_Header = "Welcome to the library application for " + "";

        public static void RunGUI()
        {
            //Todo: Start at welcome screen and progress to main menu.
            MainMenu();
        }


        //Todo: add options for other menus:
        //Check In Book
        //Check Out Book
        //Add Book to Library
        //Super user Remove Book from Library
        //Later: Pay Fee
        public static void MainMenu()
        {
            Console.WriteLine("Welcome to the Library.  What would you like to do?");
            Console.WriteLine("1. View all books available");
            Console.WriteLine("2. Search books");
            Console.WriteLine("3. View all users");
            Console.WriteLine();
            //Console.Write();
            GetInput(out menuChoice,"Enter a number selection: ");

            switch (menuChoice)
            {
                case 1:
                    foreach (Book bk in Library.TheLibrary.AllBooks)
                    {
                        Console.WriteLine(bk.ToString());
                    }
                    break;
                case 2:
                    SearchMenu();
                    break;

                case 3:
                    for (int i = 0; i < Library.TheLibrary.AllUsers.Count; i++)
                                {
                                    Console.WriteLine(Library.TheLibrary.AllUsers[i]);
                                }
                        break;

                //added new exception so we don't mistake unwritten code for buggy code.
                default:
                    throw new NotImplementedException();

            }
        }


        //TODO
        public static void CheckInMenu()
        {  
            throw new NotImplementedException("Check in menu has not been created.");
        }
        public static void CheckOutMenu(Book bookToAdd, User userToAdd)
        {
            Console.Write("Would you like to checkout? ");
            bool myY;
            GetInput(out myY);
            if (myY)
            {
                bookToAdd.Status = false;
                userToAdd.RentedBook = bookToAdd;
            }


            throw new NotImplementedException("Check out menu has not been created.");
        }
        public static void AddOrRemoveBook(bool isSuperUser)
        {
            throw new NotImplementedException("Adding or Removing books is not implemented yet.");
        }


        public static void SearchMenu()
        {
            Console.WriteLine("Please make a menu selection to search by:");
            Console.WriteLine("1. Title".PadRight(20) + "3. Author First Name");
            Console.WriteLine("2. Category".PadRight(20) + "4. Author Last Name");
            Console.WriteLine();
            GetInput(out menuChoice, "Menu Choice: ");
            List<Book> searchedBooks;
            Book searchedBook;
            switch (menuChoice)
            {
                #region SearchingTitles
                case 1:
                    //searchedBooks = SearchForTitle();
                    searchedBook = SearchForTitle();
                    break;
                #endregion

                #region SearchingCategories
                case 2:
                    GetInput(out input, "Search categories for: ");
                    searchedBooks = Library.TheLibrary.AllBooks.FindAll(delegate (Book bk) { return bk.Category.Contains(input); });
                    for (int i = 0; i < searchedBooks.Count; i++)
                    {
                        Console.WriteLine(searchedBooks[i]);
                    }
                    break;
                #endregion

                #region SearchingFirstNames
                case 3:
                    GetInput(out input, "Search author first names for: ");
                    searchedBooks = Library.TheLibrary.AllBooks.FindAll(delegate (Book bk) { return bk.AuthorFirst.Contains(input); });
                    for (int i = 0; i < searchedBooks.Count; i++)
                    {
                        Console.WriteLine(searchedBooks[i]);
                    }
                    break;
                #endregion

                #region SearchingLastNames
                case 4:
                    GetInput(out input, "Search author last names for: ");
                    searchedBooks = Library.TheLibrary.AllBooks.FindAll(delegate (Book bk) { return bk.AuthorLast.Contains(input); });
                    for (int i = 0; i < searchedBooks.Count; i++)
                    {
                        Console.WriteLine(searchedBooks[i]);
                    }
                    break;
                #endregion

                default:
                    Console.Write("Invalid input, please try again:  ");
                    menuChoice = int.Parse(Console.ReadLine());
                    break;
            }
        }

        public static Book SearchForTitle()
        {
            string input;
            Book searchedBook;
            UserInterface.GetInput(out input, "Search titles for: ");
            searchedBook = Library.TheLibrary.AllBooks.Find(delegate (Book bk) { return bk.Title.Contains(input); });

            return searchedBook;
        }
        public static Book SearchForTitle(string TitleToSearch)
        {
            Book searchedBook;

            searchedBook = Library.TheLibrary.AllBooks.Find(delegate (Book bk) { return bk.Title.Contains(TitleToSearch); });

            return searchedBook;
        }
        public static User SearchForUser(string UserToSearch)
        {
            User searchedUser;

            searchedUser = Library.TheLibrary.AllUsers.Find(delegate (User user) { return user.Email.Contains(UserToSearch); });

            return searchedUser;
        }

        public static void WelcomeScreen()
        {

            Console.WriteLine(Welcome_Header);
        }

        //To Do: Validation
        #region InputMethods
        //  ----------------!!!!!------------------   Currently assuming that the user only enters valid data. -------------!!!!!--------------
        public static void GetInput(out string myString)
        {
            Console.Write("Input: ");
            myString = Console.ReadLine();
        }
        public static void GetInput(out string myString, string prompt)
        {
            Console.Write(prompt);
            myString = Console.ReadLine();
        }
        public static void GetInput(out int myInt)
        {
            Console.Write("Input: ");
            myInt = int.Parse(Console.ReadLine());
        }
        public static void GetInput(out int myInt, string prompt)
        {
            Console.Write(prompt);
            myInt = int.Parse(Console.ReadLine());
        }
        public static void GetInput(out float myFloat)
        {
            Console.Write("Input: ");
            myFloat = float.Parse(Console.ReadLine());
        }
        public static void GetInput(out float myFloat, string prompt)
        {
            Console.Write(prompt);
            myFloat = float.Parse(Console.ReadLine());
        }
        public static void GetInput(out bool myY)
        {
            Console.Write("Enter y/ n:");
            string input = Console.ReadLine();
            if (input == "y")
            {
                myY = true;
             
            }
            else
            {
                myY = false;
            }
        }
        #endregion

    }
}
