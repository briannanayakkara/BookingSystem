namespace BookingAPI.Models
{
    public class UpdateBooking
    {
        public int? ID { get; set; }

        public string? VenueName { get; set; }

        public string? Username { get; set; }

        public DateTime? Datetime { get; set; }

        public int? Pax { get; set; }

        public string? Note { get; set; }
    }


}
