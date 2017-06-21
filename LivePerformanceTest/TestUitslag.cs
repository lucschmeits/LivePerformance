using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LivePerformanceTest
{
    [TestClass]
    public class TestUitslag
    {
        [TestMethod]
        public void TestAll()
        {
            var uitslagen = LivePerformance.Models.Uitslag.RetrieveAll();

            Assert.IsNotNull(uitslagen[0]);
        }

        [TestMethod]

        public void TestRemoveUitslag()
        {

            LivePerformance.Models.Uitslag.DeleteUitslag(2);
            var uitslag = LivePerformance.Models.Uitslag.RetrieveUitslag(2);
            Assert.IsNull(uitslag);
        }
    }
}
