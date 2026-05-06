using TravelBooking.Data;
using TravelBooking.Models.DTO;

namespace TravelBooking.Repository
{
    public class SQLBookingRepository : IBookingRepository
    {
        public SQLBookingRepository(TravellBokkingDBContext travellBokkingDBContext)
        {
            TravellBokkingDBContext = travellBokkingDBContext;
        }

        public TravellBokkingDBContext TravellBokkingDBContext { get; }

        public async Task<BookingResponseDTO> CreateBooking(CreateBookingRequestDTO createBookingRequest)
        {
            
        }
    }
}