using TravelBooking.Models.Domains;

namespace TravelBooking.Repository
{
    public interface IDestinationRepository
    {
        public Task<List<Destination>> GetAllDestinations();

    }
}
