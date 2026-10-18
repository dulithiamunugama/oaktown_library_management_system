using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakTown_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            Member member = new Member("M123", "Alice");

            // Populate manually
            // Books
            library.Items.Add(new Book("To Kill a Mockingbird", "Harper Lee", 1960, "978-0060935467", 324));
            library.Items.Add(new Book("1984", "George Orwell", 1949, "978-0451524935", 328));
            library.Items.Add(new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925, "978-0743273565", 180));
            library.Items.Add(new Book("The Hobbit", "J.R.R. Tolkien", 1937, "978-0547928227", 310));
            library.Items.Add(new Book("Pride and Prejudice", "Jane Austen", 1813, "978-1503290563", 279));

            // Reference Books
            library.Items.Add(new ReferenceBook("Oxford English Dictionary", "Oxford", 2000, "978-0198611868", 1000, true));
            library.Items.Add(new ReferenceBook("Encyclopedia Britannica", "Britannica Editors", 2010, "978-1593392925", 32000, true));
            library.Items.Add(new ReferenceBook("Gray's Anatomy", "Henry Gray", 2008, "978-0702052309", 1600, true));
            library.Items.Add(new ReferenceBook("Cambridge Atlas of Astronomy", "Cambridge University", 1990, "978-0521343768", 550, false));

            // Magazines
            library.Items.Add(new Magazine("National Geographic", "NatGeo", 2023, "978-1426209574", 202));
            library.Items.Add(new Magazine("Time", "Time Inc.", 2022, "978-1618933001", 101));
            library.Items.Add(new Magazine("Forbes", "Forbes Media", 2021, "978-1644732014", 305));
            library.Items.Add(new Magazine("Scientific American", "Springer Nature", 2023, "978-1426216434", 415));


            int choice;
            do
            {
                Console.WriteLine("\n--- OakTown Library Menu ---");
                Console.WriteLine("1. List all items");
                Console.WriteLine("2. Search available items by keyword");
                Console.WriteLine("3. Borrow item");
                Console.WriteLine("4. Return item");
                Console.WriteLine("5. Calculate borrowing cost");
                Console.WriteLine("6. List current borrowings");
                Console.WriteLine("7. List previous borrowings");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out choice)) choice = -1;

                switch (choice)
                {
                    case 1:
                        library.ListAllItems();
                        break;
                    case 2:
                        Console.Write("Enter keyword: ");
                        string keyword = Console.ReadLine();
                        library.ListAvailableItems(keyword);
                        break;
                    case 3:
                        Console.Write("Enter ISBN to borrow: ");
                        string isbnBorrow = Console.ReadLine();
                        library.BorrowItem(isbnBorrow, member);
                        break;
                    case 4:
                        Console.Write("Enter ISBN to return: ");
                        string isbnReturn = Console.ReadLine();
                        library.ReturnItem(isbnReturn, member);
                        break;
                    case 5:
                        Console.Write("Enter ISBN: ");
                        string isbnCost = Console.ReadLine();
                        Console.Write("Enter days: ");
                        int days = int.Parse(Console.ReadLine());
                        library.CalculateCost(isbnCost, days);
                        break;
                    case 6:
                        foreach (var i in member.CurrentBorrowings)
                            Console.WriteLine(i);
                        break;
                    case 7:
                        foreach (var i in member.PreviousBorrowings)
                            Console.WriteLine(i);
                        break;
                    case 0:
                        Console.WriteLine("Exiting... Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }

            } while (choice != 0);
        }
    }
}
