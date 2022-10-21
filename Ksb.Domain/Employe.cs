using Ksb.Domain.parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksb.Domain
{
    public class Employe :DefaultParent
    {
        public string Nom { get; set; }
        public string Sexe { get; set; }
        public DateTime DateOfBith { get; set; }
        public string Poste { get; set; }

    }
}
