namespace BookingAPI.Models
{
    public class SelectBookings
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Pax { get; set; }
        public string TableSize { get; set; }
        public string TableNr { get; set; }
        public string Note { get; set; }
        public DateTime Time { get; set; }
        public string Venue { get; set; }
        public string VenueOwner { get; set; }
        public string Status { get; set; }



    }
}
