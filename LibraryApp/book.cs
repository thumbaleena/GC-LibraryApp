using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    class book
    {
        private string title;
        private bool status;
        private string authorFirst;
        private string authorLast;
        private string category;
        private DateTime dueDate;
        private float bookValue;
        private float currentLateFee;
        

        public book(string title, bool status, string authorFirst, string authorLast, string category, DateTime dueDate, float bookValue, float currentLateFee)
        {
            this.title = title;
            this.status = status;
            this.authorFirst = authorFirst;
            this.authorLast = authorLast;
            this.category = category;
            this.dueDate = dueDate;
            this.bookValue = bookValue;
            this.currentLateFee = currentLateFee;
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

        public bool Status
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
    }
}
