using Ksb.Domain.parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksb.Domain
{
    public class AutresProjet : DefaultParent
    {
        public string Nom { get; set; }
        public int AutresTypesProjetId { get; set; }
        public AutresTypesProjet TypeProjet { get; set; }
    }
}
