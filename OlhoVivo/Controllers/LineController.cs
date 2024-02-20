using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlhoVivo.Data;
using OlhoVivo.Models;
using OlhoVivo.ModelViews;

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
            try
            {
                var lines = await _dataContext.Lines.ToListAsync();
                return Ok(new ResultViewModel<List<Line>>(lines));
            }
            catch 
            {

                return StatusCode(500, new ResultViewModel<List<Line>>("ERROR001 - Falha interna no servidor"));
            }
             
        }

        // GET api/<LineController>/5
        [HttpGet("v1/lines/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var line = await _dataContext.Lines.FindAsync(id);

                if(line == null) 
                    return NotFound(new ResultViewModel<Line>("ERROR002 - Line not found."));

                return Ok(new ResultViewModel<Line>(line));
            }
            catch (Exception)
            {

                return StatusCode(500, new ResultViewModel<Line>("ERROR003 - Server Error"));
            }
            
        }

        //POST api/<LineController>
        [HttpPost("v1/lines/")]
        public async Task<IActionResult> PostAsync([FromBody] string name)
        {
            // TODO Fazer verificação do modelo veio correto 
            try
            {
                var line = new Line(name);
                _dataContext.Lines.Add(line);
                await _dataContext.SaveChangesAsync();

                return Ok(new ResultViewModel<Line>(line));
            }
            catch (Exception)
            {

                return StatusCode(500, new ResultViewModel<Line>("ERROR004 - Server Error"));
            }
            
        }

        // PUT api/<LineController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string name)
        {
            try
            {
                var line = await _dataContext.Lines.FindAsync(id);
                if(line == null) 
                    return NotFound(new ResultViewModel<Line>("ERROR005 - Line not found."));

                line.SetName(name);
                await _dataContext.SaveChangesAsync();

                return Ok(new ResultViewModel<Line>(line));
            }
            catch (Exception)
            {
                return StatusCode(500, "ERROR006 - Server Error");
            }
        }

        // DELETE api/<LineController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var line = await _dataContext.Lines.FindAsync(id);
                
                if (line == null)
                    return NotFound(new ResultViewModel<Line>("ERROR007 - Line not found."));

                _dataContext.Lines.Remove(line);
                await _dataContext.SaveChangesAsync();
                return Ok(new ResultViewModel<Line>(line));
            }
            catch (Exception)
            {

                return StatusCode(500, "ERROR006 - Server Error");
            }
           
        }
    }
}
