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

            //Read Book File
            FileIO.ReadAndInitializeBooks();

            //Read User File
            FileIO.ReadAndInitializeUsers();

            //Read Record File
            FileIO.ReadAndInitializeRecords();


        UserInterface.RunGUI();
        }

    }
}
