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
                InsertMaintenanceTask(new MaintenanceTask { Id = 1, VIN = "RedCar1", Name = "Oil Change", Odometer = 5000, Date = DateTime.Now.AddMonths(-2), type = TaskType.OilChange });
                InsertMaintenanceTask(new MaintenanceTask { Id = 2, VIN = "BlueCar1", Name = "Oil Change", Odometer = 10000, Date = DateTime.Now.AddMonths(-1), type = TaskType.TireRotation });
            }
        }

        public MaintenanceTask GetTask(int id)
        {
            return _storedTasks.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<MaintenanceTask> GetMaintenanceTasks(string vin)
        {
            return _storedTasks.Where(t => t.VIN.Equals(vin, StringComparison.InvariantCultureIgnoreCase));
        }

        public List<MaintenanceTask> GetMaintenanceTasks()
        {
            return _storedTasks;
        }

        public void InsertMaintenanceTask(MaintenanceTask task)
        {
            if (task == null || string.IsNullOrWhiteSpace(task.VIN) || task.type == TaskType.Invalid)
            {
                throw new ArgumentException("Invalid task, either task is null, vin is invalid, or task type is invalid");
            }
            var existingTask = GetTask(task.Id);
            if (existingTask != null)
            {
                throw new ArgumentException("Duplicate id is not allowed");
            }
            _storedTasks.Add(task);
        }

        public void DeleteMaintenanceTask(int id)
        {
            var task = GetTask(id);
            if (task == null)
            {
                throw new ArgumentException();
            }
            _storedTasks.Remove(task);
        }
    }
}