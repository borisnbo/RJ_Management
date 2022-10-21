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
    public class TypeDepenseAutreRepository : GenericRepository<TypeDepenseAutre>, ITypeDepenseAutreRepository
    {
        public TypeDepenseAutreRepository(KsbApiContext context) : base(context)
        { }
    }
    public class TransportPersonnelRepository : GenericRepository<TransportPersonnel>, ITransportPersonnelRepository
    {
        public TransportPersonnelRepository(KsbApiContext context) : base(context)
        { }
    }
    public class RationPersonnelRepository : GenericRepository<RationPersonnel>, IRationPersonnelRepository
    {
        public RationPersonnelRepository(KsbApiContext context) : base(context)
        { }
    }
    public class PersonnelsProjetRepository : GenericRepository<PersonnelsProjet>, IPersonnelsProjetRepository
    {
        public PersonnelsProjetRepository(KsbApiContext context) : base(context)
        { }
    }
    public class FormationRepository : GenericRepository<Formation>, IFormationRepository
    {
        public FormationRepository(KsbApiContext context) : base(context)
        { }
    }
    public class DepensesProjetRepository : GenericRepository<DepensesProjet>, IDepensesProjetRepository
    {
        public DepensesProjetRepository(KsbApiContext context) : base(context)
        { }
    }
    public class DepensesPersonnelRepository : GenericRepository<DepensesPersonnel>, IDepensesPersonnelRepository
    {
        public DepensesPersonnelRepository(KsbApiContext context) : base(context)
        { }
    }
    public class AutresDepenseRepository : GenericRepository<AutresDepense>, IAutresDepenseRepository
    {
        public AutresDepenseRepository(KsbApiContext context) : base(context)
        { }
    }
    public class SalaireRepository : GenericRepository<Salaire>, ISalaireRepository
    {
        public SalaireRepository(KsbApiContext context) : base(context)
        { }
    }
}
