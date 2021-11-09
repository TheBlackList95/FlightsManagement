using SuiviDesVols.Layers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuiviDesVols.Models
{
    public class EditAmenitiesModel
    {
        public VolOption VolOption { get; set; }
        public bool IsChecked { get; set; }
        public bool IsIncluded { get; set; }
    }
}
