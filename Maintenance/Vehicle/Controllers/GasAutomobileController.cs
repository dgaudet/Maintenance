using Maintenance.Vehicle.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Maintenance.Vehicle.Controllers
{
    public class GasAutomobileController : ApiController
    {
        private IGasAutomobileRepository _repository;

        public GasAutomobileController()
        {
            _repository = new GasAutomobileRepository();
        }

        public GasAutomobileController(IGasAutomobileRepository repository)
        {
            _repository = repository;
        }

        public IHttpActionResult GetAutomobile(string VIN)
        {
            var auto = _repository.GetAutomobile(VIN);
            if (auto == null)
            {
                return NotFound();
            }
            return Ok(auto);
        }

        public IEnumerable<GasAutomobile> GetAllAutomobiles()
        {
            var autos = _repository.GetAutomobiles();
            if (autos == null)
            {
                return new List<GasAutomobile>();
            }
            return autos;
        }
    }
}
