using TravelBooking.Data;
using TravelBooking.Models.DTO;
using Microsoft.EntityFrameworkCore;
using TravelBooking.Models.Domains;

namespace TravelBooking.Repository
{
    public class SQLBookingRepository : IBookingRepository
    {
        public SQLBookingRepository(TravellBokkingDBContext travellBokkingDBContext)
        {
            TravellBokkingDBContext = travellBokkingDBContext;
        }

        public TravellBokkingDBContext TravellBokkingDBContext { get; }

       

        public async Task<BookingResponseDTO> CreateBooking(Guid userId, CreateBookingRequestDTO createBookingRequest)
        {
            //get destination details from database using destination id from createBookingRequest
            var destination = await TravellBokkingDBContext.Destinations.FirstOrDefaultAsync(d => d.Id == createBookingRequest.DestinationID);

            if (destination == null)
            {
                throw new Exception("Destination not found");
            }
            if(destination.AvailableSlots<createBookingRequest.NumberOfTravelers)
            {
               throw new Exception("Not enough available slots for booking");

            }
            //create a new booking entity and save it to the database
            var totalPrice = destination.PricePerPerson * createBookingRequest.NumberOfTravelers;
            var booking = new Booking
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                DestinationId = createBookingRequest.DestinationID,
                NumberOfPeople = createBookingRequest.NumberOfTravelers,
                TotalPrice = totalPrice,
                BookingDate = DateTime.UtcNow,
                TravelDate = createBookingRequest.TravelDate,
                Status = "Confirmed",
                PaymentStatus = "Pending"
            };
            //update available slots for the destination
            destination.AvailableSlots -= createBookingRequest.NumberOfTravelers;
            await TravellBokkingDBContext.Bookings.AddAsync(booking);
            await TravellBokkingDBContext.SaveChangesAsync();

            

            return new BookingResponseDTO
            {
                 Id = booking.Id,
                 DestinationName = destination.Name,

                 TravelDate = booking.TravelDate,
                 NumberOfTravelers = booking.NumberOfPeople,

                 TotalPrice = booking.TotalPrice,

                 Status= booking.Status,
                 PaymentStatus = booking.PaymentStatus
            };
        }
    }
}