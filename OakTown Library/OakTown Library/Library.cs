using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakTown_Library
{
    public class Library
    {
        public List<LibraryItem> Items { get; set; }

        public Library()
        {
            Items = new List<LibraryItem>();
        }

        public void ListAllItems()
        {
            foreach (var item in Items)
                Console.WriteLine(item);
        }

        public void ListAvailableItems(string keyword)
        {
            var results = Items.Where(i => i.IsAvailable() && i.Title.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0);

            foreach (var item in results)
                Console.WriteLine(item);
        }

        public void BorrowItem(string isbn, Member member)
        {
            var item = Items.FirstOrDefault(i => i.ISBN == isbn);
            if (item == null)
            {
                Console.WriteLine("Item not found!");
                return;
            }

            if (!item.IsAvailable())
            {
                Console.WriteLine("Item already borrowed.");
                return;
            }

            if (item is ReferenceBook refBook && refBook.Restricted)
            {
                Console.WriteLine("Reference books cannot be borrowed.");
                return;
            }

            item.BorrowedBy = member.MemberID;
            member.CurrentBorrowings.Add(item);
            Console.WriteLine("Item borrowed successfully!");
        }

        public void ReturnItem(string isbn, Member member)
        {
            var item = member.CurrentBorrowings.FirstOrDefault(i => i.ISBN == isbn);
            if (item == null)
            {
                Console.WriteLine("This member has not borrowed this item.");
                return;
            }

            item.BorrowedBy = null;
            member.CurrentBorrowings.Remove(item);
            member.PreviousBorrowings.Add(item);
            Console.WriteLine("Item returned successfully!");
        }

        public void CalculateCost(string isbn, int days)
        {
            var item = Items.FirstOrDefault(i => i.ISBN == isbn);
            if (item == null)
            {
                Console.WriteLine("Item not found!");
                return;
            }

            double costPerDay = 0.50; // example cost
            Console.WriteLine($"Borrowing cost for {days} days = ${days * costPerDay:F2}");
        }
    }
}
