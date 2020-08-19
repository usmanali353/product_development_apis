using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{
    [Authorize(Roles="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class clientsController : ControllerBase
    {
        private readonly RequestDbContext _context;

        public clientsController(RequestDbContext context)
        {
            _context = context;
        }

        // GET: api/clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<clients>>> Getclient()
        {
            return await _context.client.ToListAsync();
        }

        // GET: api/clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<clients>> Getclients(int id)
        {
            var clients = await _context.client.FindAsync(id);

            if (clients == null)
            {
                return NotFound();
            }

            return clients;
        }

        // PUT: api/clients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putclients(int id, clients clients)
        {
            if (id != clients.clientId)
            {
                return BadRequest();
            }

            _context.Entry(clients).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!clientsExists(id))
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

        // POST: api/clients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<clients>> Postclients(clients clients)
        {
            _context.client.Add(clients);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getclients", new { id = clients.clientId }, clients);
        }

        // DELETE: api/clients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<clients>> Deleteclients(int id)
        {
            var clients = await _context.client.FindAsync(id);
            if (clients == null)
            {
                return NotFound();
            }

            _context.client.Remove(clients);
            await _context.SaveChangesAsync();

            return clients;
        }

        private bool clientsExists(int id)
        {
            return _context.client.Any(e => e.clientId == id);
        }
    }
}
