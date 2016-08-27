using Maintenance.Vehicle.Models;
using System.Collections.Generic;

namespace Maintenance.Vehicle
{
    public class ElectricAutomobileRepository : IElectricAutomobileRepository
    {
        public ElectricAutomobile GetAutomobile(int id)
        {
            if (id == 1)
            {
                return new ElectricAutomobile() { Id = 1, VIN = "OrangeCar1", Odometer = 3000, Make = "Tesla", Model = "Roadster", Year = 2011, BatteryPackWeight = 2877 };
            }
            if (id == 2)
            {
                return new ElectricAutomobile() { Id = 2, VIN = "GreenCar1", Odometer = 15000, Make = "Chevy", Model = "Volt", Year = 2012, BatteryPackWeight = 435 };
            }
            return null;
        }

        public List<ElectricAutomobile> GetAutomobiles()
        {
            var autos = new List<ElectricAutomobile>();
            autos.Add(GetAutomobile(1));
            autos.Add(GetAutomobile(2));
            return autos;
        }
    }
}