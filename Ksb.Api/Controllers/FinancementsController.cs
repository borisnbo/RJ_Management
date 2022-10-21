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
    public class FinancementsController : ControllerBase
    {
        private readonly KsbApiContext _context;

        public FinancementsController(KsbApiContext context)
        {
            _context = context;
        }

        // GET: api/Financements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Financement>>> GetFinancement()
        {
            return await _context.Financement.Where(s => !s.IsDeleted).ToListAsync();
        }

        // GET: api/Financements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Financement>> GetFinancement(int id)
        {
            var financement = await _context.Financement.FindAsync(id);

            if (financement == null)
            {
                return NotFound();
            }

            return financement;
        }

        // PUT: api/Financements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinancement(int id, Financement financement)
        {
            if (id != financement.Id)
            {
                return BadRequest();
            }
            financement.UpdatedAt = DateTime.Now.ToLongDateString(); 
            _context.Entry(financement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinancementExists(id))
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

        // POST: api/Financements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Financement>> PostFinancement(Financement financement)
        {
            financement.CreatedAt = DateTime.Now.ToLongDateString();
            _context.Financement.Add(financement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinancement", new { id = financement.Id }, financement);
        }

        // DELETE: api/Financements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinancement(int id)
        {
            var financement = await _context.Financement.FindAsync(id);
            if (financement == null)
            {
                return NotFound();
            }

            financement.IsDeleted = true;
            financement.DeletedAt = DateTime.Now.ToLongDateString();
            _context.Entry(financement).State = EntityState.Modified;
            //_context.Financement.Remove(financement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FinancementExists(int id)
        {
            return _context.Financement.Any(e => e.Id == id);
        }
    }
}
