using Ksb.Domain.parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksb.Domain
{
    public class RationPersonnel : DefaultParent
	{
		public long Montant { get; set; }
		public DateTime Date { get; set; }
        public int PersonnelsProjetId { get; set; }
        public PersonnelsProjet PersonnelsProjet { get; set; }
	}
}
