using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SuiviDesVols.Layers.Data;

namespace SuiviDesVols.Models
{
    public class HandleReservationViewModel
    {
        public Guid FlightId { get; set; }
        public string FlightType { get; set; }
        public int Teenagers { get; set; }
        public int Kids { get; set; }
        public int BaggageQuantity { get; set; }
        public List<Guid> Amenity { get; set; }
        public List<VolOption> Amenities { get; set; }
        public List<EditAmenitiesModel> EditAmenities { get; set; }
    }
}