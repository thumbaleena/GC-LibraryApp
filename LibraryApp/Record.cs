using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    class Record
    {
        #region Variables
        private DateTime dueDate;
        private DateTime checkOutDate;
        private DateTime? checkInDate;
        private bool activeStatus;
        private User currentUser;
        private Book currentBook;
        private int daysOverdue;//Representing the amount of days overdue at the time the record was created.
        private float currentLateFee; //Representing the Fee at the time the record was created
        #endregion
        
        #region Constructors

        //Record for creating a record object that already exists
        #region OldRecord
        public Record(User currentUser, Book currentBook, DateTime dateTime1, DateTime dateTime2, DateTime dateTime3, int daysOverdue, float currentLateFee, bool activeStatus)
        {
            this.currentUser = currentUser;
            this.currentBook = currentBook;
            checkOutDate = dateTime1;
            dueDate = dateTime2;
            checkInDate = dateTime3;
            this.daysOverdue = daysOverdue;
            this.currentLateFee = currentLateFee;
            this.activeStatus = activeStatus;
        }
        #endregion

        // Used when Checking out a book.
        #region CheckoutRecord
        public Record(User currentUser, Book currentBook)
       {
           this.currentUser = currentUser;
           this.currentBook = currentBook;
            dueDate = SetDueDate(); //14 days from today
            checkOutDate = DateTime.Today;
            daysOverdue = 0;
            checkInDate = default(DateTime);
            currentLateFee = 0;
        }
        #endregion

        //Used for creating a record when checking IN a book.
        #region CheckInRecord
        public Record(User currentUser, Book currentBook, DateTime dateTime1, DateTime dateTime2, DateTime dateTime3)
        {
            this.currentUser = currentUser;
            this.currentBook = currentBook;
            checkOutDate = dateTime1;
            dueDate = dateTime2;
            checkInDate = dateTime3;
            daysOverdue = CalculateDaysOverdue();
            currentLateFee = CalculateOverdueFees();
       }
        #endregion

        #endregion
        
        #region Properties
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

        public DateTime? CheckInDate
        {
            get { return checkInDate; } 
            set { checkInDate = value; }
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

        public bool ActiveStatus
        {
            get { return activeStatus; }
            set { activeStatus = value; }
        }
        #endregion

        #region Methods
        public DateTime SetDueDate()
        {
            return DateTime.Today.AddDays(Library.TheLibrary.DefaultCheckoutTime.TotalDays);
        }

        public int CalculateDaysOverdue()
        {
            TimeSpan ts;
            ts = DateTime.Today - DueDate;
            if (ts.Days < 0) return 0;
            return ts.Days;
        }

        public float CalculateOverdueFees()
        {
            currentLateFee = CalculateDaysOverdue() * Library.TheLibrary.DefaultFee;
            return currentLateFee;
        }
        #endregion

        public override string ToString()
        {
            return Book + ", Checked out on: " + CheckOutDate +", Check-in date: "+CheckInDate+", Checked-out status: "+activeStatus;
        }
    }
}
