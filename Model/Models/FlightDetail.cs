using System;

namespace Model.Models
{
    public class FlightDetail
    {
        public string Airline { get; set; }

        public string AirlineCode { get; set; }

        public string FlightDuration { get; set; }

        public string FlightNumber { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public DateTime? DepartTime { get; set; }

        public DateTime? LandingTime { get; set; }
    }
}