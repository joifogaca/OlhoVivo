﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlhoVivo.Data;
using OlhoVivo.Models;
using OlhoVivo.ModelViews;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OlhoVivo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly AppDataContext _dataContext;
        public VehicleController(AppDataContext dataContext)
        => this._dataContext = dataContext;

        // GET: api/<VehicleController>
        [HttpGet("v1/vehicle")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var vehicle = await _dataContext.Vehicles.ToListAsync();
                return Ok(new ResultViewModel<List<Vehicle>>(vehicle));
            }
            catch
            {

                return StatusCode(500, new ResultViewModel<List<Vehicle>>("ERROR001 - Falha interna no servidor"));
            }
        }

        // GET api/<VehicleController>/5
        [HttpGet("v1/vehicle/{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var vehicle = await _dataContext.Vehicles.FindAsync(id);

                if (vehicle == null)
                    return NotFound(new ResultViewModel<Vehicle>("ERROR002 - Line not found."));

                return Ok(new ResultViewModel<Vehicle>(vehicle));
            }
            catch (Exception)
            {

                return StatusCode(500, new ResultViewModel<Line>("ERROR003 - Server Error"));
            }
        }

        // POST api/<VehicleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VehicleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VehicleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}