namespace TravelBooking.Models.DTO
{
    public class DestinationRequestDTO
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public string Description { get; set; }

        public decimal PricePerPerson { get; set; }

        public int DurationInDays { get; set; }

        public int AvailableSlots { get; set; }

        public string ImageUrl { get; set; }

        public bool IsActive
        {
            get; set;
        }
    }
}
