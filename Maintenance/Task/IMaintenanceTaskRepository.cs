using System.Collections.Generic;
using Maintenance.Models;

namespace Maintenance
{
    public interface IMaintenanceTaskRepository
    {
        List<MaintenanceTask> GetMaintenanceTasks();
        IEnumerable<MaintenanceTask> GetMaintenanceTasks(string vin);
        MaintenanceTask GetTask(int id);
        void InsertMaintenanceTask(MaintenanceTask task);
    }
}