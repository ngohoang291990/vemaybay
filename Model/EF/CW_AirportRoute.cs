using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EF
{
    [Table("CW_AirportRoute")]
    public class CW_AirportRoute
    {
        [Key,Column(Order = 1)]
        public int AirportID1 { get; set; }

        [Key,Column(Order = 2)]
        public int AirportID2 { get; set; }
    }
}