using System;
using LivePerformance.DAL.REPO;
using LivePerformance.DAL.SQL;
using LivePerformance.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LivePerformanceTest
{
    [TestClass]
    public class TestPartij
    {
        [TestMethod]
        public void TestCreatePartij()
        {
            var sql = new PartijSQL();
            var repo = new PartijREPO(sql);
            var partij = new Partij("FvD", "Forum voor Democratie", "Thierry Baudet");
            //repo.CreatePartij(partij);
            Assert.AreEqual("FvD", repo.RetrievePartij(3).Afkorting);
        }
        [TestMethod]
        public void TestRetriveAll()
        {
            var sql = new PartijSQL();
            var repo = new PartijREPO(sql);
            var partijList = repo.RetrieveAll();

            Assert.AreEqual(1, partijList[0].Id);
        }

        [TestMethod]
        public void TestGetUitslagByPartij()
        {
            var sql = new PartijSQL();
            var repo = new PartijREPO(sql);
            var uitslagList = repo.GetUitslagByPartij(1);

            Assert.AreEqual(33, uitslagList[0].Zetels);

        }

        [TestMethod]
        public void TestRetrievePartij()
        {
            var sql = new PartijSQL();
            var repo = new PartijREPO(sql);

            var partij = repo.RetrievePartij(1);

            Assert.AreEqual("VVD", partij.Afkorting);
        }
    }
}
