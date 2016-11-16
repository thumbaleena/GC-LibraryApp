using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class Book
    {
        private string title;
        private bool status;
        private string authorFirst;
        private string authorLast;
        private string category;
        private DateTime dueDate;
        private int daysOverdue;
        private float bookValue;
        private float currentLateFee;
        private string checkedOutTo;
        

        public Book(string category, string title, string authorFirst, string authorLast, bool status,/* DateTime dueDate, int daysOverdue, float bookValue, float currentLateFee, */string checkedOutTo)
        {
            this.title = title;
            this.status = status;
            this.authorFirst = authorFirst;
            this.authorLast = authorLast;
            this.category = category;
   /*         this.dueDate = dueDate;
            this.daysOverdue = DaysOverdue;
            this.bookValue = bookValue;
            this.currentLateFee = currentLateFee; */
            this.checkedOutTo = checkedOutTo;
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public bool Status //if static = true, the book is checked OUT, if false - available
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public string AuthorFirst
        {
            get
            {
                return authorFirst;
            }

            set
            {
                authorFirst = value;
            }
        }

        public string AuthorLast
        {
            get
            {
                return authorLast;
            }

            set
            {
                authorLast = value;
            }
        }

        public string Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
            }
        }

        public DateTime DueDate
        {
            get
            {
                return dueDate;
            }

            set
            {
                dueDate = value;
            }
        }

        public int DaysOverdue
        {
            get { return daysOverdue; }
            set { daysOverdue = value; }
        }
        public float BookValue
        {
            get
            {
                return bookValue;
            }

            set
            {
                bookValue = value;
            }
        }

        public float CurrentLateFee
        {
            get
            {
                return currentLateFee;
            }

            set
            {
                currentLateFee = value;
            }

        }

        public string CheckedOutTo
        {
            get
            {
                return checkedOutTo;
            }

            set
            {
                checkedOutTo = value;
            }
        }

        //only use this in the Check Out method
        public DateTime SetDueDate()
        {            
            return DateTime.Today.AddDays(Library.TheLibrary.DefaultCheckoutTime.TotalDays);
        }
        public int CalculateDaysOverdue()
        {
            TimeSpan ts;
            ts = DateTime.Today - DueDate;
            return ts.Days;
        }

        public float CalculateOverdueFees()
        {
            currentLateFee = CalculateDaysOverdue()*Library.TheLibrary.DefaultFee;
            return currentLateFee;
        }
        public override string ToString()
        {
            return Category + ", " + Title + ", " + AuthorFirst + ", " + AuthorLast + ", " + Status + ", " +
                   DueDate + ", " + DaysOverdue + ", "+ BookValue + ", " + CurrentLateFee;
        }

    }
}
