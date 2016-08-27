using Maintenance.Vehicle.Models;
using System.Collections.Generic;

namespace Maintenance.Vehicle
{
    public class GasAutomobileRepository : IGasAutomobileRepository
    {
        public GasAutomobile GetAutomobile(int id)
        {
            if (id == 1)
            {
                return new GasAutomobile() { Id = 1, VIN = "RedCar1", Odometer = 5000, Make = "Nissan", Model = "Murano", Year = 2011, NumberOfSparkPlugs = 6 };
            }
            if (id == 2)
            {
                return new GasAutomobile() { Id = 2, VIN = "BlueCar1", Odometer = 15000, Make = "Nissan", Model = "Frontier", Year = 2006, NumberOfSparkPlugs = 8 };
            }
            return null;
        }

        public List<GasAutomobile> GetAutomobiles()
        {
            var autos = new List<GasAutomobile>();
            autos.Add(GetAutomobile(1));
            autos.Add(GetAutomobile(2));
            return autos;
        }
    }
}