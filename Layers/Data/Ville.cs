using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuiviDesVols.Layers.Data
{
    public partial class Ville : BaseEntity
    {
        public Ville()
        {
            Aeroports = new HashSet<Aeroport>();
        }

        public ICollection<Aeroport> Aeroports { get; set; }
    }
}
