using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maintenance.Vehicle;
using Maintenance.Vehicle.Models;
using Maintenance.Vehicle.Controllers;
using Moq;
using System.Web.Http;
using System.Web.Http.Results;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Maintenance.Tests.Vehicle
{
    [TestClass]
    public class DieselAutomobileControllerTest
    {
        Mock<IDieselAutomobileRepository> _mockRepo;

        public DieselAutomobileControllerTest()
        {
            _mockRepo = new Mock<IDieselAutomobileRepository>();
        }

        [TestMethod]
        public void GetAutomobile_ShouldCallRepository_GetAutomobileWithCorrectVin()
        {
            var _mockRepo = new Mock<IDieselAutomobileRepository>();
            var controller = new DieselAutomobileController(_mockRepo.Object);
            var vin = "1";

            controller.GetAutomobile(vin);

            _mockRepo.Verify(m => m.GetAutomobile(vin));
        }

        [TestMethod]
        public void GetAutomobile_ShouldReturnNotFound_GivenNoAutoReturnedFromRepo()
        {
            var controller = new DieselAutomobileController(_mockRepo.Object);
            var vin = "1";
            _mockRepo.Setup(m => m.GetAutomobile(vin)).Returns((DieselAutomobile)null);

            IHttpActionResult result = controller.GetAutomobile(vin);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetAutomobile_ShouldReturnAuto_GivenAutoReturnedFromRepo()
        {
            var vin = "1";
            var auto = new DieselAutomobile() { VIN = vin };
            var controller = new DieselAutomobileController(_mockRepo.Object);
            _mockRepo.Setup(m => m.GetAutomobile(vin)).Returns(auto);

            IHttpActionResult actionResult = controller.GetAutomobile(vin);
            var result = actionResult as OkNegotiatedContentResult<DieselAutomobile>;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(auto, result.Content);
        }

        [TestMethod]
        public void GetAllAutomobiles_ShouldCallRepositoryGetAutomobiles()
        {
            var controller = new DieselAutomobileController(_mockRepo.Object);

            controller.GetAllAutomobiles();

            _mockRepo.Verify(m => m.GetAutomobiles());
        }

        [TestMethod]
        public void GetAllAutomobiles_ShouldReturnEmptyList_GivenNoAutosReturnedFromRepo()
        {
            var controller = new DieselAutomobileController(_mockRepo.Object);
            _mockRepo.Setup(m => m.GetAutomobiles()).Returns((List<DieselAutomobile>)null);

            var result = controller.GetAllAutomobiles();

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void GetAllAutomobiles_ShouldReturnAuto_GivenAutosReturnedFromRepo()
        {
            var vin = "1";
            var auto = new DieselAutomobile() { VIN = vin };
            var autos = new List<DieselAutomobile>();
            autos.Add(auto);
            var controller = new DieselAutomobileController(_mockRepo.Object);
            _mockRepo.Setup(m => m.GetAutomobiles()).Returns(autos);

            var result = controller.GetAllAutomobiles();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(auto, result.First());
        }

        [TestMethod]
        public void PostAutomobile_ShouldCallRepository_InsertAutomobileWithCorrectVIN()
        {
            var _mockRepo = new Mock<IDieselAutomobileRepository>();
            var controller = new DieselAutomobileController(_mockRepo.Object);
            var newAuto = new DieselAutomobile() { VIN = "123" };

            controller.PostAutomobile(newAuto);

            _mockRepo.Verify(m => m.InsertAutomobile(newAuto));
        }

        [TestMethod]
        public void PostAutomobile_ShouldReturnBadRequest_GivenNull()
        {
            var controller = new DieselAutomobileController(_mockRepo.Object);
            _mockRepo.Setup(a => a.InsertAutomobile(It.IsAny<DieselAutomobile>())).Throws(new Exception("should not be called"));

            IHttpActionResult result = controller.PostAutomobile(null);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void PostAutomobile_ShouldReturnExceptionRequest_GivenRepositoryThrows()
        {
            var controller = new DieselAutomobileController(_mockRepo.Object);
            _mockRepo.Setup(a => a.InsertAutomobile(It.IsAny<DieselAutomobile>())).Throws(new Exception("boom"));

            IHttpActionResult result = controller.PostAutomobile(new DieselAutomobile());

            Assert.IsInstanceOfType(result, typeof(ExceptionResult));
        }

        [TestMethod]
        public void PostAutomobile_ShouldSetLocationHeader()
        {
            var controller = new DieselAutomobileController(_mockRepo.Object);
            var expectedAuto = new DieselAutomobile() { VIN = "1" };

            IHttpActionResult actionResult = controller.PostAutomobile(expectedAuto);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<DieselAutomobile>;

            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(expectedAuto.VIN, createdResult.RouteValues["id"]);
        }

        #region DeleteAutomobile tests

        [TestMethod]
        public void DeleteAutomobile_ShouldCallRepository_GivenAutoWithCorrectVIN()
        {
            var controller = new DieselAutomobileController(_mockRepo.Object);
            var vin = "1";

            controller.DeleteAutomobile(vin);

            _mockRepo.Verify(m => m.DeleteAutomobile(vin));
        }

        [TestMethod]
        public void DeleteAutomobile_ShouldReturnExceptionRequest_GivenRepositoryThrows()
        {
            var controller = new DieselAutomobileController(_mockRepo.Object);
            _mockRepo.Setup(a => a.DeleteAutomobile(It.IsAny<string>())).Throws(new Exception("boom"));

            IHttpActionResult result = controller.DeleteAutomobile("bad news");

            Assert.IsInstanceOfType(result, typeof(ExceptionResult));
        }

        [TestMethod]
        public void DeleteAutomobile_ShouldReturnCorrectResult_GivenDeleteDoesNotThrow()
        {
            var controller = new DieselAutomobileController(_mockRepo.Object);
            var vin = "1";

            var actionResult = controller.DeleteAutomobile(vin);

            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        #endregion
    }
}
