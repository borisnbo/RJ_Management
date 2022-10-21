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
    public class AutresTypesProjetsController : ControllerBase
    {
        private readonly KsbApiContext _context;

        public AutresTypesProjetsController(KsbApiContext context)
        {
            _context = context;
        }

        // GET: api/AutresTypesProjets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutresTypesProjet>>> GetAutresTypesProjet()
        {
            return await _context.AutresTypesProjet.Where(s => !s.IsDeleted).ToListAsync();
        }

        // GET: api/AutresTypesProjets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AutresTypesProjet>> GetAutresTypesProjet(int id)
        {
            var autresTypesProjet = await _context.AutresTypesProjet.FindAsync(id);

            if (autresTypesProjet == null)
            {
                return NotFound();
            }

            return autresTypesProjet;
        }

        // PUT: api/AutresTypesProjets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutresTypesProjet(int id, AutresTypesProjet autresTypesProjet)
        {
            if (id != autresTypesProjet.Id)
            {
                return BadRequest();
            }

            autresTypesProjet.UpdatedAt = DateTime.Now.ToLongDateString();
            _context.Entry(autresTypesProjet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutresTypesProjetExists(id))
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

        // POST: api/AutresTypesProjets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AutresTypesProjet>> PostAutresTypesProjet(AutresTypesProjet autresTypesProjet)
        {
            autresTypesProjet.CreatedAt = DateTime.Now.ToLongDateString();
            _context.AutresTypesProjet.Add(autresTypesProjet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutresTypesProjet", new { id = autresTypesProjet.Id }, autresTypesProjet);
        }

        // DELETE: api/AutresTypesProjets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutresTypesProjet(int id)
        {
            var autresTypesProjet = await _context.AutresTypesProjet.FindAsync(id);
            if (autresTypesProjet == null)
            {
                return NotFound();
            }

            autresTypesProjet.IsDeleted = true;
            autresTypesProjet.DeletedAt = DateTime.Now.ToLongDateString();

            _context.Entry(autresTypesProjet).State = EntityState.Modified;
            //_context.AutresTypesProjet.Remove(autresTypesProjet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AutresTypesProjetExists(int id)
        {
            return _context.AutresTypesProjet.Any(e => e.Id == id);
        }
    }
}
