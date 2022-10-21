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
    public class TypeProjetsController : ControllerBase
    {
        private readonly KsbApiContext _context;

        public TypeProjetsController(KsbApiContext context)
        {
            _context = context;
        }

        // GET: api/TypeProjets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeProjet>>> GetTypeProjet()
        {
            return await _context.TypeProjet.Where(td => !td.IsDeleted).ToListAsync();
        }

        // GET: api/TypeProjets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeProjet>> GetTypeProjet(int id)
        {
            var typeProjet = await _context.TypeProjet.FindAsync(id);

            if (typeProjet == null)
            {
                return NotFound();
            }

            return typeProjet;
        }

        // PUT: api/TypeProjets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeProjet(int id, TypeProjet typeProjet)
        {
            if (id != typeProjet.Id)
            {
                return BadRequest();
            }

            typeProjet.UpdatedAt = DateTime.Now.ToLongDateString();
            _context.Entry(typeProjet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeProjetExists(id))
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

        // POST: api/TypeProjets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeProjet>> PostTypeProjet(TypeProjet typeProjet)
        {
            typeProjet.CreatedAt = DateTime.Now.ToLongDateString();
            _context.TypeProjet.Add(typeProjet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeProjet", new { id = typeProjet.Id }, typeProjet);
        }

        // DELETE: api/TypeProjets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeProjet(int id)
        {
            var typeProjet = await _context.TypeProjet.FindAsync(id);
            if (typeProjet == null)
            {
                return NotFound();
            }
            typeProjet.IsDeleted = true;
            typeProjet.DeletedAt = DateTime.Now.ToLongDateString();
            _context.Entry(typeProjet).State = EntityState.Modified;
            //_context.TypeProjet.Remove(typeProjet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeProjetExists(int id)
        {
            return _context.TypeProjet.Any(e => e.Id == id);
        }
    }
}
