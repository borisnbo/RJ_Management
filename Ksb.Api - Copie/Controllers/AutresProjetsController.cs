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
    public class AutresProjetsController : ControllerBase
    {
        private readonly KsbApiContext _context;

        public AutresProjetsController(KsbApiContext context)
        {
            _context = context;
        }

        // GET: api/AutresProjets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutresProjet>>> GetAutresProjet()
        {
            return await _context.AutresProjet.Where(s => !s.IsDeleted).ToListAsync();
        }

        // GET: api/AutresProjets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AutresProjet>> GetAutresProjet(int id)
        {
            var autresProjet = await _context.AutresProjet.FindAsync(id);

            if (autresProjet == null)
            {
                return NotFound();
            }

            return autresProjet;
        }

        // GET: api/AutresProjets/5
        [HttpGet("ByType/{id}")]
        public async Task<ActionResult<IEnumerable<AutresProjet>>> GetAutresProjetByType(int id)
        {
            var autresProjet = await _context.AutresProjet.Where(s => s.AutresTypesProjetId==id&&!s.IsDeleted).ToListAsync(); ;

            if (autresProjet == null)
            {
                return NotFound();
            }

            return autresProjet;
        }

        // PUT: api/AutresProjets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutresProjet(int id, AutresProjet autresProjet)
        {
            if (id != autresProjet.Id)
            {
                return BadRequest();
            }

            autresProjet.UpdatedAt = DateTime.Now.ToLongDateString();
            _context.Entry(autresProjet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutresProjetExists(id))
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

        // POST: api/AutresProjets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AutresProjet>> PostAutresProjet(AutresProjet autresProjet)
        {
            autresProjet.CreatedAt = DateTime.Now.ToLongDateString();
            _context.AutresProjet.Add(autresProjet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutresProjet", new { id = autresProjet.Id }, autresProjet);
        }

        // DELETE: api/AutresProjets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutresProjet(int id)
        {
            var autresProjet = await _context.AutresProjet.FindAsync(id);
            if (autresProjet == null)
            {
                return NotFound();
            }

            autresProjet.IsDeleted = true;
            autresProjet.DeletedAt = DateTime.Now.ToLongDateString();
            _context.Entry(autresProjet).State = EntityState.Modified;
            //_context.AutresProjet.Remove(autresProjet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AutresProjetExists(int id)
        {
            return _context.AutresProjet.Any(e => e.Id == id);
        }
    }
}
