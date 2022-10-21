using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ksb.Domain;

namespace Ksb.Api.Data
{
    public class KsbApiContext : DbContext
    {
        public KsbApiContext (DbContextOptions<KsbApiContext> options)
            : base(options)
        {
        }

        public DbSet<Ksb.Domain.Employe> Employe { get; set; }

        public DbSet<Ksb.Domain.Impot> Impot { get; set; }

        public DbSet<Ksb.Domain.Projet> Projet { get; set; }

        public DbSet<Ksb.Domain.Poste> Poste { get; set; }

        public DbSet<Ksb.Domain.Salaire> Salaire { get; set; }

        public DbSet<Ksb.Domain.TypeProjet> TypeProjet { get; set; }

        public DbSet<Ksb.Domain.Voiture> Voiture { get; set; }

        public DbSet<Ksb.Domain.Chantier> Chantier { get; set; }

        public DbSet<Ksb.Domain.Equipement> Equipement { get; set; }

        public DbSet<Ksb.Domain.PersonnelsProjet> PersonnelsProjet { get; set; }

        public DbSet<Ksb.Domain.TypeDepenseProjet> TypeDepenseProjet { get; set; }

        public DbSet<Ksb.Domain.TypeDepenseAutre> TypeDepenseAutre { get; set; }

        public DbSet<Ksb.Domain.TransportPersonnel> TransportPersonnel { get; set; }

        public DbSet<Ksb.Domain.AutresDepense> AutresDepense { get; set; }

        public DbSet<Ksb.Domain.AutresTypesProjet> AutresTypesProjet { get; set; }

        public DbSet<Ksb.Domain.AutresProjet> AutresProjet { get; set; }

        public DbSet<Ksb.Domain.Formation> Formation { get; set; }

        public DbSet<Ksb.Domain.Assurance> Assurance { get; set; }

        public DbSet<Ksb.Domain.Financement> Financement { get; set; }

        public DbSet<Ksb.Domain.Caisse> Caisse { get; set; }

        public DbSet<Ksb.Domain.DepensesPersonnel> DepensesPersonnel { get; set; }

        public DbSet<Ksb.Domain.DepensesProjet> DepensesProjet { get; set; }

        public DbSet<Ksb.Domain.RationPersonnel> RationPersonnel { get; set; }
    }
}
