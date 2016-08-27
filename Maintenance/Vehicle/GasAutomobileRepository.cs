using Maintenance.Vehicle.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Maintenance.Vehicle
{
    public class GasAutomobileRepository : IGasAutomobileRepository
    {
        static List<GasAutomobile> _storedAutos;
        public GasAutomobileRepository()
        {
            if (_storedAutos == null)
            {
                _storedAutos = new List<GasAutomobile>();
                InsertAutomobile(new GasAutomobile() { VIN = "RedCar1", Odometer = 5000, Make = "Nissan", Model = "Murano", Year = 2011, NumberOfSparkPlugs = 6 });
                InsertAutomobile(new GasAutomobile() { VIN = "BlueCar1", Odometer = 15000, Make = "Nissan", Model = "Frontier", Year = 2006, NumberOfSparkPlugs = 8 });
            }
        }

        public GasAutomobile GetAutomobile(string VIN)
        {
            return _storedAutos.FirstOrDefault(x => x.VIN.Equals(VIN, StringComparison.InvariantCultureIgnoreCase));
        }

        public List<GasAutomobile> GetAutomobiles()
        {
            return _storedAutos;
        }

        public void InsertAutomobile(GasAutomobile auto)
        {
            if (auto == null || auto.VIN == null)
            {
                throw new ArgumentException();
            }
            var existingAuto = GetAutomobile(auto.VIN);
            if (existingAuto != null)
            {
                throw new ArgumentException("Duplicate VIN is not allowed");
            }
            _storedAutos.Add(auto);
        }
    }
}