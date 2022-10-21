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
    public class TypeDepenseAutresController : ControllerBase
    {
        private readonly KsbApiContext _context;

        public TypeDepenseAutresController(KsbApiContext context)
        {
            _context = context;
        }

        // GET: api/TypeDepenseAutres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeDepenseAutre>>> GetTypeDepenseAutre()
        {
            return await _context.TypeDepenseAutre.Include("AutresTypesProjet").Where(td=>!td.IsDeleted).ToListAsync();
        }

        // GET: api/TypeDepenseAutres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeDepenseAutre>> GetTypeDepenseAutre(int id)
        {
            var typeDepenseAutre = await _context.TypeDepenseAutre.FindAsync(id);

            if (typeDepenseAutre == null)
            {
                return NotFound();
            }

            return typeDepenseAutre;
        }

        // PUT: api/TypeDepenseAutres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeDepenseAutre(int id, TypeDepenseAutre typeDepenseAutre)
        {
            if (id != typeDepenseAutre.Id)
            {
                return BadRequest();
            }

            typeDepenseAutre.UpdatedAt = DateTime.Now.ToLongDateString();
            _context.Entry(typeDepenseAutre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeDepenseAutreExists(id))
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

        // POST: api/TypeDepenseAutres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeDepenseAutre>> PostTypeDepenseAutre(TypeDepenseAutre typeDepenseAutre)
        {
            typeDepenseAutre.CreatedAt = DateTime.Now.ToLongDateString();
            _context.TypeDepenseAutre.Add(typeDepenseAutre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeDepenseAutre", new { id = typeDepenseAutre.Id }, typeDepenseAutre);
        }

        // DELETE: api/TypeDepenseAutres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeDepenseAutre(int id)
        {
            var typeDepenseAutre = await _context.TypeDepenseAutre.FindAsync(id);
            if (typeDepenseAutre == null)
            {
                return NotFound();
            }

            typeDepenseAutre.IsDeleted = true;
            typeDepenseAutre.DeletedAt = DateTime.Now.ToLongDateString();
            _context.Entry(typeDepenseAutre).State = EntityState.Modified;
            //_context.TypeDepenseAutre.Remove(typeDepenseAutre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeDepenseAutreExists(int id)
        {
            return _context.TypeDepenseAutre.Any(e => e.Id == id);
        }
    }
}
