using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maintenance.Vehicle;
using Maintenance.Vehicle.Models;
using System.Linq;

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
        public void GetAutomobile_ShouldReturnNull_GivenNonExistingVin()
        {
            Assert.IsNull(_repo.GetAutomobile("non existing"));
        }

        [TestMethod]
        public void GetAutomobile_ShouldReturnCorrectAutomobile_GivenExistingVin1()
        {
            var vin = "OrangeCar1";

            var auto = _repo.GetAutomobile(vin);
            Assert.IsNotNull(auto);
            Assert.AreEqual(vin, auto.VIN);
            Assert.AreEqual(3000, auto.Odometer);
            Assert.AreEqual("Tesla", auto.Make);
            Assert.AreEqual("Roadster", auto.Model);
            Assert.AreEqual(2011, auto.Year);
            Assert.AreEqual(2877, auto.BatteryPackWeight);
        }

        [TestMethod]
        public void GetAutomobile_ShouldReturnCorrectAutomobile_GivenExistingVin2()
        {
            var vin = "GreenCar1";

            var auto = _repo.GetAutomobile(vin);
            Assert.IsNotNull(auto);
            Assert.AreEqual(vin, auto.VIN);
            Assert.AreEqual(15000, auto.Odometer);
            Assert.AreEqual("Chevy", auto.Make);
            Assert.AreEqual("Volt", auto.Model);
            Assert.AreEqual(2012, auto.Year);
            Assert.AreEqual(435, auto.BatteryPackWeight);
        }

        [TestMethod]
        public void GetAutomobile_ShouldReturnCorrectAutomobile_GivenExistingVinButDifferentVinCase()
        {
            var vin = "greencar1";

            var auto = _repo.GetAutomobile(vin);
            Assert.IsNotNull(auto);
            Assert.IsTrue(vin.Equals(auto.VIN, System.StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void GetAutomobiles_ShouldReturnTwo()
        {
            var autos = _repo.GetAutomobiles();
            Assert.IsNotNull(autos);
            Assert.IsTrue(autos.Count > 1);
        }

        [TestMethod]
        public void GetAutomobiles_ShouldReturnTheSameAutosAsGetAutomobile()
        {
            var tasks = _repo.GetAutomobiles();

            Assert.IsNotNull(tasks);
            var automobile1 = _repo.GetAutomobile("OrangeCar1");
            Assert.IsNotNull(automobile1);
            Assert.AreEqual(tasks[0].VIN, automobile1.VIN);
            Assert.AreEqual(tasks[0].Odometer, automobile1.Odometer);
            Assert.AreEqual(tasks[0].Make, automobile1.Make);
            Assert.AreEqual(tasks[0].Model, automobile1.Model);
            Assert.AreEqual(tasks[0].Year, automobile1.Year);
            Assert.AreEqual(automobile1.BatteryPackWeight, 2877);

            var automobile2 = _repo.GetAutomobile("GreenCar1");
            Assert.IsNotNull(automobile2);
            Assert.AreEqual(tasks[1].VIN, automobile2.VIN);
            Assert.AreEqual(tasks[1].Odometer, automobile2.Odometer);
            Assert.AreEqual(tasks[1].Make, automobile2.Make);
            Assert.AreEqual(tasks[1].Model, automobile2.Model);
            Assert.AreEqual(tasks[1].Year, automobile2.Year);
            Assert.AreEqual(automobile2.BatteryPackWeight, 435);
        }        

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void InsertAutomobile_ShouldThrowArugumentException_GivenNull()
        {
            _repo.InsertAutomobile(null);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void InsertAutomobile_ShouldThrowArugumentException_GivenAutoWithNullVIN()
        {
            _repo.InsertAutomobile(new ElectricAutomobile());
        }

        [TestMethod]
        public void InsertAutomobile_ShouldAllowInsertingAutomobile()
        {
            _repo.InsertAutomobile(new ElectricAutomobile() { VIN = "111" });
        }

        [TestMethod]
        public void InsertAutomobile_ShouldStoreAutomobile()
        {
            var expectedAuto = new ElectricAutomobile() { VIN = "1234", Odometer = 234, Make = "make it", Model = "model", Year = 1, BatteryPackWeight = 8 };
            _repo.InsertAutomobile(expectedAuto);

            var actualAuto = _repo.GetAutomobile(expectedAuto.VIN);

            Assert.IsNotNull(actualAuto);
            Assert.AreEqual(expectedAuto.VIN, actualAuto.VIN);
            Assert.AreEqual(expectedAuto.Odometer, actualAuto.Odometer);
            Assert.AreEqual(expectedAuto.Make, actualAuto.Make);
            Assert.AreEqual(expectedAuto.Model, actualAuto.Model);
            Assert.AreEqual(expectedAuto.Year, actualAuto.Year);
            Assert.AreEqual(expectedAuto.BatteryPackWeight, actualAuto.BatteryPackWeight);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException), "Duplicate VIN is not allowed")]
        public void InsertAutomobile_ShouldThrowArgumentExcption_GivenAutoWithDuplicateVIN()
        {
            var expectedAuto = new ElectricAutomobile() { VIN = "56789" };
            _repo.InsertAutomobile(expectedAuto);
            _repo.InsertAutomobile(expectedAuto);

            _repo.GetAutomobile(expectedAuto.VIN);
        }

        [TestMethod]
        public void ElectricAutomobileRepository_ShouldRetainListOfAutos_GivenMultipleInstances()
        {
            var expectedAuto = new ElectricAutomobile() { VIN = "1111" };
            _repo.InsertAutomobile(expectedAuto);

            var repo2 = new ElectricAutomobileRepository();

            var actualAuto = repo2.GetAutomobile(expectedAuto.VIN);

            Assert.IsNotNull(actualAuto);
            Assert.AreEqual(expectedAuto.VIN, actualAuto.VIN);
        }

        [TestMethod]
        public void GetAutomobiles_ShouldReturn_InsertedAutomobile()
        {
            var expectedAuto = new ElectricAutomobile() { VIN = "9911"};
            _repo.InsertAutomobile(expectedAuto);

            var autos = _repo.GetAutomobiles();
            var actualAuto = autos.FirstOrDefault(a => a.VIN == expectedAuto.VIN);

            Assert.IsNotNull(actualAuto);
            Assert.AreEqual(expectedAuto.VIN, actualAuto.VIN);
        }
    }
}
