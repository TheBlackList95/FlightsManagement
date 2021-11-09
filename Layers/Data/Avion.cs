using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuiviDesVols.Layers.Data
{
    public class Avion : BaseEntity
    {
        public Avion()
        {
            LigneVols = new HashSet<LigneVol>();
        }

        public double ConsommationLitrePar100Km { get; set; }
        public int NbPassagerMax { get; set; }
        public double EffortDecollage { get; set; }

        public ICollection<LigneVol> LigneVols { get; set; }
    }
}
