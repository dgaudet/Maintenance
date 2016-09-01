using System;
using System.Linq;
using System.Web.Http;
using Maintenance.Vehicle;

namespace Maintenance.Task.Controllers
{
    public class MaintenanceTaskTypeController : ApiController
    {
        private IMaintenanceTypeService _maintenanceTypeService;

        public MaintenanceTaskTypeController()
        {
            _maintenanceTypeService = IMaintenanceTypeServiceFactory.Create();
        }

        public MaintenanceTaskTypeController(IMaintenanceTypeService maintenanceTypeService)
        {
            _maintenanceTypeService = maintenanceTypeService;
        }

        public IHttpActionResult GetMaintenanceTaskTypes(string id)
        {
            try
            {
                var taskTypes = _maintenanceTypeService.TaskTypesForAutomobile(id);
                if (taskTypes == null || taskTypes.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(taskTypes);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            
            
        }
    }
}
