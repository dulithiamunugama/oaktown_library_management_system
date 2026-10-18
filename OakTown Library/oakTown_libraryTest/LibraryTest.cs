using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using OakTown_Library;

namespace oakTown_libraryTest
{
    [TestClass]
    public class LibraryTests
    {
        private Library library;
        private Member member;
        private Book book1;
        private ReferenceBook refBook;

        [TestInitialize]
        public void Setup()
        {
            library = new Library();
            member = new Member("M001", "Alice");
            book1 = new Book("C# Basics", "John Doe", 2022, "B001", 300);
            refBook = new ReferenceBook("Encyclopedia", "Editor", 2018, "R001", 500, true);

            library.Items.Add(book1);
            library.Items.Add(refBook);
        }

        [TestMethod]
        public void BorrowItem_ShouldBorrowBookSuccessfully()
        {
            // Act
            library.BorrowItem("B001", member);

            // Assert
            Assert.AreEqual(member.MemberID, book1.BorrowedBy);
            Assert.IsTrue(member.CurrentBorrowings.Contains(book1));
        }

        [TestMethod]
        public void BorrowItem_ShouldNotBorrowReferenceBook()
        {
            // Capture console output
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                library.BorrowItem("R001", member);

                var output = sw.ToString().Trim();
                Assert.AreEqual("Reference books cannot be borrowed.", output);
                Assert.IsNull(refBook.BorrowedBy);
                Assert.IsFalse(member.CurrentBorrowings.Contains(refBook));
            }
        }

        [TestMethod]
        public void BorrowItem_ShouldNotBorrowAlreadyBorrowedBook()
        {
            library.BorrowItem("B001", member);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Try to borrow again
                library.BorrowItem("B001", member);

                var output = sw.ToString().Trim();
                Assert.AreEqual("Item already borrowed.", output);
            }
        }

        [TestMethod]
        public void ReturnItem_ShouldReturnBookSuccessfully()
        {
            library.BorrowItem("B001", member);
            library.ReturnItem("B001", member);

            Assert.IsNull(book1.BorrowedBy);
            Assert.IsFalse(member.CurrentBorrowings.Contains(book1));
            Assert.IsTrue(member.PreviousBorrowings.Contains(book1));
        }

        [TestMethod]
        public void ReturnItem_ShouldShowErrorIfNotBorrowed()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                library.ReturnItem("B001", member);

                var output = sw.ToString().Trim();
                Assert.AreEqual("This member has not borrowed this item.", output);
            }
        }

        [TestMethod]
        public void CalculateCost_ShouldPrintCorrectAmount()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                library.CalculateCost("B001", 4);

                var output = sw.ToString().Trim();
                Assert.AreEqual("Borrowing cost for 4 days = $2.00", output);
            }
        }

        [TestMethod]
        public void CalculateCost_ShouldShowErrorForInvalidISBN()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                library.CalculateCost("X999", 3);

                var output = sw.ToString().Trim();
                Assert.AreEqual("Item not found!", output);
            }
        }
    }
}

