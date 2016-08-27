using System.Collections.Generic;
using System.Web.Http;
using Maintenance.Models;

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
    }
}
