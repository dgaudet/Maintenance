using Maintenance.Vehicle.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Maintenance.Vehicle.Controllers
{
    public class AutomobileController : ApiController
    {
        private IAutomobileRepository _repository;

        public AutomobileController(IAutomobileRepository repository)
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

        public IEnumerable<Automobile> GetAllAutomobiles()
        {
            var autos = _repository.GetAutomobiles();
            if (autos == null)
            {
                return new List<Automobile>();
            }
            return autos;
        }
    }
}
