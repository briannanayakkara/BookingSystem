using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBooking.Models
{
    public class VenueItems
    {
        public int TableID { get; set; }
        public int VenueID { get; set; }
        public int TableNr { get; set; }
        public int Pax { get; set; }
        public string TableType { get; set; }
    }

}
