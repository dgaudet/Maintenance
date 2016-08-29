using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maintenance.Models;
using System.Linq;

namespace Maintenance.Tests.Task
{
    [TestClass]
    public class MaintenanceTaskRepositoryTest
    {
        MaintenanceTaskRepository _repo;

        public MaintenanceTaskRepositoryTest()
        {
            _repo = new MaintenanceTaskRepository();
        }

    #region GetMaintenanceTask

        [TestMethod]
        public void GetMaintenanceTask_ShouldReturnNull_GivenNonExistingId()
        {
            Assert.IsNull(_repo.GetTask(99));
        }

        [TestMethod]
        public void GetMaintenanceTask_ShouldReturnCorrectTask_GivenTaskId1()
        {
            var task = _repo.GetTask(1);
            Assert.IsNotNull(task);
            Assert.AreEqual(task.Id, 1);
            Assert.AreEqual(task.VIN, "RedCar1");
            Assert.AreEqual(task.Name, "Oil Change");
            Assert.AreEqual(task.Odometer, 5000);
            var TwoMonthsAgo = DateTime.Now.AddMonths(-2);
            Assert.AreEqual(task.Date.Date, TwoMonthsAgo.Date);
        }        

        [TestMethod]
        public void GetMaintenanceTask_ShouldReturnCorrectTask_GivenTaskId2()
        {
            var task = _repo.GetTask(2);
            Assert.IsNotNull(task);
            Assert.AreEqual(task.Id, 2);
            Assert.AreEqual(task.VIN, "BlueCar1");
            Assert.AreEqual(task.Name, "Oil Change");
            Assert.AreEqual(task.Odometer, 10000);
            var OneMonthAgo = DateTime.Now.AddMonths(-1);
            Assert.AreEqual(task.Date.Date, OneMonthAgo.Date);
        }

        #endregion
        #region GetMaintenanceTasks

        [TestMethod]
        public void GetMaintenanceTasks_ShouldReturnTwoTasks()
        {
            var tasks = _repo.GetMaintenanceTasks();
            Assert.IsNotNull(tasks);
            Assert.AreEqual(tasks.Count, 2);
        }

        [TestMethod]
        public void GetMaintenanceTasks_ShouldReturnTheSameTasksAsGetMaintenanceTask()
        {
            var tasks = _repo.GetMaintenanceTasks();
            Assert.IsNotNull(tasks);
            Assert.IsNotNull(tasks[0]);
            Assert.AreEqual(tasks[0].Id, _repo.GetTask(1).Id);
            Assert.AreEqual(tasks[0].Name, _repo.GetTask(1).Name);
            Assert.AreEqual(tasks[0].Date.Date, _repo.GetTask(1).Date.Date);
            Assert.AreEqual(tasks[0].Odometer, _repo.GetTask(1).Odometer);

            Assert.IsNotNull(tasks[1]);
            Assert.AreEqual(tasks[1].Id, _repo.GetTask(2).Id);
            Assert.AreEqual(tasks[1].Name, _repo.GetTask(2).Name);
            Assert.AreEqual(tasks[1].Date.Date, _repo.GetTask(2).Date.Date);
            Assert.AreEqual(tasks[1].Odometer, _repo.GetTask(2).Odometer);
        }

        #endregion
        #region InsertMaintenanceTask

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertMaintenanceTask_ShouldThrowArugumentException_GivenNull()
        {
            _repo.InsertMaintenanceTask(null);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void InsertMaintenanceTask_ShouldThrowArugumentException_GivenTaskWithNullVIN()
        {
            _repo.InsertMaintenanceTask(new MaintenanceTask() { Id = 343434 });
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void InsertMaintenanceTask_ShouldThrowArugumentException_GivenTaskWithEmptyVIN()
        {
            _repo.InsertMaintenanceTask(new MaintenanceTask() { Id = 44556734, VIN = string.Empty });
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void InsertMaintenanceTask_ShouldThrowArugumentException_GivenTaskWithWhitespaceVIN()
        {
            _repo.InsertMaintenanceTask(new MaintenanceTask() { Id = 665734, VIN = "  " });
        }

        [TestMethod]
        public void InsertMaintenanceTask_ShouldAllowInsertingTask()
        {
            _repo.InsertMaintenanceTask(new MaintenanceTask() { Id = 487834, VIN = "9977" });
        }

        [TestMethod]
        public void InsertMaintenanceTask_ShouldStoreTask()
        {
            var expectedTask = new MaintenanceTask() { Id = 5, VIN = "11233", Name = "Oil Change", Odometer = 5000, Date = DateTime.Now.AddMonths(-2) };
            _repo.InsertMaintenanceTask(expectedTask);

            var actuaTask = _repo.GetTask(expectedTask.Id);

            Assert.IsNotNull(actuaTask);
            Assert.AreEqual(expectedTask.VIN, actuaTask.VIN);
            Assert.AreEqual(expectedTask.Odometer, actuaTask.Odometer);
            Assert.AreEqual(expectedTask.Name, actuaTask.Name);
            Assert.AreEqual(expectedTask.Date, actuaTask.Date);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException), "Duplicate id is not allowed")]
        public void InsertMaintenanceTask_ShouldThrowArgumentExcption_GivenTaskWithDuplicateId()
        {
            var expectedTask = new MaintenanceTask() { Id = 9, VIN = "5555" };
            _repo.InsertMaintenanceTask(expectedTask);
            _repo.InsertMaintenanceTask(expectedTask);

            _repo.GetTask(expectedTask.Id);
        }

        [TestMethod]
        public void MaintenanceTaskRepository_ShouldRetainListOfTasks_GivenMultipleInstances()
        {
            var expectedTask = new MaintenanceTask() { Id = 33, VIN = "1111" };
            _repo.InsertMaintenanceTask(expectedTask);

            var repo2 = new MaintenanceTaskRepository();

            var actualtask = repo2.GetTask(expectedTask.Id);

            Assert.IsNotNull(actualtask);
            Assert.AreEqual(expectedTask.VIN, actualtask.VIN);
        }

        #endregion
        #region GetMaintenanceTasks

        [TestMethod]
        public void GetMaintenanceTasks_ShouldReturn_InsertedTask()
        {
            var expectedTask = new MaintenanceTask() { Id = 11, VIN = "1011" };
            _repo.InsertMaintenanceTask(expectedTask);

            var tasks = _repo.GetMaintenanceTasks();
            var actualtask = tasks.FirstOrDefault(a => a.VIN == expectedTask.VIN);

            Assert.IsNotNull(actualtask);
            Assert.AreEqual(expectedTask.VIN, actualtask.VIN);
        }

        [TestMethod]
        public void GetMaintenanceTasks_ShouldReturnEmptyEnumerable_GivenNonExistingVIN()
        {
            var enumerable = _repo.GetMaintenanceTasks("non existing vin");
            Assert.IsNotNull(enumerable);
            Assert.AreEqual(0, enumerable.Count());
        }

        [TestMethod]
        public void GetMaintenanceTasks_ShouldReturnCorrectTask_GivenVINWith1Task()
        {
            var expectedTask = new MaintenanceTask() { Id = 778, VIN = "11233a", Name = "Oil Change", Odometer = 5000, Date = DateTime.Now.AddMonths(-2) };
            _repo.InsertMaintenanceTask(expectedTask);

            var actualTasks = _repo.GetMaintenanceTasks(expectedTask.VIN);

            Assert.IsNotNull(actualTasks);
            Assert.AreEqual(1, actualTasks.Count());

            var actualTask = actualTasks.First();
            Assert.IsNotNull(actualTask);
            Assert.AreEqual(expectedTask.VIN, actualTask.VIN);
            Assert.AreEqual(expectedTask.Odometer, actualTask.Odometer);
            Assert.AreEqual(expectedTask.Name, actualTask.Name);
            Assert.AreEqual(expectedTask.Date.Date, actualTask.Date.Date);
        }

        [TestMethod]
        public void GetMaintenanceTasks_ShouldReturnCorrectTask_GivenExistingVinButDifferentVinCase()
        {
            var vin = "MULTIPLECaseVIN1";
            var expectedTask = new MaintenanceTask() { Id = 124, VIN = vin, Name = "Oil Change", Odometer = 5000, Date = DateTime.Now.AddMonths(-2) };
            _repo.InsertMaintenanceTask(expectedTask);

            var actualTasks = _repo.GetMaintenanceTasks(expectedTask.VIN.ToLower());

            Assert.IsNotNull(actualTasks);
            Assert.IsTrue(actualTasks.Count() == 1);

            var actualTask = actualTasks.First();
            Assert.IsNotNull(actualTask);
            Assert.AreEqual(expectedTask.VIN, actualTask.VIN);
        }

        [TestMethod]
        public void GetMaintenanceTasks_ShouldReturnCorrectTasks_GivenVINWithMultipleTasks()
        {
            var vin = "newVin11";
            var expectedTask1 = new MaintenanceTask() { Id = 99969, VIN = vin, Name = "Oil Change", Odometer = 5000, Date = DateTime.Now.AddMonths(-2) };
            _repo.InsertMaintenanceTask(expectedTask1);
            var expectedTask2 = new MaintenanceTask() { Id = 688886, VIN = vin, Name = "Oil Change", Odometer = 5000, Date = DateTime.Now.AddMonths(-2) };
            _repo.InsertMaintenanceTask(expectedTask2);

            var actualTasks = _repo.GetMaintenanceTasks(expectedTask1.VIN);

            var task1 = actualTasks.FirstOrDefault(t => t.Id == expectedTask1.Id);
            Assert.IsNotNull(task1);
            Assert.AreEqual(expectedTask1.Id, task1.Id);
            Assert.AreEqual(expectedTask1.VIN, task1.VIN);

            var task2 = actualTasks.FirstOrDefault(t => t.Id == expectedTask2.Id);
            Assert.IsNotNull(task2);
            Assert.AreEqual(expectedTask2.Id, task2.Id);
            Assert.AreEqual(expectedTask2.VIN, task2.VIN);
        }

        #endregion
        #region delete tests

        [TestMethod]
        public void DeleteMaintenanceTask_ShouldDeleteExistingTask()
        {
            var existingTask = new MaintenanceTask() { Id = 789977, VIN = "vin for deletion" };
            _repo.InsertMaintenanceTask(existingTask);

            _repo.DeleteMaintenanceTask(existingTask.Id);

            var actuaTask = _repo.GetTask(existingTask.Id);
            Assert.IsNull(actuaTask);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException), "Task id does not exist")]
        public void DeleteMaintenanceTask_ShouldThrowArugumentException_GivenNonExstingId()
        {
            _repo.DeleteMaintenanceTask(88);
        }

        #endregion
    }
}
