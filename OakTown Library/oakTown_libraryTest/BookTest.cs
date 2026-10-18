using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OakTown_Library;

namespace oakTown_libraryTest
{
    [TestClass]
    public class BookTest
    {
        [TestMethod]
        public void Book_CreatesWithCorrectValues()
        {
            var b = new Book("C# Basics", "John Doe", 2022, "B001", 300);

            Assert.AreEqual("C# Basics", b.Title);
            Assert.AreEqual("John Doe", b.Author);
            Assert.AreEqual(2022, b.Year);
            Assert.AreEqual("B001", b.ISBN);
            Assert.AreEqual(300, b.Pages);
        }

        [TestMethod]
        public void Book_ToString_IncludesPages()
        {
            var b = new Book("Test Book", "Jane Doe", 2021, "B002", 250);

            string result = b.ToString();

            Assert.IsTrue(result.Contains("Pages: 250"));
        }

        [TestMethod]
        public void Book_IsAvailableInitially()
        {
            var b = new Book("Available Book", "Author A", 2020, "B003", 150);

            Assert.IsTrue(b.IsAvailable());  // from LibraryItem
        }

        [TestMethod]
        public void Book_CanBeBorrowedAndReturned()
        {
            var b = new Book("Borrow Book", "Author B", 2019, "B004", 400);

            // Borrow
            b.BorrowedBy = "M001";
            Assert.IsFalse(b.IsAvailable());

            // Return
            b.BorrowedBy = null;
            Assert.IsTrue(b.IsAvailable());
        }
    }
}
