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
    public class FormationsController : ControllerBase
    {
        private readonly KsbApiContext _context;

        public FormationsController(KsbApiContext context)
        {
            _context = context;
        }

        // GET: api/Formations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Formation>>> GetFormation()
        {
            return await _context.Formation.Include("Employe").Where(f=>!f.IsDeleted).ToListAsync();
        }

        // GET: api/Formations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Formation>> GetFormation(int id)
        {
            var formation = await _context.Formation.FindAsync(id);

            if (formation == null)
            {
                return NotFound();
            }

            return formation;
        }

        // PUT: api/Formations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormation(int id, Formation formation)
        {
            if (id != formation.Id)
            {
                return BadRequest();
            }
            formation.UpdatedAt=DateTime.Now.ToLongDateString();
            _context.Entry(formation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormationExists(id))
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

        // POST: api/Formations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FormationPerso>> PostFormation(FormationPerso formations)
        {
            var p = formations;
            foreach(var res in formations.Employes)
            {
                var formation = new Formation
                {
                    EmployeId = res.Id,
                    Montant = formations.Montant,
                    code = formations.code,
                    Date = formations.Date,
                    TypeFormation = formations.TypeFormation,
                    CreatedAt = DateTime.Now.ToLongDateString()
            };

                _context.Formation.Add(formation);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetFormation", null, formations);
        }


        // POST: api/Formations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Formation>> PostFormation(Formation formation)
        //{
        //    _context.Formation.Add(formation);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetFormation", new { id = formation.Id }, formation);
        //}

        // DELETE: api/Formations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormation(int id)
        {
            var formation = await _context.Formation.FindAsync(id);
            if (formation == null)
            {
                return NotFound();
            }

            formation.IsDeleted = true;
            formation.DeletedAt = DateTime.Now.ToLongDateString();
            _context.Entry(formation).State = EntityState.Modified;
            //_context.Formation.Remove(formation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FormationExists(int id)
        {
            return _context.Formation.Any(e => e.Id == id);
        }
    }
    public class FormationPerso
    {
        public int EmployeId { get; set; }
        public IEnumerable<Employe> Employes { get; set; }
        public double Montant { get; set; }
        public string TypeFormation { get; set; }
        public string code { get; set; }
        public DateTime Date { get; set; }
    }
}
