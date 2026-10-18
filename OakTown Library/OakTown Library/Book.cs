using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakTown_Library
{
    public class Book : LibraryItem
    {
        public int Pages { get; set; }

        public Book(string title, string author, int year, string isbn, int pages)
            : base(title, author, year, isbn)
        {
            Pages = pages;
        }

        public override string ToString()
        {
            return base.ToString() + $", Pages: {Pages}";
        }
    }
}
