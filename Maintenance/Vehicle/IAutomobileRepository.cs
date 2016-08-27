using Maintenance.Vehicle.Models;
using System.Collections.Generic;

namespace Maintenance.Vehicle
{
    public interface IAutomobileRepository
    {
        Automobile GetAutomobile(int id);
        List<Automobile> GetAutomobiles();
    }
}