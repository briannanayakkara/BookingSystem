﻿namespace BookingAPI.Models
{
    public class BookingsByDate
    {
        public int ID { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Pax { get; set; }
        public int TableSize { get; set; }
        public int TableNr { get; set; }
        public string Note { get; set; }
        public DateTime Time { get; set; }
        public string Venue { get; set; }
        public string VenueOwner { get; set; }
        public string Status { get; set; }
    }

}
