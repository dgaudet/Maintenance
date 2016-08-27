using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maintenance.Vehicle;
using Maintenance.Vehicle.Models;
using Maintenance.Vehicle.Controllers;
using Moq;
using System.Web.Http;
using System.Web.Http.Results;
using System.Collections.Generic;
using System.Linq;

namespace Maintenance.Tests.Vehicle
{
    [TestClass]
    public class ElectricAutomobileControllerTest
    {
        Mock<IElectricAutomobileRepository> _mockRepo;

        public ElectricAutomobileControllerTest()
        {
            _mockRepo = new Mock<IElectricAutomobileRepository>();
        }

        [TestMethod]
        public void GetAutomobile_ShouldCallRepository_GetAutomobileWithCorrectId()
        {
            var _mockRepo = new Mock<IElectricAutomobileRepository>();
            var controller = new ElectricAutomobileController(_mockRepo.Object);
            var id = 1;

            controller.GetAutomobile(id);

            _mockRepo.Verify(m => m.GetAutomobile(id));
        }

        [TestMethod]
        public void GetAutomobile_ShouldReturnNotFound_GivenNoAutoReturnedFromRepo()
        {
            var controller = new ElectricAutomobileController(_mockRepo.Object);
            var id = 1;
            _mockRepo.Setup(m => m.GetAutomobile(id)).Returns((ElectricAutomobile)null);

            IHttpActionResult result = controller.GetAutomobile(id);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetAutomobile_ShouldReturnAuto_GivenAutoReturnedFromRepo()
        {
            var id = 1;
            var auto = new ElectricAutomobile() { Id = id };
            var controller = new ElectricAutomobileController(_mockRepo.Object);
            _mockRepo.Setup(m => m.GetAutomobile(id)).Returns(auto);

            IHttpActionResult actionResult = controller.GetAutomobile(id);
            var result = actionResult as OkNegotiatedContentResult<ElectricAutomobile>;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(auto, result.Content);
        }

        [TestMethod]
        public void GetAllAutomobiles_ShouldCallRepositoryGetAutomobiles()
        {
            var controller = new ElectricAutomobileController(_mockRepo.Object);

            controller.GetAllAutomobiles();

            _mockRepo.Verify(m => m.GetAutomobiles());
        }

        [TestMethod]
        public void GetAllAutomobiles_ShouldReturnEmptyList_GivenNoAutosReturnedFromRepo()
        {
            var controller = new ElectricAutomobileController(_mockRepo.Object);
            _mockRepo.Setup(m => m.GetAutomobiles()).Returns((List<ElectricAutomobile>)null);

            var result = controller.GetAllAutomobiles();

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void GetAllAutomobiles_ShouldReturnTask_GivenAutosReturnedFromRepo()
        {
            var id = 1;
            var auto = new ElectricAutomobile() { Id = id };
            var tasks = new List<ElectricAutomobile>();
            tasks.Add(auto);
            var controller = new ElectricAutomobileController(_mockRepo.Object);
            _mockRepo.Setup(m => m.GetAutomobiles()).Returns(tasks);

            var result = controller.GetAllAutomobiles();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(auto, result.First());
        }
    }
}
