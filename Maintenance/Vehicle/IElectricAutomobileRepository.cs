using System.Collections.Generic;
using Maintenance.Vehicle.Models;

namespace Maintenance.Vehicle
{
    public interface IElectricAutomobileRepository
    {
        ElectricAutomobile GetAutomobile(int id);
        List<ElectricAutomobile> GetAutomobiles();
    }
}