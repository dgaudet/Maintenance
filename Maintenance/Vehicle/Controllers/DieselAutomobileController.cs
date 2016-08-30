using Maintenance.Vehicle.Models;
using System.Collections.Generic;
using System.Web.Http;
using System;

namespace Maintenance.Vehicle.Controllers
{
    public class DieselAutomobileController : ApiController
    {
        private IDieselAutomobileRepository _repository;

        public DieselAutomobileController()
        {
            _repository = new DieselAutomobileRepository();
        }

        public DieselAutomobileController(IDieselAutomobileRepository repository)
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

        public IEnumerable<DieselAutomobile> GetAllAutomobiles()
        {
            var autos = _repository.GetAutomobiles();
            if (autos == null)
            {
                return new List<DieselAutomobile>();
            }
            return autos;
        }

        public IHttpActionResult PostAutomobile(DieselAutomobile newAuto)
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

            return CreatedAtRoute("DefaultApi", new { id = newAuto.VIN }, newAuto);
        }

        public IHttpActionResult DeleteAutomobile(string id)
        {
            try
            {
                _repository.DeleteAutomobile(id);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok();
        }
    }
}
