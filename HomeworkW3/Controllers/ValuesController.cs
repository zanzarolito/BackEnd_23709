using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Homework_0302.Data;
using Homework_0302.Models;
using System.Linq;

namespace Homework_0302.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly Context _context;
        public ValuesController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Homework>>> GetValues()
        {
            return await _context.Homework.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Homework>> Post_Values(Homework values)
        {
            _context.Homework.Add(values);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetValues", new { id = values.Grade }, values);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Homework>> Delete_values(int id)
        {
            var values = await _context.Homework.FindAsync(id);
            if (values == null)
            {
                return NotFound();
            }

            _context.Homework.Remove(values);
            await _context.SaveChangesAsync();

            return values;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put_Values(int id, Homework values)
        {
            if (id != values.Grade)
            {
                return BadRequest();
            }

            _context.Entry(values).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValuesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool ValuesExists(int id)
        {
            return _context.Homework.Any(e => e.Grade == id);
        }


    }
}