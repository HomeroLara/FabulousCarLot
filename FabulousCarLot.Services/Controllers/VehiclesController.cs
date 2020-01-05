using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FabulousCarLot.DAL.Interfaces;
using FabulousCarLot.Models;

namespace FabulousCarLot.Services.Controllers
{
    [Route("api/v0/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private IVehicleRepository vehicleRepository;
        public VehiclesController(IVehicleRepository repository)
        {
            vehicleRepository = repository;
        }
        // GET: api/Vehicles
        [HttpGet]
        public async Task<ActionResult<VehiclesResponse>> Get()
        {
            var vehiclesResponse = new VehiclesResponse();
            vehiclesResponse.Vehicles = await vehicleRepository.GetVehicles();
            vehiclesResponse.HttpResponseCode = 200;
            
            if (!(vehiclesResponse.Vehicles is null))
            {
                vehiclesResponse.ResultCount = vehiclesResponse.Vehicles.Count;
            }

            return Ok(vehiclesResponse);
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var vehicleResponse = new VehicleResponse();
            vehicleResponse.Vehicle = await vehicleRepository.GetVehicleById(id);

            if (vehicleResponse.Vehicle is null)
                vehicleResponse.HttpResponseCode = 404;

            return Ok(vehicleResponse);
        }

        // POST: api/Vehicles
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Vehicles/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
