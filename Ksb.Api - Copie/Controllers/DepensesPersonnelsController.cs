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
    public class DepensesPersonnelsController : ControllerBase
    {
        private readonly KsbApiContext _context;

        public DepensesPersonnelsController(KsbApiContext context)
        {
            _context = context;
        }

        // GET: api/DepensesPersonnels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepensesPersonnel>>> GetDepensesPersonnel()
        {
            return await _context.DepensesPersonnel.Where(s => !s.IsDeleted).ToListAsync();
        }

        // GET: api/DepensesPersonnels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepensesPersonnel>> GetDepensesPersonnel(int id)
        {
            var depensesPersonnel = await _context.DepensesPersonnel.FindAsync(id);

            if (depensesPersonnel == null)
            {
                return NotFound();
            }

            return depensesPersonnel;
        }

        // PUT: api/DepensesPersonnels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepensesPersonnel(int id, DepensesPersonnel depensesPersonnel)
        {
            if (id != depensesPersonnel.Id)
            {
                return BadRequest();
            }

            depensesPersonnel.UpdatedAt = DateTime.Now.ToLongDateString();
            _context.Entry(depensesPersonnel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepensesPersonnelExists(id))
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

        // POST: api/DepensesPersonnels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DepensesPersonnel>> PostDepensesPersonnel(DepensesPersonnel depensesPersonnel)
        {
            depensesPersonnel.CreatedAt = DateTime.Now.ToLongDateString();
            _context.DepensesPersonnel.Add(depensesPersonnel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepensesPersonnel", new { id = depensesPersonnel.Id }, depensesPersonnel);
        }

        // DELETE: api/DepensesPersonnels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepensesPersonnel(int id)
        {
            var depensesPersonnel = await _context.DepensesPersonnel.FindAsync(id);
            if (depensesPersonnel == null)
            {
                return NotFound();
            }
            depensesPersonnel.IsDeleted = true;
            depensesPersonnel.DeletedAt = DateTime.Now.ToLongDateString();
            _context.Entry(depensesPersonnel).State = EntityState.Modified;
            //_context.DepensesPersonnel.Remove(depensesPersonnel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepensesPersonnelExists(int id)
        {
            return _context.DepensesPersonnel.Any(e => e.Id == id);
        }
    }
}
