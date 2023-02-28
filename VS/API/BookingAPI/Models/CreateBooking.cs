namespace BookingAPI.Models
{
    public class CreateBooking
    {
        public string Username { get; set; }
        public string VenueName { get; set; }
        public DateTime DateTime { get; set; }
        public int Pax { get; set; }
        public string Note { get; set; }
    }

}
