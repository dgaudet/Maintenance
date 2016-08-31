using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maintenance.Vehicle;
using Moq;
using Maintenance.Vehicle.Models;
using System.Linq;
using Maintenance.Models;

namespace Maintenance.Tests.Vehicle
{
    [TestClass]
    public class MaintenanceTypeServiceTest
    {
        Mock<IDieselAutomobileRepository> _mockDieselRepo;
        Mock<IElectricAutomobileRepository> _mockElectricRepo;
        Mock<IGasAutomobileRepository> _mockGasRepo;

        MaintenanceTypeService _service;

        public MaintenanceTypeServiceTest()
        {
            _mockDieselRepo = new Mock<IDieselAutomobileRepository>();
            _mockElectricRepo = new Mock<IElectricAutomobileRepository>();
            _mockGasRepo = new Mock<IGasAutomobileRepository>();

            _service = new MaintenanceTypeService(_mockDieselRepo.Object, _mockElectricRepo.Object, _mockGasRepo.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TaskTypesForAutomobile_shouldThrowArgumentException_GivenNull()
        {
            _service.TaskTypesForAutomobile(null);
        }

        [TestMethod]
        public void TaskTypesForAutomobile_shouldReturnCorrectTypes_ForDieselVin()
        {
            var vin = "diesel vin";
            _mockDieselRepo.Setup(x => x.GetAutomobile(vin)).Returns(new DieselAutomobile());

            var actualTypes = _service.TaskTypesForAutomobile(vin);

            Assert.IsNotNull(actualTypes);
            Assert.AreEqual(3, actualTypes.Count());
            Assert.IsTrue(actualTypes.Contains(TaskType.OilChange));
            Assert.IsTrue(actualTypes.Contains(TaskType.GlowPlugReplacement));
            Assert.IsTrue(actualTypes.Contains(TaskType.TireRotation));
        }

        [TestMethod]
        public void TaskTypesForAutomobile_shouldReturnCorrectTypes_ForElectricVin()
        {
            var vin = "Electric vin";
            _mockElectricRepo.Setup(x => x.GetAutomobile(vin)).Returns(new ElectricAutomobile());

            var actualTypes = _service.TaskTypesForAutomobile(vin);

            Assert.IsNotNull(actualTypes);
            Assert.AreEqual(3, actualTypes.Count());
            Assert.IsTrue(actualTypes.Contains(TaskType.OilChange));
            Assert.IsTrue(actualTypes.Contains(TaskType.TireRotation));
            Assert.IsTrue(actualTypes.Contains(TaskType.BatteryPackReplacement));
        }

        [TestMethod]
        public void TaskTypesForAutomobile_shouldReturnCorrectTypes_ForGasVin()
        {
            var vin = "gas vin";
            _mockGasRepo.Setup(x => x.GetAutomobile(vin)).Returns(new GasAutomobile());

            var actualTypes = _service.TaskTypesForAutomobile(vin);

            Assert.IsNotNull(actualTypes);
            Assert.AreEqual(3, actualTypes.Count());
            Assert.IsTrue(actualTypes.Contains(TaskType.OilChange));
            Assert.IsTrue(actualTypes.Contains(TaskType.TireRotation));
            Assert.IsTrue(actualTypes.Contains(TaskType.SparkPlugReplacement));
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TaskTypesForAutomobile_shouldThrowArgumentException_GivenEmptyString()
        {
            _service.TaskTypesForAutomobile(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TaskTypesForAutomobile_shouldThrowArgumentException_GivenWhitespace()
        {
            _service.TaskTypesForAutomobile("   ");
        }

        [TestMethod]
        public void TaskTypesForAutomobile_shouldReturnEmptyListOfTypes_ForNoMatchingVin()
        {
            var vin = "gas vin";
            _mockGasRepo.Setup(x => x.GetAutomobile(vin)).Returns((GasAutomobile)null);
            _mockElectricRepo.Setup(x => x.GetAutomobile(vin)).Returns((ElectricAutomobile)null);
            _mockDieselRepo.Setup(x => x.GetAutomobile(vin)).Returns((DieselAutomobile)null);

            var actualTypes = _service.TaskTypesForAutomobile(vin);

            Assert.IsNotNull(actualTypes);
            Assert.AreEqual(0, actualTypes.Count());
        }
    }
}
