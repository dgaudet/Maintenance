using Maintenance.Vehicle.Models;
using System.Collections.Generic;
using System.Web.Http;
using System;
using System.Net;

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

        public IHttpActionResult GetAutomobile(string id)
        {
            var auto = _repository.GetAutomobile(id);
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

        public IHttpActionResult PostAutomobile(GasAutomobile newAuto)
        {
            if (newAuto == null)
            {
                return BadRequest();
            }
            try
            {
                _repository.InsertAutomobile(newAuto);
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
            return Content(HttpStatusCode.Accepted, newAuto);
        }

        public IHttpActionResult DeleteAutomobile(string vin)
        {
            try
            {
                _repository.DeleteAutomobile(vin);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok();
        }
    }
}
