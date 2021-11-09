using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuiviDesVols.Layers.Data
{
    public class Vol : BaseEntity
    {
        public Guid IdLigne { get; set; }
        public DateTime DateVoyage { get; set; }
        public LigneVol LigneVol { get; set; }
        public string ClasseVol { get; set; }
        public string IdUtilisateur { get; set; }
        public List<VolOption> OptionsChoisies { get; set; }
        public int NombreAdultes { get; set; }
        public int NombreEnfants { get; set; }
        public int QuantiteBagageEnKg { get; set; }
    }
}
