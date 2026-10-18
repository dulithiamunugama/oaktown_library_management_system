using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OakTown_Library;

namespace oakTown_libraryTest
{
    [TestClass]
    public class ReferenceBookTest
    {
        [TestMethod]
        public void ReferenceBook_CreatesWithRestrictedStatus()
        {
            var rb = new ReferenceBook("Oxford English Dictionary", "Oxford", 2000, "978-0198611868", 1000, true);

            Assert.AreEqual("Oxford English Dictionary", rb.Title);
            Assert.AreEqual("Oxford", rb.Author);
            Assert.AreEqual(2000, rb.Year);
            Assert.AreEqual("978-0198611868", rb.ISBN);
            Assert.AreEqual(1000, rb.Pages);
            Assert.IsTrue(rb.Restricted);   // ✅ restricted status is stored
        }

        [TestMethod]
        public void ReferenceBook_ToString_ShowsRestrictedStatus()
        {
            var rb = new ReferenceBook("Test Ref", "Author A", 2020, "1111", 200, true);
            string result = rb.ToString();

            Assert.IsTrue(result.Contains("Restricted"));  // ✅ must mention restricted
        }

        [TestMethod]
        public void ReferenceBook_ToString_ShowsNotRestrictedStatus()
        {
            var rb = new ReferenceBook("Test Ref 2", "Author B", 2021, "2222", 300, false);
            string result = rb.ToString();

            Assert.IsTrue(result.Contains("Not Restricted"));  // ✅ must mention not restricted
        }

        [TestMethod]
        public void ReferenceBook_InheritsCalculateCost()
        {
            var rb = new ReferenceBook("Cost Test", "C Author", 2010, "3333", 150, true);

            double cost = rb.CalculateCost(5);  // should come from Book
            Assert.AreEqual(5.0, cost);  // ✅ same rule: 1.0 per day
        }

        [TestMethod]
        public void ReferenceBook_IsAvailableInitially()
        {
            var rb = new ReferenceBook("Available Test", "Auth", 2022, "4444", 250, false);

            Assert.IsTrue(rb.IsAvailable());  // ✅ newly created, no member borrowed it
        }
    }
}

