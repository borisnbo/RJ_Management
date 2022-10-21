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
    public class PersonnelsProjetsController : ControllerBase
    {
        private readonly KsbApiContext _context;

        public PersonnelsProjetsController(KsbApiContext context)
        {
            _context = context;
        }

        // GET: api/PersonnelsProjets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonnelsProjet>>> GetPersonnelsProjet()
        {
            return await _context.PersonnelsProjet.Include("Employe").Where(s => !s.IsDeleted).ToListAsync();
        }

        // GET: api/PersonnelsProjets/5
        [HttpGet("ByProject/{id}")]
        public async Task<ActionResult<IEnumerable<PersonnelsProjet>>> GetPersonnelsProjetByProjet(int id)
        {
            var personnelsProjet = await _context.PersonnelsProjet.Include("Employe").Where(s=>s.ProjetId==id&&!s.IsDeleted).ToListAsync();

            if (personnelsProjet == null)
            {
                return NotFound();
            }

            return personnelsProjet;
        }
        // GET: api/PersonnelsProjets/5
        [HttpGet("ByPEmp/{id}")]
        public async Task<ActionResult<IEnumerable<PersonnelsEmp>>> GetPersonnelsEmployePerso(int id)
        {
            var personnelsProjet = await _context.PersonnelsProjet.Include("Employe").Where(s=>s.ProjetId==id&&!s.IsDeleted).ToListAsync();
            var list = new List<PersonnelsEmp>();
            foreach(var res in personnelsProjet)
            {
                list.Add(new PersonnelsEmp { id = res.Id, nom = res.Employe.Nom });
            }
            if (personnelsProjet == null)
            {
                return NotFound();
            }

            return list;
        }

        // GET: api/PersonnelsProjets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonnelsProjet>> GetPersonnelsProjet(int id)
        {
            var personnelsProjet = await _context.PersonnelsProjet.FindAsync(id);

            if (personnelsProjet == null)
            {
                return NotFound();
            }

            return personnelsProjet;
        }

        // PUT: api/PersonnelsProjets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonnelsProjet(int id, PersonnelsProjet personnelsProjet)
        {
            if (id != personnelsProjet.Id)
            {
                return BadRequest();
            }
            personnelsProjet.UpdatedAt = DateTime.Now.ToLongDateString();
            _context.Entry(personnelsProjet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonnelsProjetExists(id))
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

        // POST: api/PersonnelsProjets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonnelsProjetPerso>> PostPersonnelsProjet(PersonnelsProjetPerso personnelsProjets)
        {
            for(int i=0; i<personnelsProjets.Employes.Count(); i++)
            {
                var emp = await _context.PersonnelsProjet.Where(p=>p.EmployeId == personnelsProjets.Employes[i].Id&&p.ProjetId== personnelsProjets.Projet.Id).FirstOrDefaultAsync();
                if (emp == null)
                {
                    var personnelsProjet = new PersonnelsProjet
                    {
                        EmployeId = personnelsProjets.Employes[i].Id,
                        ProjetId = personnelsProjets.Projet.Id,
                        CreatedAt = DateTime.Now.ToLongDateString()
                };
                    _context.PersonnelsProjet.Add(personnelsProjet);
                }
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonnelsProjet", null, personnelsProjets);
        }

        // POST: api/PersonnelsProjets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<PersonnelsProjet>> PostPersonnelsProjet(PersonnelsProjet personnelsProjet)
        //{
        //    _context.PersonnelsProjet.Add(personnelsProjet);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPersonnelsProjet", new { id = personnelsProjet.Id }, personnelsProjet);
        //}

        // DELETE: api/PersonnelsProjets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonnelsProjet(int id)
        {
            var personnelsProjet = await _context.PersonnelsProjet.FindAsync(id);
            if (personnelsProjet == null)
            {
                return NotFound();
            }

            personnelsProjet.IsDeleted = true;
            personnelsProjet.DeletedAt = DateTime.Now.ToLongDateString();
            _context.Entry(personnelsProjet).State = EntityState.Modified;
            //_context.PersonnelsProjet.Remove(personnelsProjet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonnelsProjetExists(int id)
        {
            return _context.PersonnelsProjet.Any(e => e.Id == id);
        }
    }
    public class PersonnelsProjetPerso
    {
        public Employe[] Employes { get; set; }
        public Projet Projet { get; set; }
    }
    public class PersonnelsEmp
    {
        public string nom { get; set; }
        public int id { get; set; }
    }
}
