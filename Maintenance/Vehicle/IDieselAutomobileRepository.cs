using System.Collections.Generic;
using Maintenance.Vehicle.Models;

namespace Maintenance.Vehicle
{
    public interface IDieselAutomobileRepository
    {
        void DeleteAutomobile(string vin);
        DieselAutomobile GetAutomobile(string VIN);
        List<DieselAutomobile> GetAutomobiles();
        void InsertAutomobile(DieselAutomobile auto);
    }
}