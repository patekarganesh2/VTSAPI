using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VTSAPI.Models;
using VTSAPI.Repository;

namespace VTSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        // GET: api/Vehicle
        [HttpGet]
        public IActionResult Get()
        {
            var vehicle = _vehicleRepository.GetVehicle();
            return new OkObjectResult(vehicle);
        }
        // GET: api/vehicle/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var vehicle = _vehicleRepository.GetVehicleByID(id);
            return new OkObjectResult(vehicle);
        }
        // POST: api/vehicle
        [HttpPost]
        public IActionResult Post([FromBody] Vehicle vehicle)
        {
            using (var scope = new TransactionScope())
            {
                _vehicleRepository.InsertVehicle(vehicle);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = vehicle.VechileId }, vehicle);
            }
        }
        // PUT: api/vehicle/5
        [HttpPut]
        public IActionResult Put([FromBody] Vehicle vehicle)
        {
            if (vehicle != null)
            {
                using (var scope = new TransactionScope())
                {
                    _vehicleRepository.UpdateVehicle(vehicle);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _vehicleRepository.DeleteVehicle(id);
            return new OkResult();
        }
    }
}