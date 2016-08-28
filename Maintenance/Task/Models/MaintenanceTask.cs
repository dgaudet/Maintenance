using System;

namespace Maintenance.Models
{
    public class MaintenanceTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public long Odometer { get; set; }
        public string VIN { get; set; }
    }
}