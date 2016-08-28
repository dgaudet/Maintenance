using System;
using System.Collections.Generic;
using System.Web.Http;
using Maintenance.Models;
using System.Net;
using System.Linq;

namespace Maintenance.Controllers
{
    public class MaintenanceTaskController : ApiController
    {
        private IMaintenanceTaskRepository _repository;

        public MaintenanceTaskController()
        {
            _repository = new MaintenanceTaskRepository();
        }

        public MaintenanceTaskController(IMaintenanceTaskRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<MaintenanceTask> GetAllMaintenanceTasks()
        {
            var tasks =_repository.GetMaintenanceTasks();
            if (tasks == null)
            {
                return new List<MaintenanceTask>();
            }
            return tasks;
        }

        public IHttpActionResult GetMaintenanceTask(int id)
        {
            var task = _repository.GetTask(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        public IHttpActionResult PostMaintenanceTask(MaintenanceTask newTask)
        {
            if (newTask == null)
            {
                return BadRequest();
            }
            try {
                _repository.InsertMaintenanceTask(newTask);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Content(HttpStatusCode.Accepted, newTask);
        }

        public IEnumerable<MaintenanceTask> GetMaintenanceTasks(string vin)
        {
            var tasks = _repository.GetMaintenanceTasks(vin).ToList();
            if (tasks.Count == 0)
            {
                return new List<MaintenanceTask>();
            }
            return tasks;
        }
    }
}
