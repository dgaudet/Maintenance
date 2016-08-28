using System.Collections.Generic;
using Maintenance.Models;

namespace Maintenance
{
    public interface IMaintenanceTaskRepository
    {
        List<MaintenanceTask> GetMaintenanceTasks();
        MaintenanceTask GetTask(int id);
    }
}