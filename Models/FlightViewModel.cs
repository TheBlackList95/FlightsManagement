using Microsoft.AspNetCore.Mvc.Rendering;
using SuiviDesVols.Layers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuiviDesVols.Models
{
    public class FlightViewModel
    {
        public List<SingleFlightModel> Flights { get; set; }
        public SelectList Airports { get; set; }
        public SearchFlightModel SearchFlight { get; set; }
    }
}
