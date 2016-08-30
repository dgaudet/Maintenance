﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maintenance.Vehicle;
using Maintenance.Vehicle.Models;
using System.Linq;

namespace Maintenance.Tests.Vehicle
{
    [TestClass]
    public class DieselAutomobileRepositoryTest
    {
        DieselAutomobileRepository _repo;

        public DieselAutomobileRepositoryTest()
        {
            _repo = new DieselAutomobileRepository();
        }

        #region GetAutomobile

        [TestMethod]
        public void GetAutomobile_ShouldReturnNull_GivenNonExistingVIN()
        {
            Assert.IsNull(_repo.GetAutomobile("non existing vin"));
        }

        [TestMethod]
        public void GetAutomobile_ShouldReturnCorrectAutomobile_GivenExistingVIN1()
        {
            var vin = "BlackTruck1";

            var auto = _repo.GetAutomobile(vin);

            Assert.IsNotNull(auto);
            Assert.AreEqual(vin, auto.VIN);
            Assert.AreEqual(5000, auto.Odometer);
            Assert.AreEqual("Dodge", auto.Make);
            Assert.AreEqual("Heavy Duty", auto.Model);
            Assert.AreEqual(2013, auto.Year);
        }

        [TestMethod]
        public void GetAutomobile_ShouldReturnCorrectAutomobile_GivenExistingVIN2()
        {
            var vin = "GreyCar1";

            var auto = _repo.GetAutomobile(vin);

            Assert.IsNotNull(auto);
            Assert.AreEqual(vin, auto.VIN);
            Assert.AreEqual("Volkswagon", auto.Make);
            Assert.AreEqual("Passat", auto.Model);
            Assert.AreEqual(2009, auto.Year);
        }

        [TestMethod]
        public void GetAutomobile_ShouldReturnCorrectAutomobile_GivenExistingVinButDifferentVinCase()
        {
            var vin = "BlackTruck1";

            var auto = _repo.GetAutomobile(vin);
            Assert.IsNotNull(auto);
            Assert.IsTrue(vin.Equals(auto.VIN, System.StringComparison.InvariantCultureIgnoreCase));
        }

        #endregion
        #region GetAutomobiles tests

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
            var autos = _repo.GetAutomobiles();

            Assert.IsNotNull(autos);

            var automobile1 = _repo.GetAutomobile("BlackTruck1");
            Assert.IsNotNull(automobile1);
            Assert.AreEqual(autos[0].VIN, automobile1.VIN);
            Assert.AreEqual(autos[0].Odometer, automobile1.Odometer);
            Assert.AreEqual(autos[0].Make, automobile1.Make);
            Assert.AreEqual(autos[0].Model, automobile1.Model);
            Assert.AreEqual(autos[0].Year, automobile1.Year);

            var automobile2 = _repo.GetAutomobile("GreyCar1");
            Assert.IsNotNull(automobile2);
            Assert.AreEqual(autos[1].VIN, automobile2.VIN);
            Assert.AreEqual(autos[1].Odometer, automobile2.Odometer);
            Assert.AreEqual(autos[1].Make, automobile2.Make);
            Assert.AreEqual(autos[1].Model, automobile2.Model);
            Assert.AreEqual(autos[1].Year, automobile2.Year);
        }

        #endregion
        #region InsertAutomobile tests

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
            _repo.InsertAutomobile(new DieselAutomobile());
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void InsertAutomobile_ShouldThrowArugumentException_GivenAutoWithEmptyVIN()
        {
            _repo.InsertAutomobile(new DieselAutomobile() { VIN = string.Empty });
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void InsertAutomobile_ShouldThrowArugumentException_GivenAutoWithWhitespaceVIN()
        {
            _repo.InsertAutomobile(new DieselAutomobile() { VIN = "   " });
        }

        [TestMethod]
        public void InsertAutomobile_ShouldAllowInsertingAutomobile()
        {
            _repo.InsertAutomobile(new DieselAutomobile() { VIN = "111" });
        }

        [TestMethod]
        public void InsertAutomobile_ShouldStoreAutomobile()
        {
            var expectedAuto = new DieselAutomobile() { VIN = "1234", Odometer = 234, Make = "make it", Model = "model", Year = 1 };
            _repo.InsertAutomobile(expectedAuto);

            var actualAuto = _repo.GetAutomobile(expectedAuto.VIN);

            Assert.IsNotNull(actualAuto);
            Assert.AreEqual(expectedAuto.VIN, actualAuto.VIN);
            Assert.AreEqual(expectedAuto.Odometer, actualAuto.Odometer);
            Assert.AreEqual(expectedAuto.Make, actualAuto.Make);
            Assert.AreEqual(expectedAuto.Model, actualAuto.Model);
            Assert.AreEqual(expectedAuto.Year, actualAuto.Year);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException), "Duplicate VIN is not allowed")]
        public void InsertAutomobile_ShouldThrowArgumentExcption_GivenAutoWithDuplicateVIN()
        {
            var expectedAuto = new DieselAutomobile() { VIN = "5555" };
            _repo.InsertAutomobile(expectedAuto);
            _repo.InsertAutomobile(expectedAuto);

            _repo.GetAutomobile(expectedAuto.VIN);
        }

        [TestMethod]
        public void AutomobileRepository_ShouldRetainListOfAutos_GivenMultipleInstances()
        {
            var expectedAuto = new DieselAutomobile() { VIN = "1111" };
            _repo.InsertAutomobile(expectedAuto);

            var repo2 = new DieselAutomobileRepository();

            var actualAuto = repo2.GetAutomobile(expectedAuto.VIN);

            Assert.IsNotNull(actualAuto);
            Assert.AreEqual(expectedAuto.VIN, actualAuto.VIN);
        }

        [TestMethod]
        public void GetAutomobiles_ShouldReturn_InsertedAutomobile()
        {
            var expectedAuto = new DieselAutomobile() { VIN = "9911" };
            _repo.InsertAutomobile(expectedAuto);

            var autos = _repo.GetAutomobiles();
            var actualAuto = autos.FirstOrDefault(a => a.VIN == expectedAuto.VIN);

            Assert.IsNotNull(actualAuto);
            Assert.AreEqual(expectedAuto.VIN, actualAuto.VIN);
        }

        #endregion
        #region delete tests

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException), "invalid VIN")]
        public void DeleteAutomobile_ShouldThrowException_GivenNull()
        {
            _repo.DeleteAutomobile(null);
            _repo.DeleteAutomobile(string.Empty);
            _repo.DeleteAutomobile("    ");
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException), "invalid VIN")]
        public void DeleteAutomobile_ShouldThrowException_GivenEmpty()
        {
            _repo.DeleteAutomobile(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException), "invalid VIN")]
        public void DeleteAutomobile_ShouldThrowException_GivenWhitespace()
        {
            _repo.DeleteAutomobile("    ");
        }

        [TestMethod]
        public void DeleteAutomobile_ShouldDeleteExistingAuto()
        {
            var existingAuto = new DieselAutomobile() { VIN = "vin for deletion" };
            _repo.InsertAutomobile(existingAuto);

            _repo.DeleteAutomobile(existingAuto.VIN);

            var actuaAuto = _repo.GetAutomobile(existingAuto.VIN);
            Assert.IsNull(actuaAuto);
        }

        [TestMethod]
        public void DeleteAutomobile_ShouldDeleteExistingAuto_GivenDifferentCaseOfVin()
        {
            var existingAuto = new DieselAutomobile() { VIN = "UPPER CASE VIN FOR DELETE" };
            _repo.InsertAutomobile(existingAuto);

            _repo.DeleteAutomobile(existingAuto.VIN.ToLower());

            var actuaAuto = _repo.GetAutomobile(existingAuto.VIN);
            Assert.IsNull(actuaAuto);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException), "VIN does not exist")]
        public void DeleteAutomobile_ShouldThrowArugumentException_GivenNonExstingId()
        {
            _repo.DeleteAutomobile("non existing vin");
        }

        #endregion
    }
}
