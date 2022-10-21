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
    public class DepensesProjetsController : ControllerBase
    {
        private readonly KsbApiContext _context;

        public DepensesProjetsController(KsbApiContext context)
        {
            _context = context;
        }

        // GET: api/DepensesProjets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepensesProjet>>> GetDepensesProjet()
        {
            return await _context.DepensesProjet.Include("TypeDepenseProjet")
                                .Where(s => !s.IsDeleted).ToListAsync();
        }

        // GET: api/DepensesProjets/5
        [HttpGet("ByProj/{id}")]
        public async Task<ActionResult<IEnumerable<DepensesProjet>>> GetDepensesByProjet(int id)
        {
            var depensesProjet = await _context.DepensesProjet.Include("TypeDepenseProjet").
                Where(d=>d.ProjetId==id&&!d.IsDeleted).ToListAsync();

            if (depensesProjet == null)
            {
                return NotFound();
            }

            return depensesProjet;
        }

        // GET: api/DepensesProjets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepensesProjet>> GetDepensesProjet(int id)
        {
            var depensesProjet = await _context.DepensesProjet.FindAsync(id);

            if (depensesProjet == null)
            {
                return NotFound();
            }

            return depensesProjet;
        }

        // PUT: api/DepensesProjets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepensesProjet(int id, DepensesProjet depensesProjet)
        {
            if (id != depensesProjet.Id)
            {
                return BadRequest();
            }

            depensesProjet.UpdatedAt = DateTime.Now.ToLongDateString();
            _context.Entry(depensesProjet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepensesProjetExists(id))
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

        // POST: api/DepensesProjets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DepensesProjet>> PostDepensesProjet(DepensesProjet depensesProjet)
        {
            depensesProjet.CreatedAt = DateTime.Now.ToLongDateString();
            _context.DepensesProjet.Add(depensesProjet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepensesProjet", new { id = depensesProjet.Id }, depensesProjet);
        }

        // DELETE: api/DepensesProjets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepensesProjet(int id)
        {
            var depensesProjet = await _context.DepensesProjet.FindAsync(id);
            if (depensesProjet == null)
            {
                return NotFound();
            }

            depensesProjet.IsDeleted = true;
            depensesProjet.DeletedAt = DateTime.Now.ToLongDateString();
            _context.Entry(depensesProjet).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepensesProjetExists(int id)
        {
            return _context.DepensesProjet.Any(e => e.Id == id);
        }
    }
}
