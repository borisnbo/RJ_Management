using Ksb.Domain.parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksb.Domain
{
    public class Assurance : DefaultParent
    {
        public DateTime Date { get; set; }
        public int Montant { get; set; }
        public int EmployeId { get; set; }
        public Employe Employe { get; set; }

    }
}
