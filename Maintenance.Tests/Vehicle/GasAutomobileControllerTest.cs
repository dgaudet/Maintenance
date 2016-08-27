using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maintenance.Vehicle;
using Maintenance.Vehicle.Models;
using Maintenance.Vehicle.Controllers;
using Moq;
using System.Web.Http;
using System.Web.Http.Results;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System;

namespace Maintenance.Tests.Vehicle
{
    [TestClass]
    public class GasAutomobileControllerTest
    {
        Mock<IGasAutomobileRepository> _mockRepo;

        public GasAutomobileControllerTest()
        {
            _mockRepo = new Mock<IGasAutomobileRepository>();
        }

        [TestMethod]
        public void GetAutomobile_ShouldCallRepository_GetAutomobileWithCorrectVIN()
        {
            var _mockRepo = new Mock<IGasAutomobileRepository>();
            var controller = new GasAutomobileController(_mockRepo.Object);
            var VIN = "123";

            controller.GetAutomobile(VIN);

            _mockRepo.Verify(m => m.GetAutomobile(VIN));
        }

        [TestMethod]
        public void GetAutomobile_ShouldReturnNotFound_GivenNoAutoReturnedFromRepo()
        {
            var controller = new GasAutomobileController(_mockRepo.Object);
            var vin = "1";
            _mockRepo.Setup(m => m.GetAutomobile(vin)).Returns((GasAutomobile)null);

            IHttpActionResult result = controller.GetAutomobile(vin);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetAutomobile_ShouldReturnAuto_GivenAutoReturnedFromRepo()
        {
            var vin = "1";
            var auto = new GasAutomobile() { VIN = vin };
            var controller = new GasAutomobileController(_mockRepo.Object);
            _mockRepo.Setup(m => m.GetAutomobile(vin)).Returns(auto);

            IHttpActionResult actionResult = controller.GetAutomobile(vin);
            var result = actionResult as OkNegotiatedContentResult<GasAutomobile>;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(auto, result.Content);
        }

        [TestMethod]
        public void GetAllAutomobiles_ShouldCallRepositoryGetAutomobiles()
        {
            var controller = new GasAutomobileController(_mockRepo.Object);

            controller.GetAllAutomobiles();

            _mockRepo.Verify(m => m.GetAutomobiles());
        }

        [TestMethod]
        public void GetAllAutomobiles_ShouldReturnEmptyList_GivenNoAutosReturnedFromRepo()
        {
            var controller = new GasAutomobileController(_mockRepo.Object);
            _mockRepo.Setup(m => m.GetAutomobiles()).Returns((List<GasAutomobile>)null);

            var result = controller.GetAllAutomobiles();

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void GetAllAutomobiles_ShouldReturnTask_GivenAutosReturnedFromRepo()
        {
            var vin = "1";
            var auto = new GasAutomobile() { VIN = vin };
            var tasks = new List<GasAutomobile>();
            tasks.Add(auto);
            var controller = new GasAutomobileController(_mockRepo.Object);
            _mockRepo.Setup(m => m.GetAutomobiles()).Returns(tasks);

            var result = controller.GetAllAutomobiles();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(auto, result.First());
        }

        [TestMethod]
        public void PutAutomobile_ShouldCallRepository_InsertAutomobileWithCorrectVIN()
        {
            var _mockRepo = new Mock<IGasAutomobileRepository>();
            var controller = new GasAutomobileController(_mockRepo.Object);
            var newAuto = new GasAutomobile() { VIN = "123" };

            controller.PutAutomobile(newAuto);

            _mockRepo.Verify(m => m.InsertAutomobile(newAuto));
        }

        [TestMethod]
        public void PutAutomobile_ShouldReturnBadRequest_GivenNull()
        {
            var controller = new GasAutomobileController(_mockRepo.Object);
            _mockRepo.Setup(a => a.InsertAutomobile(It.IsAny<GasAutomobile>())).Throws(new Exception("should not be called"));

            IHttpActionResult result = controller.PutAutomobile(null);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void PutAutomobile_ShouldReturnExceptionRequest_GivenRepositoryThrows()
        {
            var controller = new GasAutomobileController(_mockRepo.Object);
            _mockRepo.Setup(a => a.InsertAutomobile(It.IsAny<GasAutomobile>())).Throws(new Exception("boom"));

            IHttpActionResult result = controller.PutAutomobile(new GasAutomobile());

            Assert.IsInstanceOfType(result, typeof(ExceptionResult));
        }

        [TestMethod]
        public void PutAutomobile_ShouldReturnContentResult_GivenAutoSaved()
        {
            var expectedAuto = new GasAutomobile() { VIN = "1" };
            var controller = new GasAutomobileController(_mockRepo.Object);

            IHttpActionResult actionResult = controller.PutAutomobile(expectedAuto);
            var result = actionResult as NegotiatedContentResult<GasAutomobile>;

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.Accepted, result.StatusCode);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(expectedAuto.VIN, result.Content.VIN);
        }
    }
}
