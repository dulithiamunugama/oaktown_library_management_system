using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OakTown_Library;

namespace oakTown_libraryTest
{
    [TestClass]
    public class MagazineTest
    {
        [TestMethod]
        public void Constructor_ShouldSetAllProperties()
        {
            // Arrange
            string title = "Tech Monthly";
            string author = "Editor A";
            int year = 2025;
            string isbn = "MAG-001";
            int issueNumber = 42;

            // Act
            var magazine = new Magazine(title, author, year, isbn, issueNumber);

            // Assert
            Assert.AreEqual(title, magazine.Title);
            Assert.AreEqual(author, magazine.Author);
            Assert.AreEqual(year, magazine.Year);
            Assert.AreEqual(isbn, magazine.ISBN);
            Assert.AreEqual(issueNumber, magazine.IssueNumber);
        }

        [TestMethod]
        public void ToString_ShouldIncludeIssueNumber()
        {
            // Arrange
            var magazine = new Magazine("Science Weekly", "Editor B", 2024, "MAG-002", 15);

            // Act
            string result = magazine.ToString();

            // Assert
            StringAssert.Contains(result, "Science Weekly");
            StringAssert.Contains(result, "Editor B");
            StringAssert.Contains(result, "2024");
            StringAssert.Contains(result, "MAG-002");
            StringAssert.Contains(result, "Issue No: 15");
        }
    }
}
