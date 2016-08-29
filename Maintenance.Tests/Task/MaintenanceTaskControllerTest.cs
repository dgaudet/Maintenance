using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maintenance.Controllers;
using Moq;
using System.Web.Http.Results;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using Maintenance.Models;
using System;
using System.Net;

namespace Maintenance.Tests.Task
{
    [TestClass]
    public class MaintenanceTaskControllerTest
    {
        Mock<IMaintenanceTaskRepository> _mockRepo;

        public MaintenanceTaskControllerTest()
        {
            _mockRepo = new Mock<IMaintenanceTaskRepository>();
        }

        [TestMethod]
        public void GetMaintenanceTask_ShouldCallRepository_GetTaskWithCorrectId()
        {
            var controller = new MaintenanceTaskController(_mockRepo.Object);
            var id = 1;

            controller.GetMaintenanceTask(id);

            _mockRepo.Verify(m => m.GetTask(id));
        }

        [TestMethod]
        public void GetMaintenanceTask_ShouldReturnNotFound_GivenNoTaskReturnedFromRepo()
        {
            var controller = new MaintenanceTaskController(_mockRepo.Object);
            var id = 1;
            _mockRepo.Setup(m => m.GetTask(id)).Returns((MaintenanceTask)null);

            IHttpActionResult result = controller.GetMaintenanceTask(id);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetMaintenanceTask_ShouldReturnTask_GivenTaskReturnedFromRepo()
        {
            var id = 1;
            var task = new MaintenanceTask() { Id = id};
            var controller = new MaintenanceTaskController(_mockRepo.Object);
            _mockRepo.Setup(m => m.GetTask(id)).Returns(task);

            IHttpActionResult actionResult = controller.GetMaintenanceTask(id);
            var result = actionResult as OkNegotiatedContentResult<MaintenanceTask>;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(task, result.Content);
        }

        [TestMethod]
        public void GetAllMaintenanceTasks_ShouldCallRepositoryGetMaintanenceTasks()
        {
            var controller = new MaintenanceTaskController(_mockRepo.Object);

            controller.GetAllMaintenanceTasks();

            _mockRepo.Verify(m => m.GetMaintenanceTasks());
        }

        [TestMethod]
        public void GetAllMaintenanceTasks_ShouldReturnEmptyList_GivenNoTasksReturnedFromRepo()
        {
            var controller = new MaintenanceTaskController(_mockRepo.Object);
            _mockRepo.Setup(m => m.GetMaintenanceTasks()).Returns((List<MaintenanceTask>)null);

            var result = controller.GetAllMaintenanceTasks();

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void GetAllMaintenanceTasks_ShouldReturnTask_GivenTaskReturnedFromRepo()
        {
            var id = 1;
            var task = new MaintenanceTask() { Id = id };
            var tasks = new List<MaintenanceTask>();
            tasks.Add(task);
            var controller = new MaintenanceTaskController(_mockRepo.Object);
            _mockRepo.Setup(m => m.GetMaintenanceTasks()).Returns(tasks);

            var result = controller.GetAllMaintenanceTasks();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(task, result.First());
        }

        [TestMethod]
        public void PostMaintenanceTask_ShouldCallRepository_InsertTask()
        {
            var _mockRepo = new Mock<IMaintenanceTaskRepository>();
            var controller = new MaintenanceTaskController(_mockRepo.Object);
            var newAuto = new MaintenanceTask() { Id = 1 };

            controller.PostMaintenanceTask(newAuto);

            _mockRepo.Verify(m => m.InsertMaintenanceTask(newAuto));
        }

        [TestMethod]
        public void PostMaintenanceTask_ShouldReturnBadRequest_GivenNull()
        {
            var controller = new MaintenanceTaskController(_mockRepo.Object);
            _mockRepo.Setup(a => a.InsertMaintenanceTask(It.IsAny<MaintenanceTask>())).Throws(new Exception("should not be called"));

            IHttpActionResult result = controller.PostMaintenanceTask(null);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void PostMaintenanceTask_ShouldReturnExceptionRequest_GivenRepositoryThrows()
        {
            var controller = new MaintenanceTaskController(_mockRepo.Object);
            _mockRepo.Setup(a => a.InsertMaintenanceTask(It.IsAny<MaintenanceTask>())).Throws(new Exception("boom"));

            IHttpActionResult result = controller.PostMaintenanceTask(new MaintenanceTask());

            Assert.IsInstanceOfType(result, typeof(ExceptionResult));
        }

        [TestMethod]
        public void PostMaintenanceTask_ShouldReturnContentResult_GivenTaskSaved()
        {
            var expectedAuto = new MaintenanceTask() { VIN = "1" };
            var controller = new MaintenanceTaskController(_mockRepo.Object);

            IHttpActionResult actionResult = controller.PostMaintenanceTask(expectedAuto);
            var result = actionResult as NegotiatedContentResult<MaintenanceTask>;

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.Accepted, result.StatusCode);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(expectedAuto.VIN, result.Content.VIN);
        }

        [TestMethod]
        public void GetMaintenanceTasks_ShouldCallRepository_GetTasksWithCorrectVIN()
        {
            var controller = new MaintenanceTaskController(_mockRepo.Object);
            var id = "1";

            controller.GetMaintenanceTasks(id);

            _mockRepo.Verify(m => m.GetMaintenanceTasks(id));
        }

        [TestMethod]
        public void GetMaintenanceTasks_ShouldReturnEmptyList_GivenNoTasksReturnedFromRepo()
        {
            var controller = new MaintenanceTaskController(_mockRepo.Object);
            var id = "1";
            _mockRepo.Setup(m => m.GetMaintenanceTasks(id)).Returns(new List<MaintenanceTask>());

            var result = controller.GetMaintenanceTasks(id);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void GetMaintenanceTasks_ShouldReturnTasks_GivenTaskReturnedFromRepo()
        {
            var vin = "1";
            var controller = new MaintenanceTaskController(_mockRepo.Object);
            var tasks = new List<MaintenanceTask>();
            var task = new MaintenanceTask() { Id = 1, VIN = vin };
            tasks.Add(task);
            _mockRepo.Setup(m => m.GetMaintenanceTasks(vin)).Returns(tasks);

            var actualTasks = controller.GetMaintenanceTasks(vin);

            Assert.IsNotNull(actualTasks);
            Assert.AreEqual(1, actualTasks.Count());
            Assert.IsNotNull(tasks[0]);
            Assert.AreEqual(task, tasks[0]);
            
        }

        [TestMethod]
        public void DeleteMaintenanceTask_ShouldCallRepository_GivenTaskWithCorrectId()
        {
            var controller = new MaintenanceTaskController(_mockRepo.Object);
            var id = 1;

            controller.DeleteMaintenanceTask(id);

            _mockRepo.Verify(m => m.DeleteMaintenanceTask(id));
        }

        [TestMethod]
        public void DeleteMaintenanceTask_ShouldReturnExceptionRequest_GivenRepositoryThrows()
        {
            var controller = new MaintenanceTaskController(_mockRepo.Object);
            _mockRepo.Setup(a => a.DeleteMaintenanceTask(It.IsAny<int>())).Throws(new Exception("boom"));

            IHttpActionResult result = controller.DeleteMaintenanceTask(8);

            Assert.IsInstanceOfType(result, typeof(ExceptionResult));
        }

        [TestMethod]
        public void DeleteMaintenanceTask_ShouldReturnCorrectResult_GivenRepoDoesNotThrow()
        {
            var controller = new MaintenanceTaskController(_mockRepo.Object);
            var id = 1;

            var actionResult = controller.DeleteMaintenanceTask(id);

            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }
    }
}
