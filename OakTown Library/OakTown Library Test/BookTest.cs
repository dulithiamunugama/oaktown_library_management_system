using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;

namespace OakTown_Library_Test
{
    public class BookTests
    {
        [TestMethod]
        public void Book_CostCalculation_Works()
        {
            var b = new Book("111", "Test Book", "Author", 2000, 100);
            Assert.AreEqual(5.0, b.CalculateCost(5));
        }

        [TestMethod]
        public void Book_IsAvailable_OnCreate()
        {
            var b = new Book("222", "Test", "A", 2000, 50);
            Assert.IsTrue(b.IsAvailable());
        }
    }
}

