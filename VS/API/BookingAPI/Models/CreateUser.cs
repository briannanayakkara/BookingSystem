namespace BookingAPI.Models
{
    public class CreateUser
    {
        public string AdminLvl { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string  phone { get; set; }
        public string region { get; set; }
        public string bday { get; set; }
        public string pass { get; set; }

    }
}
