using Ksb.Domain.parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksb.Domain
{
    public class Financement : DefaultParent
    {
        public string projet { get; set; }
        public int Montant { get; set; }
        public int financement { get; set; }
        public DateTime date { get; set; }
    }
}
