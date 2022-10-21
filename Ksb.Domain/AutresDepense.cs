using Ksb.Domain.parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksb.Domain
{
    public class AutresDepense : DefaultParent
    {
        public DateTime Date { get; set; }
        public int TypeDepenseAutreId { get; set; }
        //cette prop doit etre supprimer avant toute migration
        public TypeDepenseAutre TypeDepenseAutre { get; set; }
        public int AutresProjetId { get; set; }
        public AutresProjet AutresProjet { get; set; }
        public double PrixUnitaire { get; set; }
        public int Quantite { get; set; }
        public double Total { get; set; }
    }
}
