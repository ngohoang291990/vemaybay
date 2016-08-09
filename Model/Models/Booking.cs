using System;
using System.Collections.Generic;

namespace Model.Models
{
    public class Booking
    {
        public int Adult { get; set; }

        public ICollection<BookingPassenger> BookingPassengers { get; set; }

        public string Brand { get; set; }

        public int Child { get; set; }

        public string CurrencyType { get; set; }

        public DateTime DepartDate { get; set; }

        public string FlightNumber { get; set; }

        public string ReturnFlightNumber { get; set; }

        public string FromPlaceCode { get; set; }

        public string ToPlaceCode { get; set; }

        public int Infant { get; set; }

        public DateTime ReturnDate { get; set; }

        public bool RoundTrip { get; set; }

        public decimal? TicketPrice { get; set; }

        public decimal? ReturnTicketPrice { get; set; }

        public string TicketType { get; set; }

        public string CallBackUrl { get; set; }

        public string ReturnTicketType { get; set; }

        public string FareBasis { get; set; }

        public string ReturnFareBasis { get; set; }
    }
}