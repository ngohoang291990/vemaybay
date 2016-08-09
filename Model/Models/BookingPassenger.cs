using System;

namespace Model.Models
{
    public class BookingPassenger
    {
        public string Address { get; set; }

        public int? Baggage { get; set; }

        public int? ReturnBaggage { get; set; }

        public DateTime? BirthDay { get; set; }

        public int BookingId { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public short Gender { get; set; }

        public int Id { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string MobileNumber { get; set; }

        public string Nationality { get; set; }

        public short PassengerType { get; set; }

        public DateTime? PassportExpired { get; set; }

        public string PassportNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Province { get; set; }

        public string Title { get; set; }
    }
}