using Ksb.Domain.parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksb.Domain
{
    public class DepensesProjet : DefaultParent
    {
        public int TypeDepenseProjetId { get; set; }
        public TypeDepenseProjet TypeDepenseProjet { get; set; }
        public int ProjetId { get; set; }
        public Projet Projet { get; set; }
        public double PrixUnitaire { get; set; }
        public int Quantite { get; set; }
        public double Total { get; set; }
        public DateTime Date { get; set; }
    }
}
