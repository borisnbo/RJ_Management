using Ksb.Domain.parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksb.Domain
{
    public class Impot : DefaultParent
	{
		public string Periode { get; set; }
		public string TypeImpot { get; set; }
		public double Montant { get; set; }
	}
}
