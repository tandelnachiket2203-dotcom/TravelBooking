namespace TravelBooking.Models.Domains
{
    public class Destination
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }
        public string City { get; set; }

        public string Description { get; set; }

        public decimal PricePerPerson { get; set; }

        public int AvailableSlots { get; set; }

        public string ImageUrl { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime LastUpdatedAt { get; set; }

        //Navigation property

        public ICollection<Booking> Bookings { get; set; }


    }
}
