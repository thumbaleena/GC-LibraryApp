using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    class User
    {
        private string email;
        private string firstName;
        private string lastName;
        private bool powerUser;
        private book rentedBook;
        private float totalFees;

        //Tomjk@acdmail.com,Tom,Krueger,true,My Life,100
        public User(string email, string firstName, string lastName, bool powerUser, book rentedBook, float totalFees)
        {
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
            this.powerUser = powerUser;
            this.rentedBook = rentedBook;
            this.totalFees = totalFees;
        }

        #region Properties
        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }

        }
        public string FirstName
        {
            get
            {
                return firstName;
            }

        }
        public bool PowerUser
        {
            get
            {
                return powerUser;
            }

        }
        public book RentedBook
        {
            get
            {
                return rentedBook;
            }

            set
            {
                rentedBook = value;
            }
        }
        public float TotalFees
        {
            get
            {
                return totalFees;
            }

            set
            {
                totalFees = value;
            }
        }
        #endregion

        public override string ToString()
        {
            return FirstName + ", " + LastName + ", " + Email + ", " + TotalFees + ", " + PowerUser + "\n" +
                   RentedBook;//rented book has a Overidden ToString();
        }
    }
}
