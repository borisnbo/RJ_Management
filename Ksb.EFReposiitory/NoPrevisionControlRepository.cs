using Ksb.Api.Data;
using Ksb.Domain;
using Ksb.EFReposiitory.Generic;
using Ksb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksb.EFReposiitory
{
    public class AssuranceRepository : GenericRepository<Assurance>, IAssuranceRepository
    {
        public AssuranceRepository(KsbApiContext context) : base(context)
        { }
    }
    public class AutresProjetRepository : GenericRepository<AutresProjet>, IAutresProjetRepository
    {
        public AutresProjetRepository(KsbApiContext context) : base(context)
        { }
    }
    public class AutresTypesProjetRepository : GenericRepository<AutresTypesProjet>, IAutresTypesProjetRepository
    {
        public AutresTypesProjetRepository(KsbApiContext context) : base(context)
        { }
    }
    public class CaisseRepository : GenericRepository<Caisse>, ICaisseRepository
    {
        public CaisseRepository(KsbApiContext context) : base(context)
        { }
    }
    public class ChantierRepository : GenericRepository<Chantier>, IChantierRepository
    {
        public ChantierRepository(KsbApiContext context) : base(context)
        { }
    }
    public class EmployeRepository : GenericRepository<Employe>, IEmployeRepository
    {
        public EmployeRepository(KsbApiContext context) : base(context)
        { }
    }
    public class EquipementRepository : GenericRepository<Equipement>, IEquipementRepository
    {
        public EquipementRepository(KsbApiContext context) : base(context)
        { }
    }
    public class FinancementRepository : GenericRepository<Financement>, IFinancementRepository
    {
        public FinancementRepository(KsbApiContext context) : base(context)
        { }
    }
    public class ImpotRepository : GenericRepository<Impot>, IImpotRepository
    {
        public ImpotRepository(KsbApiContext context) : base(context)
        { }
    }
    public class PosteRepository : GenericRepository<Poste>, IPosteRepository
    {
        public PosteRepository(KsbApiContext context) : base(context)
        { }
    }
    public class ProjetRepository : GenericRepository<Projet>, IProjetRepository
    {
        public ProjetRepository(KsbApiContext context) : base(context)
        { }
    }
    public class TypeDepenseProjetRepository : GenericRepository<TypeDepenseProjet>, ITypeDepenseProjetRepository
    {
        public TypeDepenseProjetRepository(KsbApiContext context) : base(context)
        { }
    }
    public class TypeProjetRepository : GenericRepository<TypeProjet>, ITypeProjetRepository
    {
        public TypeProjetRepository(KsbApiContext context) : base(context)
        { }
    }
    public class VoitureRepository : GenericRepository<Voiture>, IVoitureRepository
    {
        public VoitureRepository(KsbApiContext context) : base(context)
        { }
    }
}
