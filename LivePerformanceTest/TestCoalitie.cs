using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LivePerformance;

namespace LivePerformanceTest
{
    [TestClass]
    public class TestCoalitie
    {
        [TestMethod]
        public void TestRetrieveCoalitie()
        {
            var coalitie = LivePerformance.Models.Coalitie.RetrieveCoalitie(1);

            Assert.AreEqual("74", coalitie.Zetels.ToString());
        }

        [TestMethod]
        public void TestUpdateCoalitie()
        {
            var coalitie = LivePerformance.Models.Coalitie.RetrieveCoalitie(1);
            coalitie.Naam = "Geupdate";
            LivePerformance.Models.Coalitie.UpdateCoalitie(coalitie);
            coalitie = LivePerformance.Models.Coalitie.RetrieveCoalitie(1);
            Assert.AreEqual("Geupdate", coalitie.Naam);
        }
       
    }
}
