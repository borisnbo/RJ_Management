using Ksb.Domain.parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksb.Domain
{
    public class TransportPersonnel : DefaultParent
    {
        public int PersonnelsProjetId { get; set; }
        public PersonnelsProjet PersonnelsProjet { get; set; }
        public long Montant { get; set; }
    }
}
