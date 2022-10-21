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
    public class SalairesController : ControllerBase
    {
        private readonly KsbApiContext _context;

        public SalairesController(KsbApiContext context)
        {
            _context = context;
        }

        // GET: api/Salaires
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salaire>>> GetSalaire()
        {
            return await _context.Salaire.Include("Employe")
                .Where(s=>!s.IsDeleted).ToListAsync();
        }

        // GET: api/Salaires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Salaire>> GetSalaire(int id)
        {
            var salaire = await _context.Salaire.FindAsync(id);

            if (salaire == null)
            {
                return NotFound();
            }

            return salaire;
        }

        // PUT: api/Salaires/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalaire(int id, Salaire salaire)
        {
            if (id != salaire.Id)
            {
                return BadRequest();
            }

            salaire.UpdatedAt = DateTime.Now.ToLongDateString();
            _context.Entry(salaire).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaireExists(id))
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

        // POST: api/Salaires
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalairePerso>> PostSalaire(SalairePerso salaires)
        {
            foreach (var res in salaires.Employes)
            {
                var salaire = new Salaire
                {
                    EmployeId = res.Id,
                    code = salaires.code,
                    Periode = salaires.Periode,
                    Montant = salaires.Montant,
                    CreatedAt = DateTime.Now.ToLongDateString()
            };
                _context.Salaire.Add(salaire);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetSalaire", null);
        }
        //public async Task<ActionResult<Salaire>> PostSalaire (Salaire salaire)
        //{
        //    _context.Salaire.Add(salaire);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetSalaire", null);
        //}

        // DELETE: api/Salaires/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalaire(int id)
        {
            var salaire = await _context.Salaire.FindAsync(id);
            if (salaire == null)
            {
                return NotFound();
            }
            salaire.IsDeleted = true;
            salaire.DeletedAt = DateTime.Now.ToLongDateString();
            _context.Entry(salaire).State = EntityState.Modified;
            //_context.Salaire.Remove(salaire);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalaireExists(int id)
        {
            return _context.Salaire.Any(e => e.Id == id);
        }
    }

    public class SalairePerso
    {

        public string code { get; set; }
        public string Periode { get; set; }
        public int EmployeId { get; set; }
        public IEnumerable<Employe> Employes { get; set; }
        public double Montant { get; set; }
    }

}
