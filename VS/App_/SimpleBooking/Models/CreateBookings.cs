using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBooking.Models
{
    public class CreateBookings
    {
        public string VenueName { get; set; }
        public string Username { get; set; }
        public string DateTime { get; set; }
        public int Pax { get; set; }
        public string Note { get; set; }
    }
}
