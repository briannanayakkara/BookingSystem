namespace BookingAPI.Models
{
    public class Bookings
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int VenueID { get; set; }
        public DateTime Time { get; set; }
        public int Pax { get; set; }
        public string Note { get; set; }
        public int TableID { get; set; }
        public int status { get; set; }
       
    }
}
