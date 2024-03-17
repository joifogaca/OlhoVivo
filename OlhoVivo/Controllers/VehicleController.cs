using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlhoVivo.Data;
using OlhoVivo.Models;
using OlhoVivo.ModelViews;
using OlhoVivo.ModelViews.Vehicle;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OlhoVivo.Controllers
{
    
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly AppDataContext _dataContext;
        public VehicleController(AppDataContext dataContext)
        => this._dataContext = dataContext;

        // GET: api/<VehicleController>
        [HttpGet("v1/vehicles")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var vehicle = await _dataContext.Vehicles
                    .Where(v => v.IsActive == true)
                    .ToListAsync();
                return Ok(new ResultViewModel<List<Vehicle>>(vehicle));
            }
            catch(Exception ex)
            {

                return StatusCode(500, new ResultViewModel<List<Vehicle>>("ERROR001 - Falha interna no servidor: " + ex.Message));
            }
        }

        // GET api/<VehicleController>/5
        [HttpGet("v1/vehicle/{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var vehicle = await _dataContext.Vehicles
                    .Where(v => v.IsActive == true)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (vehicle == null)
                    return NotFound(new ResultViewModel<Vehicle>("ERROR002 - Line not found."));

                return Ok(new ResultViewModel<Vehicle>(vehicle));
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ResultViewModel<Line>("ERROR003 - Server Error: " + ex.Message));
            }
        }

        // POST api/<VehicleController>
        [HttpPost("v1/vehicle")]
        public async Task<IActionResult> Post([FromBody] CreateVehicleModelView model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var vehicle = new Vehicle();
                vehicle.Name = model.Name;
                vehicle.Model = model.Model;

                var line = _dataContext.Lines.Find(model.LineId);

                if (line is null)
                    return NotFound("Linha atribuida para o veículo não encontrada");

               _dataContext.Vehicles.Add(vehicle);
                await _dataContext.SaveChangesAsync();
                var vehicleCreated = await _dataContext.Vehicles.FirstOrDefaultAsync(v => v.Name == model.Name);


                return CreatedAtAction(nameof(GetAsync), vehicleCreated.Id);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ResultViewModel<Line>("Server Error: " + ex.Message));
            }
        }

        //PUT api/<VehicleController>/5
        [HttpPut("v1/vehicle/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CreateVehicleModelView model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var vehicle = _dataContext.Vehicles.Find(id);

                if (vehicle is null)
                    return NotFound("Veiculo não encontrado.");

                vehicle.Name = model.Name;
                vehicle.Model = model.Model;

                var line = _dataContext.Lines.Find(model?.LineId);

                if (line is null)
                    return NotFound("Linha não encontrada");

                vehicle.Line = line;
                await _dataContext.SaveChangesAsync();

                return Ok(new ResultViewModel<Vehicle>(vehicle));

            }
            catch (Exception ex )
            {
                return StatusCode(500, new ResultViewModel<Line>("Server Error: " + ex.Message));

            }
        }

        //// DELETE api/<VehicleController>/5
        [HttpDelete("v1/vehicle/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var vehicle = _dataContext.Vehicles.Find(id);

                if(vehicle is null)
                    return NotFound("Veiculo não encontrado");

                //colocar ativo igual a false e rodar migration
                vehicle.IsActive = false;

                await _dataContext.SaveChangesAsync();

                return Ok(new ResultViewModel<Vehicle>(vehicle));

            }
            catch (Exception ex)
            {

                return StatusCode(500, new ResultViewModel<Line>("Server Error: " + ex.Message));
            }

        }
    }
}
