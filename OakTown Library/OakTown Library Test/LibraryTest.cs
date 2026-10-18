using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace OakTown_Library_Test
{
    [TestClass]
    public class LibraryTest
    {
        private string GetTempDbPath() => Path.Combine(Path.GetTempPath(), $"library_test_{Guid.NewGuid()}.db");

        [TestMethod]
        public void BorrowAndReturnFlow()
        {
            var db = GetTempDbPath();
            var lib = new Library(db);
            lib.Initialize(true); // will insert sample data
            var member = new Member("M123");

            // pick a book ISBN from the library
            var book = lib.Items.Find(i => i is Book && !(i is ReferenceBook));
            Assert.IsNotNull(book);

            // Borrow
            var ok = lib.BorrowItem(book.ISBN, member, out var msg);
            Assert.IsTrue(ok);

            // cannot borrow again
            var ok2 = lib.BorrowItem(book.ISBN, member, out var msg2);
            Assert.IsFalse(ok2);

            // Return
            var ret = lib.ReturnItem(book.ISBN, member, out var rm);
            Assert.IsTrue(ret);
        }
    }
}

