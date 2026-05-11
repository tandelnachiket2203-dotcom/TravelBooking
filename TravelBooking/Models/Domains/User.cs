namespace TravelBooking.Models.Domains
{
    public class User
    {
        public Guid Id { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }="";
        public bool isEmailVerified { get; set; }= false;

        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }

        //Navigation property

        public ICollection<Booking> Bookings { get; set; }
    }
}
