using System;
using System.Collections.Generic;
using Maintenance.Models;

namespace Maintenance
{
    public class MaintenanceTaskRepository : IMaintenanceTaskRepository
    {
        public MaintenanceTask GetTask(int id)
        {
            if (id == 1)
            {
                return new MaintenanceTask { Id = 1, Name = "Oil Change", Odometer = 5000, Date = DateTime.Now.AddMonths(-2) };
            }
            if (id == 2)
            {
                return new MaintenanceTask { Id = 2, Name = "Oil Change", Odometer = 10000, Date = DateTime.Now.AddMonths(-1) };
            }
            return null;
        }

        public List<MaintenanceTask> GetMaintenanceTasks()
        {
            var tasks = new List<MaintenanceTask>();
            tasks.Add(GetTask(1));
            tasks.Add(GetTask(2));
            return tasks;
        }
    }
}