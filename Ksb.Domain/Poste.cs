using Ksb.Domain.parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksb.Domain
{
    public class Poste : DefaultParent
    {
        public string Nom { get; set; }
        public string Description { get; set; }
    }
}
