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
        private string lastName;
        private string firstName;
        private bool powerUser;

        public User(string email, string lastName, string firstName, bool powerUser)
        {
            this.email = email;
            this.lastName = lastName;
            this.firstName = firstName;
            this.powerUser = powerUser;
        }

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
    }
}
