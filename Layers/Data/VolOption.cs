using SuiviDesVols.Layers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuiviDesVols.Layers.Data
{
    public class VolOption : BaseEntity
    {
        public VolOption()
        {
            LigneVols = new HashSet<LigneVol>();
        }

        public string Icone { get; set; }
        public double Prix { get; set; }
        public ICollection<LigneVol> LigneVols { get; set; }
    }
}
