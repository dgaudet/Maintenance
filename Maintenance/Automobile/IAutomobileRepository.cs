using System.Collections.Generic;

namespace Maintenance.Automobile
{
    public interface IAutomobileRepository
    {
        Automobile GetAutomobile(int id);
        List<Automobile> GetAutomobiles();
    }
}