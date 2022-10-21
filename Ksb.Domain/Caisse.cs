using Ksb.Domain.parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksb.Domain
{
    public class Caisse : DefaultParent
    {
        public long Projets { get; set; }
        public long Depenses { get; set; }
        public long Difference { get; set; }
        public long Attente { get; set; }
    }
}
