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
    public class ImpotsController : ControllerBase
    {
        private readonly KsbApiContext _context;

        public ImpotsController(KsbApiContext context)
        {
            _context = context;
        }

        // GET: api/Impots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Impot>>> GetImpot()
        {
            return await _context.Impot.Where(i=>!i.IsDeleted).ToListAsync();
        }

        // GET: api/Impots/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Impot>> GetImpot(int id)
        {
            var impot = await _context.Impot.FindAsync(id);

            if (impot == null)
            {
                return NotFound();
            }

            return impot;
        }

        // PUT: api/Impots/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImpot(int id, Impot impot)
        {
            if (id != impot.Id)
            {
                return BadRequest();
            }
            impot.UpdatedAt = DateTime.Now.ToLongDateString();
            _context.Entry(impot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImpotExists(id))
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

        // POST: api/Impots
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Impot>> PostImpot(Impot impot)
        {
            impot.CreatedAt = DateTime.Now.ToLongDateString();
            _context.Impot.Add(impot);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImpot", new { id = impot.Id }, impot);
        }

        // DELETE: api/Impots/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImpot(int id)
        {
            var impot = await _context.Impot.FindAsync(id);
            if (impot == null)
            {
                return NotFound();
            }

            //_context.Impot.Remove(impot);
            impot.IsDeleted = true;
            impot.DeletedAt = DateTime.Now.ToLongDateString();

            _context.Entry(impot).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImpotExists(int id)
        {
            return _context.Impot.Any(e => e.Id == id);
        }
    }
}
