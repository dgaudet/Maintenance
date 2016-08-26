using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maintenance;

namespace Maintenance.Tests.MaintenanceTask
{
    [TestClass]
    public class MaintenanceTaskRepositoryTest
    {
        MaintenanceTaskRepository _repo;

        public MaintenanceTaskRepositoryTest()
        {
            _repo = new MaintenanceTaskRepository();
        }

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
            Assert.AreEqual(task.Name, "Oil Change");
            Assert.AreEqual(task.Odometer, 10000);
            var OneMonthAgo = DateTime.Now.AddMonths(-1);
            Assert.AreEqual(task.Date.Date, OneMonthAgo.Date);
        }

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
    }
}
