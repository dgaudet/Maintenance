using Maintenance.Vehicle.Models;
using System.Collections.Generic;
using System.Web.Http;
using System;
using System.Net;

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

        public IHttpActionResult GetAutomobile(string id)
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

        public IHttpActionResult PutAutomobile(ElectricAutomobile newAuto)
        {
            if (newAuto == null)
            {
                return BadRequest();
            }
            try
            {
                _repository.InsertAutomobile(newAuto);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Content(HttpStatusCode.Accepted, newAuto);
        }
    }
}
