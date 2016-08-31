using System;
using System.ComponentModel;

namespace Maintenance.Models
{
    public class MaintenanceTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public long Odometer { get; set; }
        public string VIN { get; set; }
        public TaskType type { get; set; }
        public string TypeDescription { get
            {
                return type.GetDescription();
            }
        }
    }

    public enum TaskType {
        Invalid,
        [Description("Oil Change")] OilChange,
        [Description("Tire Rotation")] TireRotation,
        [Description("Battery Pack Replacement")] BatteryPackReplacement,
        [Description("Glow Plug Replacement")] GlowPlugReplacement
    }
}