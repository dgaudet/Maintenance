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

    public class IGasAutomobileRepositoryFactory
    {
        static IGasAutomobileRepository _repo;

        public static IGasAutomobileRepository CreateSharedRepo()
        {
            if (_repo == null)
            {
                _repo = new GasAutomobileRepository();
            }
            return _repo;
        }
    }
}