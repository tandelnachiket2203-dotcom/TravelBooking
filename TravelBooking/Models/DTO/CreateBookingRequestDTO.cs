namespace TravelBooking.Models.DTO
{
    public class CreateBookingRequestDTO
    {
       public Guid DestinationID { get; set; }
        public DateTime TravelDate { get; set; }
        public int NumberOfTravelers { get; set; }

    }
}
