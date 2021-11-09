using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuiviDesVols.Models
{
    public class SearchFlightModel
    {
        public Guid? StartAirport { get; set; }
        public Guid? EndAirport { get; set; }
        public string TravelDate { get; set; }
    }
}
