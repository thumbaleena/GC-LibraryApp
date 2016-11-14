using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    class Library
    {
        private string address;
        private string nameOfLibrary;
        private TimeSpan defaultCheckoutTime;
        private float defaultFee;
        private float overDueFeeByDay;
        private List<book> allBooks;
        public static Library TheLibrary;
        public Library(string address, string nameOfLibrary, TimeSpan defaultCheckoutTime, float defaultFee, float overDueFeeByDay)
        {
            this.address = address;
            this.nameOfLibrary = nameOfLibrary;
            this.defaultCheckoutTime = defaultCheckoutTime;
            this.defaultFee = defaultFee;
            this.overDueFeeByDay = overDueFeeByDay;
            allBooks = new List<book>();
            TheLibrary = this;
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string NameOfLibrary
        {
            get
            {
                return nameOfLibrary;
            }

            set
            {
                nameOfLibrary = value;
            }
        }

        public TimeSpan DefaultCheckoutTime
        {
            get
            {
                return defaultCheckoutTime;
            }

            set
            {
                defaultCheckoutTime = value;
            }
        }

        public float DefaultFee
        {
            get
            {
                return defaultFee;
            }

            set
            {
                defaultFee = value;
            }
        }

        public float OverDueFeeByDay
        {
            get
            {
                return overDueFeeByDay;
            }

            set
            {
                overDueFeeByDay = value;
            }
        }

        public List<book> AllBooks
        {
            get
            {
                return allBooks;
            }

            set
            {
                allBooks = value;
            }
        }
    }
}
