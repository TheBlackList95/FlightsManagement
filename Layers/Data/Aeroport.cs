using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuiviDesVols.Layers.Data
{
    public partial class Aeroport : BaseEntity
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public virtual Ville Ville { get; set; }
    }
}
