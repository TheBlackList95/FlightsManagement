using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuiviDesVols.Layers.Data
{
    public class LigneVol : BaseEntity
    {
        public LigneVol()
        {
            Vols = new HashSet<Vol>();
            VolOptions = new HashSet<VolOption>();
        }

        public double PrixUnitaire { get; set; }
        public DateTime DateDecollage { get; set; }
        public DateTime DateAtterrissage { get; set; }
        public virtual Aeroport AeroportDepart { get; set; }
        public virtual Aeroport AeroportArrivee { get; set; }
        public virtual Avion Avion { get; set; }
        public virtual Agence Agence { get; set; }
        public virtual ICollection<Vol> Vols { get; set; }
        public virtual ICollection<VolOption> VolOptions { get; set; }
    }
}
