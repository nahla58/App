using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Domain
{
    public class Activite
    { public string ActiviteId { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public double Prix { get; set; }
        public string TypeService{ get; set; }
        public Zone zone { get; set; }
        public virtual ICollection<Pack> Packs { get; set; }
    }
}
