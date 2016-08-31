using Maintenance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maintenance.Vehicle
{
    public class MaintenanceTypeService
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

        public IEnumerable<TaskType> TaskTypesForAutomobile(string vin)
        {
            if (string.IsNullOrWhiteSpace(vin))
            {
                throw new ArgumentException("VIN is invalid");
            }

            var taskTypes = new List<TaskType>();

            var dieselAuto = _dieselRepo.GetAutomobile(vin);
            var electricAuto = _electricRepo.GetAutomobile(vin);
            var gasAuto = _gasRepo.GetAutomobile(vin);

            if (dieselAuto != null)
            {
                taskTypes.Add(TaskType.OilChange);
                taskTypes.Add(TaskType.TireRotation);
                taskTypes.Add(TaskType.GlowPlugReplacement);
            }
            else if (electricAuto != null)
            {
                taskTypes.Add(TaskType.OilChange);
                taskTypes.Add(TaskType.TireRotation);
                taskTypes.Add(TaskType.BatteryPackReplacement);
            } else if (gasAuto != null)
            {
                taskTypes.Add(TaskType.OilChange);
                taskTypes.Add(TaskType.TireRotation);
                taskTypes.Add(TaskType.SparkPlugReplacement);
            }

            return taskTypes;
        }
    }
}