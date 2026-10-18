using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakTown_Library_Test
{
    public class MagazineTests
    {
        [TestMethod]
        public void Magazine_CostWorks()
        {
            var m = new Magazine("MAG1", "Mag", "Z", 2020, 12);
            Assert.AreEqual(2.5, m.CalculateCost(5));
        }
    }
}
