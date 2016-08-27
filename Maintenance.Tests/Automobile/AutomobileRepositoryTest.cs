using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maintenance.Automobile;

namespace Maintenance.Tests.Automobile
{
    [TestClass]
    public class AutomobileRepositoryTest
    {
        AutomobileRepository _repo;

        public AutomobileRepositoryTest()
        {
            _repo = new AutomobileRepository();
        }

        [TestMethod]
        public void GetAutomobile_ShouldReturnNull_GivenNonExistingId()
        {
            Assert.IsNull(_repo.GetAutomobile(0));
        }

        [TestMethod]
        public void GetAutomobile_ShouldReturnCorrectAutomobile_GivenExistingId1()
        {
            var auto = _repo.GetAutomobile(1);
            Assert.IsNotNull(auto);
            Assert.AreEqual(auto.Id, 1);
            Assert.AreEqual(auto.VIN, "RedCar1");
            Assert.AreEqual(auto.Odometer, 5000);
            Assert.AreEqual(auto.Make, "Nissan");
            Assert.AreEqual(auto.Model, "Murano");
            Assert.AreEqual(auto.Year, 2011);
        }

        [TestMethod]
        public void GetAutomobile_ShouldReturnCorrectAutomobile_GivenExistingId2()
        {
            var auto = _repo.GetAutomobile(2);
            Assert.IsNotNull(auto);
            Assert.AreEqual(auto.Id, 2);
            Assert.AreEqual(auto.VIN, "BlueCar1");
            Assert.AreEqual(auto.Odometer, 15000);
            Assert.AreEqual(auto.Make, "Nissan");
            Assert.AreEqual(auto.Model, "Frontier");
            Assert.AreEqual(auto.Year, 2006);
        }

        [TestMethod]
        public void GetAutomobiles_ShouldReturnTwo()
        {
            var autos = _repo.GetAutomobiles();
            Assert.IsNotNull(autos);
            Assert.AreEqual(autos.Count, 2);
        }

        [TestMethod]
        public void GetAutomobiles_ShouldReturnTheSameAutosAsGetAutomobile()
        {
            var tasks = _repo.GetAutomobiles();
            Assert.IsNotNull(tasks);
            var automobile1 = _repo.GetAutomobile(1);
            Assert.IsNotNull(automobile1);
            Assert.AreEqual(tasks[0].Id, automobile1.Id);
            Assert.AreEqual(tasks[0].VIN, automobile1.VIN);
            Assert.AreEqual(tasks[0].Odometer, automobile1.Odometer);
            Assert.AreEqual(tasks[0].Make, automobile1.Make);
            Assert.AreEqual(tasks[0].Model, automobile1.Model);
            Assert.AreEqual(tasks[0].Year, automobile1.Year);

            var automobile2 = _repo.GetAutomobile(2);
            Assert.IsNotNull(automobile2);
            Assert.AreEqual(tasks[1].Id, automobile2.Id);
            Assert.AreEqual(tasks[1].VIN, automobile2.VIN);
            Assert.AreEqual(tasks[1].Odometer, automobile2.Odometer);
            Assert.AreEqual(tasks[1].Make, automobile2.Make);
            Assert.AreEqual(tasks[1].Model, automobile2.Model);
            Assert.AreEqual(tasks[1].Year, automobile2.Year);
        }
    }
}
