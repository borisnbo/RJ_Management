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
    public class TransportPersonnelsController : ControllerBase
    {
        private readonly KsbApiContext _context;

        public TransportPersonnelsController(KsbApiContext context)
        {
            _context = context;
        }

        // GET: api/TransportPersonnels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransportPersonnel>>> GetTransportPersonnel()
        {
            return await _context.TransportPersonnel.Where(s => !s.IsDeleted).Include("PersonnelsProjet").
                Include("PersonnelsProjet.Employe").ToListAsync();
        }

        // GET: api/TransportPersonnels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransportPersonnel>> GetTransportPersonnel(int id)
        {
            var transportPersonnel = await _context.TransportPersonnel.FindAsync(id);

            if (transportPersonnel == null)
            {
                return NotFound();
            }

            return transportPersonnel;
        }

        // PUT: api/TransportPersonnels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransportPersonnel(int id, TransportPersonnel transportPersonnel)
        {
            if (id != transportPersonnel.Id)
            {
                return BadRequest();
            }

            transportPersonnel.UpdatedAt = DateTime.Now.ToLongDateString();
            _context.Entry(transportPersonnel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportPersonnelExists(id))
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

        // POST: api/TransportPersonnels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TransportPersonnelPerso>> PostTransportPersonnel(TransportPersonnelPerso transportPersonnels)
        {

            foreach(var res in transportPersonnels.Personnels)
            {
                var transportPersonnel = new TransportPersonnel
                {
                    Montant = transportPersonnels.Montant,
                    CreatedAt = DateTime.Now.ToLongDateString(),
                    code = transportPersonnels.code,
                    PersonnelsProjetId = res.Id
                };
                _context.TransportPersonnel.Add(transportPersonnel);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetTransportPersonnel", null, transportPersonnels);
        }

        //// POST: api/TransportPersonnels
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<TransportPersonnel>> PostTransportPersonnel(TransportPersonnel transportPersonnel)
        //{
        //    _context.TransportPersonnel.Add(transportPersonnel);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetTransportPersonnel", new { id = transportPersonnel.Id }, transportPersonnel);
        //}
        // DELETE: api/TransportPersonnels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransportPersonnel(int id)
        {
            var transportPersonnel = await _context.TransportPersonnel.FindAsync(id);
            if (transportPersonnel == null)
            {
                return NotFound();
            }
            transportPersonnel.IsDeleted = true;
            transportPersonnel.DeletedAt = DateTime.Now.ToLongDateString();
            _context.Entry(transportPersonnel).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransportPersonnelExists(int id)
        {
            return _context.TransportPersonnel.Any(e => e.Id == id);
        }
    }
    public class TransportPersonnelPerso
    {
        public string code { get; set; }
        public IEnumerable<Employe> Personnels { get; set; }
        public long Montant { get; set; }
    }
}
