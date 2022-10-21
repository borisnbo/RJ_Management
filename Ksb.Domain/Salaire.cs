using Ksb.Domain.parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksb.Domain
{
    public class Salaire : DefaultParent
    {

        public string Periode { get; set; }
        public int EmployeId { get; set; }
        public Employe Employe { get; set; }
        public double Montant { get; set; }
    }
}
