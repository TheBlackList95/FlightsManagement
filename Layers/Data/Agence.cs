using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuiviDesVols.Layers.Data
{
    public class Agence : BaseEntity
    {
        public Agence()
        {
            LigneVols = new HashSet<LigneVol>();
        }

        public string Description { get; set; }
        public string Image { get; set; }
        public ICollection<LigneVol> LigneVols { get; set; }
    }
}
