using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBooking.Models
{
    public class UserData
    {
        public int AdminLvl { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Region { get; set; }
        public DateTime Bday { get; set; }
        public string Password { get; set; }
    }

}
