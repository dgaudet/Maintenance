using System;
using System.Collections.Generic;
using Maintenance.Models;
using System.Linq;

namespace Maintenance
{
    public class MaintenanceTaskRepository : IMaintenanceTaskRepository
    {
        static List<MaintenanceTask> _storedTasks;

        public MaintenanceTaskRepository()
        {
            if (_storedTasks == null)
            {
                _storedTasks = new List<MaintenanceTask>();
                InsertMaintenanceTask(new MaintenanceTask { Id = 1, VIN = "RedCar1", Name = "Oil Change", Odometer = 5000, Date = DateTime.Now.AddMonths(-2) });
                InsertMaintenanceTask(new MaintenanceTask { Id = 2, VIN = "BlueCar1", Name = "Oil Change", Odometer = 10000, Date = DateTime.Now.AddMonths(-1) });
            }
        }

        public MaintenanceTask GetTask(int id)
        {
            return _storedTasks.FirstOrDefault(t => t.Id == id);
        }

        public List<MaintenanceTask> GetMaintenanceTasks()
        {
            return _storedTasks;
        }

        public void InsertMaintenanceTask(MaintenanceTask task)
        {
            if (task == null || task.VIN == null)
            {
                throw new ArgumentException();
            }
            var existingTask = GetTask(task.Id);
            if (existingTask != null)
            {
                throw new ArgumentException("Duplicate VIN is not allowed");
            }
            _storedTasks.Add(task);
        }
    }
}