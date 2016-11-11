using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public static class UserInterface
    {
        static string Welcome_Header = "Welcome to the library application for " + "";

        

        
        public static void ScreenWelcome()
        {
            Console.WriteLine(Welcome_Header);
        }


        #region InputMethods
        //Currently assuming that the user only enters valid data.
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
        #endregion
    }
}
