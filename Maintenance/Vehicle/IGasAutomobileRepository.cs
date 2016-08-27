using Maintenance.Vehicle.Models;
using System.Collections.Generic;

namespace Maintenance.Vehicle
{
    public interface IGasAutomobileRepository
    {
        List<GasAutomobile> GetAutomobiles();
        GasAutomobile GetAutomobile(string VIN);
        void InsertAutomobile(GasAutomobile auto);
    }
}