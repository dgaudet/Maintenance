using System.Collections.Generic;
using Maintenance.Vehicle.Models;

namespace Maintenance.Vehicle
{
    public interface IElectricAutomobileRepository
    {
        List<ElectricAutomobile> GetAutomobiles();
        ElectricAutomobile GetAutomobile(string vin);
    }
}