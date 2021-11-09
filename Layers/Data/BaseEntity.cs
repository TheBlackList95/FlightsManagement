using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuiviDesVols.Layers.Data
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public string Nom { get; set; }
    }
}
