using Ksb.Domain.parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksb.Domain
{
    public class Formation : DefaultParent
    {
        public int EmployeId { get; set; }
        public Employe Employe { get; set; }
        public double Montant { get; set; }
        public string TypeFormation { get; set; }
        public DateTime Date { get; set; }
    }
}
