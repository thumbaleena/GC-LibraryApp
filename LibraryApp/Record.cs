using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    class Record
    {
        private DateTime dueDate;
        private DateTime checkOutDate;
        private int daysOverdue;
        private float currentLateFee;
        private User currentUser;
        private Book currentBook;
       public Record(User currentUser, Book currentBook, DateTime checkOutDate, DateTime dueDate, int daysOverdue,
            float currentLateFee)
       {
           this.currentUser = currentUser;
           this.currentBook = currentBook;
           this.checkOutDate = checkOutDate;
           this.dueDate = dueDate;
           this.daysOverdue = daysOverdue;
           this.currentLateFee = currentLateFee;
       }

        public User User
        {
            get { return currentUser; }
            set { currentUser = value; }
        }

        public Book Book
        {
            get
            {
                return currentBook;
            }
            set
            {
                currentBook = value;
            }
        }

        public DateTime CheckOutDate
        {
            get { return checkOutDate; }
            set
            {
                checkOutDate = value;
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
            currentLateFee = CalculateDaysOverdue() * Library.TheLibrary.DefaultFee;
            return currentLateFee;
        }

        public override string ToString()
        {
            return Book+", "+CheckOutDate;
        }
    }
}
