using Maintenance.Vehicle.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Maintenance.Vehicle.Controllers
{
    public class ElectricAutomobileController : ApiController
    {
        private IElectricAutomobileRepository _repository;

        public ElectricAutomobileController()
        {
            _repository = new ElectricAutomobileRepository();
        }

        public ElectricAutomobileController(IElectricAutomobileRepository repository)
        {
            _repository = repository;
        }

        public IHttpActionResult GetAutomobile(int id)
        {
            var auto = _repository.GetAutomobile(id);
            if (auto == null)
            {
                return NotFound();
            }
            return Ok(auto);
        }

        public IEnumerable<ElectricAutomobile> GetAllAutomobiles()
        {
            var autos = _repository.GetAutomobiles();
            if (autos == null)
            {
                return new List<ElectricAutomobile>();
            }
            return autos;
        }
    }
}
