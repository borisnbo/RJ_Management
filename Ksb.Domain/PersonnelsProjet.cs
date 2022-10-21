using Ksb.Domain.parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksb.Domain
{
    public class PersonnelsProjet : DefaultParent
    {
        public int EmployeId { get; set; }
        public int ProjetId { get; set; }
        public Employe Employe { get; set; }
        public Projet Projet { get; set; }
    }
}
