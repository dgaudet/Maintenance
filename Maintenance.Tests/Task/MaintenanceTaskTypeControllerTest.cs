using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Http.Results;
using System.Web.Http;
using System.Collections.Generic;
using Maintenance.Models;
using System;
using Maintenance.Vehicle;
using Maintenance.Task.Controllers;
using Maintenance.Task.Models;

namespace Maintenance.Tests.Task
{
    [TestClass]
    public class MaintenanceTaskTypeControllerTest
    {
        Mock<IMaintenanceTypeService> _mockRepo;

        public MaintenanceTaskTypeControllerTest()
        {
            _mockRepo = new Mock<IMaintenanceTypeService>();
        }

        [TestMethod]
        public void GetMaintenanceTaskTypes_ShouldCallService_WithCorrectVin()
        {
            var controller = new MaintenanceTaskTypeController(_mockRepo.Object);
            var id = "1";

            controller.GetMaintenanceTaskTypes(id);

            _mockRepo.Verify(m => m.TaskTypesForAutomobile(id));
        }

        [TestMethod]
        public void GetMaintenanceTaskTypes_ShouldReturnNotFound_GivenNullReturnedFromService()
        {
            var controller = new MaintenanceTaskTypeController(_mockRepo.Object);
            var id = "1";
            _mockRepo.Setup(m => m.TaskTypesForAutomobile(id)).Returns((List<TaskTypeModel>)null);

            IHttpActionResult result = controller.GetMaintenanceTaskTypes(id);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetMaintenanceTaskTypes_ShouldReturnNotFound_GivenNoTaskTypeReturnedFromService()
        {
            var controller = new MaintenanceTaskTypeController(_mockRepo.Object);
            var id = "1";
            _mockRepo.Setup(m => m.TaskTypesForAutomobile(id)).Returns(new List<TaskTypeModel>());

            IHttpActionResult result = controller.GetMaintenanceTaskTypes(id);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetMaintenanceTaskTypes_ShouldReturnTaskTypes_GivenTaskTypesReturnedFromService()
        {
            var id = "1";
            var taskTypes = new List<TaskTypeModel>();
            taskTypes.Add(new TaskTypeModel(TaskType.BatteryPackReplacement));
            taskTypes.Add(new TaskTypeModel(TaskType.GlowPlugReplacement));
            var controller = new MaintenanceTaskTypeController(_mockRepo.Object);
            _mockRepo.Setup(m => m.TaskTypesForAutomobile(id)).Returns(taskTypes);

            IHttpActionResult actionResult = controller.GetMaintenanceTaskTypes(id);
            var result = actionResult as OkNegotiatedContentResult<IEnumerable<TaskTypeModel>>;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(taskTypes, result.Content);
        }

        [TestMethod]
        public void GetMaintenanceTaskTypes_ShouldReturnExceptionRequest_GivenServiceThrows()
        {
            var controller = new MaintenanceTaskTypeController(_mockRepo.Object);
            _mockRepo.Setup(a => a.TaskTypesForAutomobile(It.IsAny<string>())).Throws(new Exception("boom"));

            IHttpActionResult result = controller.GetMaintenanceTaskTypes("vin");

            Assert.IsInstanceOfType(result, typeof(ExceptionResult));
        }
    }
}
