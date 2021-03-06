﻿using Maintenance.Vehicle.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Maintenance.Vehicle
{
    public class ElectricAutomobileRepository : IElectricAutomobileRepository
    {
        static List<ElectricAutomobile> _storedAutos;

        public ElectricAutomobileRepository()
        {
            if (_storedAutos == null)
            {
                _storedAutos = new List<ElectricAutomobile>();
                InsertAutomobile(new ElectricAutomobile() { VIN = "OrangeCar1", Odometer = 3000, Make = "Tesla", Model = "Roadster", Year = 2011, BatteryPackWeight = 2877 });
                InsertAutomobile(new ElectricAutomobile() { VIN = "GreenCar1", Odometer = 15000, Make = "Chevy", Model = "Volt", Year = 2012, BatteryPackWeight = 435 });
            }
        }

        public ElectricAutomobile GetAutomobile(string vin)
        {
            var auto = _storedAutos.FirstOrDefault(a => a.VIN.Equals(vin, StringComparison.InvariantCultureIgnoreCase));
            return auto;
        }

        public List<ElectricAutomobile> GetAutomobiles()
        {
            return _storedAutos;
        }

        public void InsertAutomobile(ElectricAutomobile auto)
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
            var existingAuto = GetAutomobile(vin);
            if (existingAuto == null)
            {
                throw new ArgumentException("VIN does not exist");
            }
            _storedAutos.Remove(existingAuto);
        }
    }
}