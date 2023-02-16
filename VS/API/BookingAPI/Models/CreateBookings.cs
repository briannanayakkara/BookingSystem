namespace BookingAPI.Models
{
    public class CreateBookings
    {
        public string userName { get; set; }
        public string venueName { get; set; }
        public DateTime Time { get; set; }
        public int Pax { get; set; }
        public string Note { get; set; }
       
    }
}
