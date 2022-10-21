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
    public class AutresDepensesController : ControllerBase
    {
        private readonly KsbApiContext _context;

        public AutresDepensesController(KsbApiContext context)
        {
            _context = context;
        }

        // GET: api/AutresDepenses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutresDepense>>> GetAutresDepense()
        {
            return await _context.AutresDepense.Include("TypeDepenseAutre").Include("AutresProjet")
                                    .Where(s => !s.IsDeleted).ToListAsync();
        }

        // GET: api/AutresDepenses/5
        [HttpGet("By/{idProj}")]
        public async Task<ActionResult<IEnumerable<AutresDepense>>> GetAutresDepenseByProjetAndDep(int idType, int idProj)
        {
            var autresDepense = await _context.AutresDepense.Include("TypeDepenseAutre").Include("AutresProjet").Where(s => !s.IsDeleted).Where(d=>d.AutresProjetId==idProj).ToListAsync();

            if (autresDepense == null)
            {
                return NotFound();
            }

            return autresDepense;
        }

        // GET: api/AutresDepenses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AutresDepense>> GetAutresDepense(int id)
        {
            var autresDepense = await _context.AutresDepense.FindAsync(id);

            if (autresDepense == null)
            {
                return NotFound();
            }

            return autresDepense;
        }

        // PUT: api/AutresDepenses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutresDepense(int id, AutresDepense autresDepense)
        {
            if (id != autresDepense.Id)
            {
                return BadRequest();
            }

            autresDepense.UpdatedAt = DateTime.Now.ToLongDateString();
            _context.Entry(autresDepense).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutresDepenseExists(id))
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

        // POST: api/AutresDepenses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AutresDepense>> PostAutresDepense(AutresDepense autresDepense)
        {
            autresDepense.CreatedAt = DateTime.Now.ToLongDateString();
            _context.AutresDepense.Add(autresDepense);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutresDepense", new { id = autresDepense.Id }, autresDepense);
        }

        // DELETE: api/AutresDepenses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutresDepense(int id)
        {
            var autresDepense = await _context.AutresDepense.FindAsync(id);
            if (autresDepense == null)
            {
                return NotFound();
            }
            autresDepense.IsDeleted = true;
            autresDepense.DeletedAt = DateTime.Now.ToLongDateString();
            _context.Entry(autresDepense).State = EntityState.Modified;
            //_context.AutresDepense.Remove(autresDepense);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AutresDepenseExists(int id)
        {
            return _context.AutresDepense.Any(e => e.Id == id);
        }
    }
}
