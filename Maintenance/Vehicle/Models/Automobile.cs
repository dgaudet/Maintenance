﻿
namespace Maintenance.Vehicle.Models
{
    public class Automobile
    {
        public string VIN { get; set; }
        public long Odometer { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
}