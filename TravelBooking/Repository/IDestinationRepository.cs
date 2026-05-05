using TravelBooking.Models.Domains;
using TravelBooking.Models.DTO;

namespace TravelBooking.Repository
{
    public interface IDestinationRepository
    {
        public Task<List<DestinationResponseDTO>> GetAllDestinations();
        public Task<DestinationResponseDTO> AddDestination(DestinationRequestDTO destinationRequestDTO);

    }
}
