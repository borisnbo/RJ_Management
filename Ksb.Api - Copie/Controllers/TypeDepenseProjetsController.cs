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
    public class TypeDepenseProjetsController : ControllerBase
    {
        private readonly KsbApiContext _context;

        public TypeDepenseProjetsController(KsbApiContext context)
        {
            _context = context;
        }

        // GET: api/TypeDepenseProjets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeDepenseProjet>>> GetTypeDepenseProjet()
        {
            return await _context.TypeDepenseProjet.Where(td=>!td.IsDeleted).ToListAsync();
        }

        // GET: api/TypeDepenseProjets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeDepenseProjet>> GetTypeDepenseProjet(int id)
        {
            var typeDepenseProjet = await _context.TypeDepenseProjet.FindAsync(id);

            if (typeDepenseProjet == null)
            {
                return NotFound();
            }

            return typeDepenseProjet;
        }

        // PUT: api/TypeDepenseProjets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeDepenseProjet(int id, TypeDepenseProjet typeDepenseProjet)
        {
            if (id != typeDepenseProjet.Id)
            {
                return BadRequest();
            }
            typeDepenseProjet.UpdatedAt = DateTime.Now.ToLongDateString();
            _context.Entry(typeDepenseProjet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeDepenseProjetExists(id))
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

        // POST: api/TypeDepenseProjets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeDepenseProjet>> PostTypeDepenseProjet(TypeDepenseProjet typeDepenseProjet)
        {
            typeDepenseProjet.CreatedAt = DateTime.Now.ToLongDateString();
            _context.TypeDepenseProjet.Add(typeDepenseProjet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeDepenseProjet", new { id = typeDepenseProjet.Id }, typeDepenseProjet);
        }

        // DELETE: api/TypeDepenseProjets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeDepenseProjet(int id)
        {
            var typeDepenseProjet = await _context.TypeDepenseProjet.FindAsync(id);
            if (typeDepenseProjet == null)
            {
                return NotFound();
            }

            typeDepenseProjet.IsDeleted = true;
            typeDepenseProjet.DeletedAt = DateTime.Now.ToLongDateString();
            _context.Entry(typeDepenseProjet).State = EntityState.Modified;
            //_context.TypeDepenseProjet.Remove(typeDepenseProjet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeDepenseProjetExists(int id)
        {
            return _context.TypeDepenseProjet.Any(e => e.Id == id);
        }
    }
}
