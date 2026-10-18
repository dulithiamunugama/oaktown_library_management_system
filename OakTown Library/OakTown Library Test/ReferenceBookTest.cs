using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakTown_Library_Test
{
    public class ReferenceBookTests
    {
        [TestMethod]
        public void ReferenceBook_Borrow_Restricted_Throws()
        {
            var r = new ReferenceBook("333", "Ref", "X", 2010, 1000, true);
            Assert.ThrowsException<InvalidOperationException>(() => r.Borrow("M123"));
        }

        [TestMethod]
        public void ReferenceBook_NotRestricted_AllowsBorrow()
        {
            var r = new ReferenceBook("334", "Ref2", "Y", 2012, 200, false);
            r.Borrow("M123");
            Assert.IsFalse(r.IsAvailable());
            Assert.AreEqual("M123", r.BorrowerMemberId);
        }
    }
}
