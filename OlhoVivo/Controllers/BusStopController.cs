﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlhoVivo.Data;
using OlhoVivo.Models;
using OlhoVivo.ModelViews;
using OlhoVivo.ModelViews.BusStop;

namespace OlhoVivo.Controllers
{
    [ApiController]
    public class BusStopController : Controller
    {
        private readonly AppDataContext _dataContext;
        public BusStopController(AppDataContext dataContext)
        => this._dataContext = dataContext;

        [HttpGet("v1/BusStops")]
        public async Task<IActionResult> getAsync()
        {
            try
            {
                var busStops = await _dataContext.BusStops.ToListAsync();
                return Ok(new ResultViewModel<List<BusStop>>(busStops));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<List<BusStop>>("05X07 - Falha interna no servidor"));
            }
        }

        [HttpGet("v1/lines/{id}/BusStops")]
        public async Task<IActionResult> GetBusStopByLine(int id)
        {
            try
            {
                var line = await _dataContext
                    .Lines
                    .AsNoTracking()
                    .Include(x => x.BusStops)
                    .FirstAsync(l => l.Id == id);

                if (line is null) 
                    return NotFound();

                return Ok(line.BusStops);
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<List<BusStop>>("05X07 - Falha interna no servidor"));
            }
        }

        [HttpPost("v1/BusStops/")]
        public async Task<IActionResult> PostAsync([FromBody] CreateBusStopViewModel model)
        {
            if (ModelState.IsValid)
                return BadRequest(ModelState);
            
            try
            {
                var busStop = new BusStop();
                busStop.Name = model.Name;
                busStop.Longitude = model.Longitude;
                busStop.Latitude = model.Latitude;
                _dataContext.BusStops.Add(busStop);
                await _dataContext.SaveChangesAsync();

                return Ok(new ResultViewModel<BusStop>(busStop));
            }
            catch (Exception)
            {

                return StatusCode(500, new ResultViewModel<Line>("ERROR004 - Server Error"));
            }

        }

        [HttpPost("line/{id}/stopBus/{idStopBus}")]
        public async Task<IActionResult> AddsStopBusInLine(int id, int idStopBus) 
        {
            try
            {
                var line = await _dataContext.Lines.FindAsync(id);
                var stopBus = await _dataContext.BusStops.FindAsync(idStopBus);

                if (line == null || stopBus == null)
                {
                    return NotFound();
                }

                stopBus.Lines.Add(line);
                await _dataContext.SaveChangesAsync();
                return CreatedAtAction(nameof(GetBusStopByLine), id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("v1/BusStops/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CreateBusStopViewModel model) {
            
            if (ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var busStop = await _dataContext.BusStops.FindAsync(id);
                if (busStop == null)
                    return NotFound(new ResultViewModel<Line>("ERROR005 - BusStop not found."));

                busStop.Name = model.Name;
                busStop.Latitude = model.Latitude;
                busStop.Longitude = model.Longitude;
                await _dataContext.SaveChangesAsync();

                return Ok(new ResultViewModel<BusStop>(busStop));
            }
            catch (Exception)
            {
                return StatusCode(500, "ERROR006 - Server Error");
            }
        }

        [HttpDelete("v1/BusStops/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var busStop = await _dataContext.BusStops.FindAsync(id);

                if (busStop == null)
                    return NotFound(new ResultViewModel<Line>("ERROR007 - BusStop not found."));

                _dataContext.BusStops.Remove(busStop);
                await _dataContext.SaveChangesAsync();
                return Ok(new ResultViewModel<BusStop>(busStop));
            }
            catch (Exception)
            {

                return StatusCode(500, "ERROR006 - Server Error");
            }

        }

    }
}
