using Maintenance.Vehicle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maintenance.Vehicle
{
    public class DieselAutomobileRepository : IDieselAutomobileRepository
    {
        static List<DieselAutomobile> _storedAutos;
        public DieselAutomobileRepository()
        {
            if (_storedAutos == null)
            {
                _storedAutos = new List<DieselAutomobile>();
                InsertAutomobile(new DieselAutomobile() { VIN = "BlackTruck1", Odometer = 5000, Make = "Dodge", Model = "Heavy Duty", Year = 2013});
                InsertAutomobile(new DieselAutomobile() { VIN = "GreyCar1", Odometer = 15000, Make = "Volkswagon", Model = "Passat", Year = 2009 });
            }
        }

        public DieselAutomobile GetAutomobile(string VIN)
        {
            return _storedAutos.FirstOrDefault(x => x.VIN.Equals(VIN, StringComparison.InvariantCultureIgnoreCase));
        }

        public List<DieselAutomobile> GetAutomobiles()
        {
            return _storedAutos;
        }

        public void InsertAutomobile(DieselAutomobile auto)
        {
            if (auto == null || string.IsNullOrWhiteSpace(auto.VIN))
            {
                throw new ArgumentException("Invalid auto, either auto is null or invalid VIN");
            }
            var existingAuto = GetAutomobile(auto.VIN);
            if (existingAuto != null)
            {
                throw new ArgumentException("Duplicate VIN is not allowed");
            }
            _storedAutos.Add(auto);
        }

        public void DeleteAutomobile(string vin)
        {
            if (string.IsNullOrWhiteSpace(vin))
            {
                throw new ArgumentException("VIN must not be null");
            }
            var auto = GetAutomobile(vin);
            if (auto == null)
            {
                throw new ArgumentException("VIN does not exist");
            }
            _storedAutos.Remove(auto);
        }
    }
}