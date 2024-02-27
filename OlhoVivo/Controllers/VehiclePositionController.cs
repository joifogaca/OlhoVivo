using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlhoVivo.Data;
using OlhoVivo.Models;
using OlhoVivo.ModelViews;
using OlhoVivo.ModelViews.VehiclePosition;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OlhoVivo.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class VehiclePositionController : ControllerBase
    {
        private readonly AppDataContext _dataContext;
        public VehiclePositionController(AppDataContext dataContext)
        => this._dataContext = dataContext;

        // GET: api/<VehiclePositionController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var vehiclePositions = await _dataContext.VehiclePositions.ToListAsync();
                return Ok(new ResultViewModel<List<VehiclePositions>>(vehiclePositions));
            }
            catch
            {

                return StatusCode(500, new ResultViewModel<List<VehiclePositions>>("ERRORVP001 - Falha interna no servidor"));
            }
        }

        // GET api/<VehiclePositionController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var vehiclePositions = await _dataContext.VehiclePositions.FindAsync(id);

                if (vehiclePositions == null)
                    return NotFound(new ResultViewModel<VehiclePositions>("ERRORVP002 - Vehicle Position not found."));

                return Ok(new ResultViewModel<VehiclePositions>(vehiclePositions));
            }
            catch (Exception)
            {

                return StatusCode(500, new ResultViewModel<VehiclePositions>("ERRORVP003 - Server Error"));
            }
        }

        // POST api/<VehiclePositionController>
        [HttpPost("v1/vehicle/{id}/VehiclePosition")]
        public async Task<IActionResult> PostAsync([FromBody] CreateVehiclePositionViewModel model, int id)
        {
            if (ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var vehicle = await _dataContext.Vehicles.FindAsync(id);
                var vehiclePositions = new VehiclePositions();
                vehiclePositions.Vehicle = vehicle;
                vehiclePositions.Longitude = model.Longitude;
                vehiclePositions.Latitude = model.Latitude;
                vehiclePositions.DateTime = model.DateTime;


                _dataContext.VehiclePositions.Add(vehiclePositions);
                await _dataContext.SaveChangesAsync();

                return Ok(new ResultViewModel<VehiclePositions>(vehiclePositions));
            }
            catch (Exception)
            {

                return StatusCode(500, new ResultViewModel<Line>("ERROR004 - Server Error"));
            }
        }

        // PUT api/<VehiclePositionController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, CreateVehiclePositionViewModel model)
        {
            if (ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var vehiclePositions = await _dataContext.VehiclePositions.FindAsync(id);
                if (vehiclePositions == null)
                    return NotFound(new ResultViewModel<Line>("ERROR005 - Vehicle Positions not found."));

                vehiclePositions.Latitude = model.Latitude;
                vehiclePositions.Longitude = model.Longitude;
                vehiclePositions.DateTime = model.DateTime;
                await _dataContext.SaveChangesAsync();

                return Ok(new ResultViewModel<VehiclePositions>(vehiclePositions));
            }
            catch (Exception)
            {
                return StatusCode(500, "ERROR006 - Server Error");
            }
        }

        // DELETE api/<VehiclePositionController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var vehiclePositions = await _dataContext.VehiclePositions.FindAsync(id);

                if (vehiclePositions == null)
                    return NotFound(new ResultViewModel<VehiclePositions>("ERROR007 - Vehicle Positions not found."));

                _dataContext.VehiclePositions.Remove(vehiclePositions);
                await _dataContext.SaveChangesAsync();
                return Ok(new ResultViewModel<VehiclePositions>(vehiclePositions));
            }
            catch (Exception)
            {

                return StatusCode(500, "ERROR006 - Server Error");
            }
        }
    }
}
