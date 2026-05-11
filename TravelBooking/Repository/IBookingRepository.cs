using TravelBooking.Models.DTO;

namespace TravelBooking.Repository
{
    public interface IBookingRepository
    {
        // Define methods for booking operations
        public Task<BookingResponseDTO> CreateBooking(Guid userId,CreateBookingRequestDTO createBookingRequest);
    }
}