using Ksb.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksb.Repository
{
    public interface IAssuranceRepository : IGenericRepository<Assurance>
    { }
    public interface IAutresDepenseRepository : IGenericRepository<AutresDepense>
    { }
    public interface IAutresProjetRepository : IGenericRepository<AutresProjet>
    { }
    public interface IAutresTypesProjetRepository : IGenericRepository<AutresTypesProjet>
    { }
    public interface ICaisseRepository : IGenericRepository<Caisse>
    { }
    public interface IChantierRepository : IGenericRepository<Chantier>
    { }
    public interface IDepensesPersonnelRepository : IGenericRepository<DepensesPersonnel>
    { }
    public interface IDepensesProjetRepository : IGenericRepository<DepensesProjet>
    { }
    public interface IEmployeRepository : IGenericRepository<Employe>
    { }
    public interface IEquipementRepository : IGenericRepository<Equipement>
    { }
    public interface IFinancementRepository : IGenericRepository<Financement>
    { }
    public interface IFormationRepository : IGenericRepository<Formation>
    { }
    public interface IImpotRepository : IGenericRepository<Impot>
    { }
    public interface IPersonnelsProjetRepository : IGenericRepository<PersonnelsProjet>
    { }
    public interface IPosteRepository : IGenericRepository<Poste>
    { }
    public interface IProjetRepository : IGenericRepository<Projet>
    { }
    public interface IRationPersonnelRepository : IGenericRepository<RationPersonnel>
    { }
    public interface ISalaireRepository : IGenericRepository<Salaire>
    { }
    public interface ITransportPersonnelRepository : IGenericRepository<TransportPersonnel>
    { }
    public interface ITypeDepenseAutreRepository : IGenericRepository<TypeDepenseAutre>
    { }
    public interface ITypeDepenseProjetRepository : IGenericRepository<TypeDepenseProjet>
    { }
    public interface ITypeProjetRepository : IGenericRepository<TypeProjet>
    { }
    public interface IVoitureRepository : IGenericRepository<Voiture>
    { }
}
