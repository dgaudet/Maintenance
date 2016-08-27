using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maintenance.Vehicle;

namespace Maintenance.Tests.Vehicle
{
    [TestClass]
    public class ElectricAutomobileRepositoryTest
    {
        ElectricAutomobileRepository _repo;

        public ElectricAutomobileRepositoryTest()
        {
            _repo = new ElectricAutomobileRepository();
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
            Assert.AreEqual(auto.VIN, "OrangeCar1");
            Assert.AreEqual(auto.Odometer, 3000);
            Assert.AreEqual(auto.Make, "Tesla");
            Assert.AreEqual(auto.Model, "Roadster");
            Assert.AreEqual(auto.Year, 2011);
            Assert.AreEqual(auto.BatteryPackWeight, 2877);
        }

        [TestMethod]
        public void GetAutomobile_ShouldReturnCorrectAutomobile_GivenExistingId2()
        {
            var auto = _repo.GetAutomobile(2);
            Assert.IsNotNull(auto);
            Assert.AreEqual(auto.Id, 2);
            Assert.AreEqual(auto.VIN, "GreenCar1");
            Assert.AreEqual(auto.Odometer, 15000);
            Assert.AreEqual(auto.Make, "Chevy");
            Assert.AreEqual(auto.Model, "Volt");
            Assert.AreEqual(auto.Year, 2012);
            Assert.AreEqual(auto.BatteryPackWeight, 435);
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
            Assert.AreEqual(automobile1.BatteryPackWeight, 2877);

            var automobile2 = _repo.GetAutomobile(2);
            Assert.IsNotNull(automobile2);
            Assert.AreEqual(tasks[1].Id, automobile2.Id);
            Assert.AreEqual(tasks[1].VIN, automobile2.VIN);
            Assert.AreEqual(tasks[1].Odometer, automobile2.Odometer);
            Assert.AreEqual(tasks[1].Make, automobile2.Make);
            Assert.AreEqual(tasks[1].Model, automobile2.Model);
            Assert.AreEqual(tasks[1].Year, automobile2.Year);
            Assert.AreEqual(automobile2.BatteryPackWeight, 435);
        }
    }
}
