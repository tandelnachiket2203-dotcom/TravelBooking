namespace TravelBooking.Models.Domains
{
    public class Booking
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid DestinationId { get; set; }

        public DateTime BookingData { get; set; }

        public DateTime TravelDate {  get; set; }

        public int NumberOfPeople { get; set; }

        public decimal TotalPrice { get; set; }
        public string Status { get; set; }

        public string PaymentStatus { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime LastUpdatedAt { get; set; }

        //Navigation properties

        public User User { get; set; }

        public Destination Destination { get; set; }

    }
}
