using Maintenance.Vehicle.Models;
using System.Collections.Generic;

namespace Maintenance.Vehicle
{
    public class AutomobileRepository : IAutomobileRepository
    {
        public Automobile GetAutomobile(int id)
        {
            if (id == 1)
            {
                return new Automobile() { Id = 1, VIN = "RedCar1", Odometer = 5000, Make = "Nissan", Model = "Murano", Year = 2011 };
            }
            if (id == 2)
            {
                return new Automobile() { Id = 2, VIN = "BlueCar1", Odometer = 15000, Make = "Nissan", Model = "Frontier", Year = 2006 };
            }
            return null;
        }

        public List<Automobile> GetAutomobiles()
        {
            var autos = new List<Automobile>();
            autos.Add(GetAutomobile(1));
            autos.Add(GetAutomobile(2));
            return autos;
        }
    }
}