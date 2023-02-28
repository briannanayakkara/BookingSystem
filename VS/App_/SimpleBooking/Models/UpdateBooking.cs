using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBooking.Models
{
    public class UpdateBooking
    {
        public int ID { get; set; }
<<<<<<< HEAD
        public string Datetime { get; set; }
=======
        public DateTime Datetime { get; set; }
>>>>>>> API
        public int Pax { get; set; }
        public string Note { get; set; }
        public string VenueName { get; set; }
        public string Username { get; set; }
    }

}
