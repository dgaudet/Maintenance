using Maintenance.Vehicle.Models;
using System.Collections.Generic;

namespace Maintenance.Vehicle
{
    public interface IGasAutomobileRepository
    {
        GasAutomobile GetAutomobile(int id);
        List<GasAutomobile> GetAutomobiles();
    }
}