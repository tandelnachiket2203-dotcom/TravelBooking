namespace TravelBooking.Models.DTO
{
    public class BookingResponseDTO
    {
        public Guid Id { get; set; }
        public string DestinationName { get; set; }
        public DateTime TravelDate { get; set; }
        public int NumberOfTravelers { get; set; }

        public decimal TotalPrice { get; set; }

        public string Status { get; set; }
         public string PaymentStatus { get; set; }

    }
}
