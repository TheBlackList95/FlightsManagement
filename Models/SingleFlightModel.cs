using SuiviDesVols.Layers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuiviDesVols.Models
{
    public class SingleFlightModel
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public String AgenceImage { get; set; }
        public double UnitPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Aeroport StartAirport { get; set; }
        public Aeroport EndAirport { get; set; }
        public List<string> VolOptions { get; set; }
        public Guid ReservedFlightId { get; set; }
    }
}
