using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Maintenance.Models;

namespace Maintenance.Controllers
{
    public class MaintenanceTaskController : ApiController
    {
        MaintenanceTask[] tasks = new MaintenanceTask[]
        {
            new MaintenanceTask {Id = 1, Name ="Oil Change", Date = DateTime.Now, Odometer = 5000 },
            new MaintenanceTask {Id = 2, Name ="Oil Change", Date = DateTime.Now, Odometer = 10000 },
            new MaintenanceTask {Id = 3, Name ="Oil Change", Date = DateTime.Now, Odometer = 15000 }
        };

        public IEnumerable<MaintenanceTask> GetAllMaintenanceTasks()
        {
            return tasks;
        }

        public IHttpActionResult GetMaintenanceTask(int id)
        {
            var task = tasks.FirstOrDefault((x) => x.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }
    }
}
