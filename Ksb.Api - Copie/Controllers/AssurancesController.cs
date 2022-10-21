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
    public class AssurancesController : ControllerBase
    {
        private readonly KsbApiContext _context;

        public AssurancesController(KsbApiContext context)
        {
            _context = context;
        }

        // GET: api/Assurances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assurance>>> GetAssurance()
        {
            return await _context.Assurance.Include("Employe").Where(s => !s.IsDeleted).ToListAsync();
        }

        // GET: api/Assurances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Assurance>> GetAssurance(int id)
        {
            var assurance = await _context.Assurance.FindAsync(id);

            if (assurance == null)
            {
                return NotFound();
            }

            return assurance;
        }

        // PUT: api/Assurances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssurance(int id, Assurance assurance)
        {
            if (id != assurance.Id)
            {
                return BadRequest();
            }

            assurance.UpdatedAt = DateTime.Now.ToLongDateString(); 
            _context.Entry(assurance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssuranceExists(id))
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

        // POST: api/Assurances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AssurancePerso>> PostAssurance(AssurancePerso assurances)
        {
            foreach(var res in assurances.Employes)
            {
                var assurance = new Assurance
                {
                    code = assurances.code,
                    Montant = assurances.Montant,
                    CreatedAt = DateTime.Now.ToLongDateString(),
                    Date = assurances.Date,
                    EmployeId = res.Id
                };
                _context.Assurance.Add(assurance);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetAssurance", null, assurances);
        }

        // POST: api/Assurances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Assurance>> PostAssurance(Assurance assurance)
        //{
        //    _context.Assurance.Add(assurance);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAssurance", new { id = assurance.Id }, assurance);
        //}

        // DELETE: api/Assurances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssurance(int id)
        {
            var assurance = await _context.Assurance.FindAsync(id);
            if (assurance == null)
            {
                return NotFound();
            }

            assurance.IsDeleted = true;
            assurance.DeletedAt = DateTime.Now.ToLongDateString();

            _context.Entry(assurance).State = EntityState.Modified;
            //_context.Assurance.Remove(assurance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssuranceExists(int id)
        {
            return _context.Assurance.Any(e => e.Id == id);
        }
    }
    public class AssurancePerso 
    {
        public string code { get; set; }
        public DateTime Date { get; set; }
        public int Montant { get; set; }
        public int EmployeId { get; set; }
        public IEnumerable<Employe> Employes { get; set; }

    }
}
