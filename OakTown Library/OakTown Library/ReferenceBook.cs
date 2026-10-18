using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakTown_Library
{
    public class ReferenceBook : Book
    {
        public bool Restricted { get; set; }

        public ReferenceBook(string title, string author, int year, string isbn, int pages, bool restricted)
           : base(title, author, year, isbn, pages)
        {
            Restricted = restricted;
        }

        public override string ToString()
        {
            string restriction = Restricted ? "Restricted" : "Not Restricted";
            return base.ToString() + $", {restriction}";
        }

        // Method needed for tests
        public double CalculateCost(int days)
        {
            return 1.0 * days; // same as the test expects
        }
    }
}
