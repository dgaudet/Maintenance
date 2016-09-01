using System.Collections.Generic;
using Maintenance.Models;
using Maintenance.Task.Models;

namespace Maintenance.Vehicle
{
    public interface IMaintenanceTypeService
    {
        IEnumerable<TaskTypeModel> TaskTypesForAutomobile(string vin);
    }

    public class IMaintenanceTypeServiceFactory
    {
        public static IMaintenanceTypeService Create()
        {
            var dieselRepo = new DieselAutomobileRepository();
            var electricRepo = new ElectricAutomobileRepository();
            var gasRepo = new GasAutomobileRepository();
            return new MaintenanceTypeService(dieselRepo, electricRepo, gasRepo);
        }
    }
}