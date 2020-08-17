using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly RequestDbContext _context;

        public ColorsController(RequestDbContext context)
        {
            _context = context;
        }

        // GET: api/Colors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colors>>> Getcolors()
        {
            return await _context.colors.ToListAsync();
        }

        // GET: api/Colors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Colors>> GetColors(int id)
        {
            var colors = await _context.colors.FindAsync(id);

            if (colors == null)
            {
                return NotFound();
            }

            return colors;
        }

        // PUT: api/Colors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColors(int id, Colors colors)
        {
            if (id != colors.colorId)
            {
                return BadRequest();
            }

            _context.Entry(colors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorsExists(id))
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

        // POST: api/Colors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Colors>> PostColors(Colors colors)
        {
            _context.colors.Add(colors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColors", new { id = colors.colorId }, colors);
        }

        // DELETE: api/Colors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Colors>> DeleteColors(int id)
        {
            var colors = await _context.colors.FindAsync(id);
            if (colors == null)
            {
                return NotFound();
            }

            _context.colors.Remove(colors);
            await _context.SaveChangesAsync();

            return colors;
        }

        private bool ColorsExists(int id)
        {
            return _context.colors.Any(e => e.colorId == id);
        }
    }
}
