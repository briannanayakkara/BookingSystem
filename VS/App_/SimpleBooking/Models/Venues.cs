using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBooking.Models
{
    public  class Venues
    {
        public int VenueID { get; set; }
        public string Name { get; set; }
        public int Limit { get; set; }
        public int EmployeeQty { get; set; }
        public string Type { get; set; }
        public string CVR { get; set; }
        public string Region { get; set; }
    }
}
