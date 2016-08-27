using Maintenance.Vehicle.Models;
using System.Collections.Generic;

namespace Maintenance.Vehicle
{
    public class ElectricAutomobileRepository : IElectricAutomobileRepository
    {
        public ElectricAutomobile GetAutomobile(string vin)
        {
            if (vin.Equals("OrangeCar1", System.StringComparison.InvariantCultureIgnoreCase))
            {
                return new ElectricAutomobile() { VIN = "OrangeCar1", Odometer = 3000, Make = "Tesla", Model = "Roadster", Year = 2011, BatteryPackWeight = 2877 };
            }
            if (vin.Equals("GreenCar1", System.StringComparison.InvariantCultureIgnoreCase))
            {
                return new ElectricAutomobile() { VIN = "GreenCar1", Odometer = 15000, Make = "Chevy", Model = "Volt", Year = 2012, BatteryPackWeight = 435 };
            }
            return null;
        }

        public List<ElectricAutomobile> GetAutomobiles()
        {
            var autos = new List<ElectricAutomobile>();
            autos.Add(GetAutomobile("OrangeCar1"));
            autos.Add(GetAutomobile("GreenCar1"));
            return autos;
        }
    }
}