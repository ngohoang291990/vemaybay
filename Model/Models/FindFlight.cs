using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Models
{
    public class FindFlight
    {
        public bool RoundTrip { get; set; }

        public string FromPlace { get; set; }

        public string ToPlace { get; set; }

        public DateTime DepartDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public string CurrencyType { get; set; }

        public string FlightType { get; set; }

        public int Adult { get; set; }

        public int Child { get; set; }

        public int Infant { get; set; }

        public string Sources { get; set; }
    }
}
