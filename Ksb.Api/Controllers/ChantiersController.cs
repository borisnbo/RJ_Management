using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ksb.Api.Data;
using Ksb.Domain;

namespace Ksb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChantiersController : ControllerBase
    {
        private readonly KsbApiContext _context;

        public ChantiersController(KsbApiContext context)
        {
            _context = context;
        }

        // GET: api/Chantiers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chantier>>> GetChantier()
        {
            return await _context.Chantier.Where(s => !s.IsDeleted).ToListAsync();
        }

        // GET: api/Chantiers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chantier>> GetChantier(int id)
        {
            var chantier = await _context.Chantier.FindAsync(id);

            if (chantier == null)
            {
                return NotFound();
            }

            return chantier;
        }

        // PUT: api/Chantiers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChantier(int id, Chantier chantier)
        {
            if (id != chantier.Id)
            {
                return BadRequest();
            }
            chantier.UpdatedAt = DateTime.Now.ToLongDateString();
            _context.Entry(chantier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChantierExists(id))
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

        // POST: api/Chantiers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Chantier>> PostChantier(Chantier chantier)
        {
            chantier.CreatedAt = DateTime.Now.ToLongDateString();
            _context.Chantier.Add(chantier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChantier", new { id = chantier.Id }, chantier);
        }

        // DELETE: api/Chantiers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChantier(int id)
        {
            var chantier = await _context.Chantier.FindAsync(id);
            if (chantier == null)
            {
                return NotFound();
            }
            chantier.IsDeleted = true;
            chantier.DeletedAt = DateTime.Now.ToLongDateString();
            _context.Entry(chantier).State = EntityState.Modified;
            //_context.Chantier.Remove(chantier);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChantierExists(int id)
        {
            return _context.Chantier.Any(e => e.Id == id);
        }
    }
}
