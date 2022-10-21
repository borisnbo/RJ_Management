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
    public class CaissesController : ControllerBase
    {
        private readonly KsbApiContext _context;

        public CaissesController(KsbApiContext context)
        {
            _context = context;
        }

        // GET: api/Caisses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Caisse>>> GetCaisse()
        {
            return await _context.Caisse.Where(s => !s.IsDeleted).ToListAsync();
        }

        // GET: api/Caisses/Depenses
        [HttpGet("Depenses")]
        public async Task<ActionResult<CaissePerso>> GetCaisseDepense()
        {
            var dp = _context.DepensesProjet.Where(s => !s.IsDeleted).ToList();
            var tp = _context.TransportPersonnel.Where(s => !s.IsDeleted).ToList();
            var rp = _context.RationPersonnel.Where(s => !s.IsDeleted).ToList();
            var adp = _context.AutresDepense.Where(s => !s.IsDeleted).ToList();
            var sl = _context.Salaire.Where(s => !s.IsDeleted).ToList();
            var imp = _context.Impot.Where(s => !s.IsDeleted).ToList();
            var form = _context.Formation.Where(s => !s.IsDeleted).ToList();
            var assur = _context.Assurance.Where(s => !s.IsDeleted).ToList();

            double total = 0;
            foreach (var d in dp)
            {
                total += d.Quantite * d.PrixUnitaire;
            }
            foreach (var d in tp)
            {
                total += d.Montant;
            }
            foreach (var d in rp)
            {
                total += d.Montant;
            }
            foreach (var d in adp)
            {
                total += d.Quantite * d.PrixUnitaire;
            }
            foreach (var d in sl)
            {
                total += d.Montant;
            }
            foreach (var d in imp)
            {
                total += d.Montant;
            }
            foreach (var d in form)
            {
                total += d.Montant;
            }
            foreach (var d in assur)
            {
                total += d.Montant;
            }
            var caisse = new CaissePerso { Depenses = total };
            return CreatedAtAction("GetCaisse", new { Depenses = caisse.Depenses }, caisse);
        }
        // GET: api/Caisses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Caisse>> GetCaisse(int id)
        {
            var caisse = await _context.Caisse.FindAsync(id);

            if (caisse == null)
            {
                return NotFound();
            }

            return caisse;
        }

        // PUT: api/Caisses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaisse(int id, Caisse caisse)
        {
            if (id != caisse.Id)
            {
                return BadRequest();
            }

            _context.Entry(caisse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaisseExists(id))
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

        // POST: api/Caisses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Caisse>> PostCaisse(Caisse caisse)
        {
            _context.Caisse.Add(caisse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCaisse", new { id = caisse.Id }, caisse);
        }

        // DELETE: api/Caisses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaisse(int id)
        {
            var caisse = await _context.Caisse.FindAsync(id);
            if (caisse == null)
            {
                return NotFound();
            }

            _context.Caisse.Remove(caisse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CaisseExists(int id)
        {
            return _context.Caisse.Any(e => e.Id == id);
        }
    }
    public class CaissePerso
    {
        public double Depenses { get; set; }
        public double Entrees { get; set; }
    }
}
