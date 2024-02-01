using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlhoVivo.Data;
using OlhoVivo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OlhoVivo.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class LineController : ControllerBase
    {
        private readonly AppDataContext _dataContext;
        public LineController(AppDataContext dataContext)
        => this._dataContext = dataContext;

        // GET: api/<LineController>
        [HttpGet("v1/lines")]
        public async Task<IActionResult> GetAsync()
        {
             var lines = await _dataContext.Lines.ToListAsync();
            return Ok(lines);
        }

        // GET api/<LineController>/5
        [HttpGet("v1/lines/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var line = await _dataContext.Lines.SingleOrDefaultAsync(x => x.Id == id);
            return Ok(line);
        }

        //POST api/<LineController>
        [HttpPost("v1/lines/")]
        public async Task<IActionResult> PostAsync([FromBody] string name)
        {
            var line = new Line(name);
            _dataContext.Lines.Add(line);
            await _dataContext.SaveChangesAsync();

            return Ok(line);
        }

        // PUT api/<LineController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string name)
        {
            var line = _dataContext.Lines.SingleOrDefault(x => x.Id == id);
            line.SetName(name);
            await _dataContext.SaveChangesAsync();
            return Ok(line);
        }

        // DELETE api/<LineController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var line = _dataContext.Lines.SingleOrDefault(x => x.Id == id);
            _dataContext.Lines.Remove(line);
            await _dataContext.SaveChangesAsync();
            return Ok();
        }
    }
}
