using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OakTown_Library
{
    public class Member
    {
        public string MemberID { get; set; }

        public string Name { get; set; }
        public List<LibraryItem> CurrentBorrowings { get; set; }
        public List<LibraryItem> PreviousBorrowings { get; set; }

        public Member(string id, string name)
        {
            MemberID = id;
            Name = name;
            CurrentBorrowings = new List<LibraryItem>();
            PreviousBorrowings = new List<LibraryItem>();
        }
    }
}
