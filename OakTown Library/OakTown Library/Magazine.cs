using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakTown_Library
{
    public class Magazine : LibraryItem
    {
        public int IssueNumber { get; set; }

        public Magazine(string title, string author, int year, string isbn, int issueNumber)
            : base(title, author, year, isbn)
        {
            IssueNumber = issueNumber;
        }

        public override string ToString()
        {
            return base.ToString() + $", Issue No: {IssueNumber}";
        }
    }
}
