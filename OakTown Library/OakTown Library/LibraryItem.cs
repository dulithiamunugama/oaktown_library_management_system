using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakTown_Library
{
    public abstract class LibraryItem
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; }
        public string BorrowedBy { get; set; } // null if not borrowed

        public LibraryItem(string title, string author, int year, string isbn)
        {
            Title = title;
            Author = author;
            Year = year;
            ISBN = isbn;
            BorrowedBy = null;
        }

        public bool IsAvailable()
        {
            return BorrowedBy == null;
        }

        public override string ToString()
        {
            string status = IsAvailable() ? "Available" : $"Borrowed by {BorrowedBy}";
            return $"{Title} ({Year}) - {Author}, ISBN: {ISBN} [{status}]";
        }
    }

}
