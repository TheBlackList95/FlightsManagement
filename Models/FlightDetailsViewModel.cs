using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuiviDesVols.Models
{
    public class FlightDetailsViewModel
    {
        public string FlightType { get; set; }
        public double BasicPrice { get; set; }
        public double TotalPrice { get; set; }
        public int NbChildren { get; set; }
        public int NbAdults { get; set; }
        public int QuantityBaggageInKg { get; set; }
        public string FligthName { get; set; }
        public string StartAirportName { get; set; }
        public string EndAirportName { get; set; }
        public TimeSpan CompleteFlightTime { get; set; }
        public DateTime FlightTakeOffDate { get; set; }
        public DateTime FlightLandingDate { get; set; }
        public double DistanceBetweenAirports { get; set; }
        public List<AmenityModel> Amenities { get; set; }
        public string AgencyName { get; set; }
        public string AirplaneName { get; set; }
        public double AirplaneConsumption { get; set; }
        public int AirplaneNbPassengers { get; set; }
        public double AirplaneTakeOffPower { get; set; }
        public double AirplaneKerosenQuantity { get; set; }
        public string AgencyDescription { get; set; }
        public string AgencyImage { get; set; }
    }
}