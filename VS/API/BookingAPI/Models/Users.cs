namespace BookingAPI.Models
{
    public class Users
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Region { get; set; }
        public DateTime Birthday { get; set; }
        public int AdminLevel { get; set; }



    }
}
