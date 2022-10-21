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
    public class RationPersonnelsController : ControllerBase
    {
        private readonly KsbApiContext _context;

        public RationPersonnelsController(KsbApiContext context)
        {
            _context = context;
        }

        // GET: api/RationPersonnels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RationPersonnel>>> GetRationPersonnel()
        {
            var res = await _context.RationPersonnel.Include("PersonnelsProjet").
                Include("PersonnelsProjet.Employe").Where(s=>!s.IsDeleted).ToListAsync();
            return res;
        }

        // GET: api/RationPersonnels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RationPersonnel>> GetRationPersonnel(int id)
        {
            var rationPersonnel = await _context.RationPersonnel.FindAsync(id);

            if (rationPersonnel == null)
            {
                return NotFound();
            }

            return rationPersonnel;
        }

        // PUT: api/RationPersonnels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRationPersonnel(int id, RationPersonnel rationPersonnel)
        {
            if (id != rationPersonnel.Id)
            {
                return BadRequest();
            }

            rationPersonnel.UpdatedAt = DateTime.Now.ToLongDateString();
            _context.Entry(rationPersonnel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RationPersonnelExists(id))
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

        // POST: api/RationPersonnels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RationPersonnelPerso>> PostRationPersonnel(RationPersonnelPerso rationPersonnels)
        {
            foreach(var res in rationPersonnels.personnels)
            {
                var rationPersonnel = new RationPersonnel
                {
                    code = rationPersonnels.code,
                    Montant = rationPersonnels.Montant,
                    CreatedAt = DateTime.Now.ToLongDateString(),
                    PersonnelsProjetId = res.Id,
                    Date = rationPersonnels.Date
                };
                _context.RationPersonnel.Add(rationPersonnel);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetRationPersonnel", null, rationPersonnels);
        }

        // POST: api/RationPersonnels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<RationPersonnel>> PostRationPersonnel(RationPersonnel rationPersonnel)
        //{
        //    _context.RationPersonnel.Add(rationPersonnel);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetRationPersonnel", new { id = rationPersonnel.Id }, rationPersonnel);
        //}

        // DELETE: api/RationPersonnels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRationPersonnel(int id)
        {
            var rationPersonnel = await _context.RationPersonnel.FindAsync(id);
            if (rationPersonnel == null)
            {
                return NotFound();
            }

            rationPersonnel.IsDeleted = true;
            rationPersonnel.DeletedAt = DateTime.Now.ToLongDateString();
            _context.Entry(rationPersonnel).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RationPersonnelExists(int id)
        {
            return _context.RationPersonnel.Any(e => e.Id == id);
        }
    }
    public class RationPersonnelPerso
    {
        public long Montant { get; set; }
        public DateTime Date { get; set; }
        public string code { get; set; }
        public IEnumerable<Employe> personnels { get; set; }
    }
}
