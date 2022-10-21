using Ksb.Domain.parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksb.Domain
{
    public class Projet : DefaultParent
	{
		public string Nom { get; set; }
		public string Description { get; set; }
		public double Budjet { get; set; }
		public string Etat { get; set; }
		public string TypeFinancement { get; set; }

		public Boolean Doit { get; set; }
	}
}
