using Microsoft.EntityFrameworkCore;
using TravelBooking.Data;
using TravelBooking.Models.Domains;

namespace TravelBooking.Repository
{
    public class SQLDestinationRepository : IDestinationRepository
    {
        public SQLDestinationRepository(TravellBokkingDBContext travellBokkingDBContext)
        {
            TravellBokkingDBContext = travellBokkingDBContext;
        }

        public TravellBokkingDBContext TravellBokkingDBContext { get; }

        public async Task<List<Destination>> GetAllDestinations()
        {
            return await TravellBokkingDBContext.Destinations.ToListAsync();
        }
    }
}
