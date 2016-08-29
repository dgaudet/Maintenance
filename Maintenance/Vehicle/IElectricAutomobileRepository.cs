using System.Collections.Generic;
using Maintenance.Vehicle.Models;

namespace Maintenance.Vehicle
{
    public interface IElectricAutomobileRepository
    {
        List<ElectricAutomobile> GetAutomobiles();
        ElectricAutomobile GetAutomobile(string vin);
        void InsertAutomobile(ElectricAutomobile auto);
        void DeleteAutomobile(string vin);
    }
}