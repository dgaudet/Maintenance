using Maintenance.Models;
using Maintenance.Task.Models;
using System;
using System.Collections.Generic;

namespace Maintenance.Vehicle
{
    public class MaintenanceTypeService : IMaintenanceTypeService
    {
        private IElectricAutomobileRepository _electricRepo;
        private IDieselAutomobileRepository _dieselRepo;
        private IGasAutomobileRepository _gasRepo;

        public MaintenanceTypeService(IDieselAutomobileRepository dieselRepo, IElectricAutomobileRepository electricRepo, IGasAutomobileRepository gasRepo)
        {
            _dieselRepo = dieselRepo;
            _electricRepo = electricRepo;
            _gasRepo = gasRepo;
        }

        public IEnumerable<TaskTypeModel> TaskTypesForAutomobile(string vin)
        {
            if (string.IsNullOrWhiteSpace(vin))
            {
                throw new ArgumentException("VIN is invalid");
            }

            var taskTypes = new List<TaskTypeModel>();

            var dieselAuto = _dieselRepo.GetAutomobile(vin);
            var electricAuto = _electricRepo.GetAutomobile(vin);
            var gasAuto = _gasRepo.GetAutomobile(vin);

            if (dieselAuto != null)
            {
                taskTypes.Add(new TaskTypeModel(TaskType.OilChange));
                taskTypes.Add(new TaskTypeModel(TaskType.TireRotation));
                taskTypes.Add(new TaskTypeModel(TaskType.GlowPlugReplacement));
            }
            else if (electricAuto != null)
            {
                taskTypes.Add(new TaskTypeModel(TaskType.OilChange));
                taskTypes.Add(new TaskTypeModel(TaskType.TireRotation));
                taskTypes.Add(new TaskTypeModel(TaskType.BatteryPackReplacement));
            } else if (gasAuto != null)
            {
                taskTypes.Add(new TaskTypeModel(TaskType.OilChange));
                taskTypes.Add(new TaskTypeModel(TaskType.TireRotation));
                taskTypes.Add(new TaskTypeModel(TaskType.SparkPlugReplacement));
            }

            return taskTypes;
        }
    }
}