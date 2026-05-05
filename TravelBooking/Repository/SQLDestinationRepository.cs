using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelBooking.Data;
using TravelBooking.Models.Domains;
using TravelBooking.Models.DTO;

namespace TravelBooking.Repository
{
    public class SQLDestinationRepository : IDestinationRepository
    {
        public SQLDestinationRepository(TravellBokkingDBContext travellBokkingDBContext,IMapper autoMapper)
        {
            TravellBokkingDBContext = travellBokkingDBContext;
            AutoMapper = autoMapper;
        }

        public TravellBokkingDBContext TravellBokkingDBContext { get; }
        public IMapper AutoMapper { get; }

        public async Task<DestinationResponseDTO> AddDestination(DestinationRequestDTO destinationRequestDTO)

        {
            var destinationDomain = AutoMapper.Map<Destination>(destinationRequestDTO);
            destinationDomain.CreatedAt = DateTime.UtcNow;
            await TravellBokkingDBContext.Destinations.AddAsync(destinationDomain);
            await TravellBokkingDBContext.SaveChangesAsync();
            return AutoMapper.Map<DestinationResponseDTO>(destinationDomain);

        }
        

        public async Task<List<DestinationResponseDTO>> GetAllDestinations()
        {
           var destinationDomainList=  await TravellBokkingDBContext.Destinations.ToListAsync();
           var destinationResponseDTOList = AutoMapper.Map<List<DestinationResponseDTO>>(destinationDomainList);
            return destinationResponseDTOList;
        }
    }
}
