namespace BookingAPI.Models
{
    public class Bookings
    {
        public int? Id { get; set; }

        public int? UserID { get; set; }

        public int? VenueID { get; set; }
        public string? Time { get; set; }
        public int? Pax { get; set; }
        public string? Note { get; set; }
        public string? TableID { get; set; }
        public int? Status { get; set; }

    }
}
