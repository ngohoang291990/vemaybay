using System;
using System.Collections.Generic;

namespace Model.Models
{
    public class Flight
    {
        public string Airline { get; set; }

        public string AirlineCode { get; set; }

        public DateTime DepartTime { get; set; }

        public string Description { get; set; }

        public IList<FlightDetail> Details { get; set; }

        public TimeSpan? FlightDuration { get; set; }

        public string FromAirport { get; set; }

        public string FromPlace { get; set; }

        public string Id { get; set; }

        public DateTime LandingTime { get; set; }

        public string FlightNumber { get; set; }

        public decimal Price { get; set; }

        public short Stops { get; set; }

        public string TicketType { get; set; }

        public string ToAirport { get; set; }

        public string ToPlace { get; set; }

        public int FromPlaceId { get; set; }

        public int ToPlaceId { get; set; }

        public decimal TotalPrice { get; set; }

        public string Filter { get; set; }

        public string Source { get; set; }

        public string SourceGroup { get; set; }

        public string FareBasis { get; set; }

        public IList<TicketOption> TicketOptions { get; set; }

        public IList<PriceSummary> PriceSummaries { get; set; }

        public IList<PriceDetail> TicketPriceDetails { get; set; }
    }
}