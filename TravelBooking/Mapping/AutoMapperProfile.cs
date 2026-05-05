using AutoMapper;
using TravelBooking.Models.Domains;
using TravelBooking.Models.DTO;

namespace TravelBooking.Mapping
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            // CreateMap<Destination, DestinationResponseDTO>().ForMember(dest => dest.DestId, opt => opt.MapFrom(src => src.Id)).ReverseMap ; //incase there are property name will slight diffrence and want to Map that value too.

            CreateMap<Destination, DestinationResponseDTO>().ReverseMap(); //for same property name we can use this simple way to map the value.
            CreateMap<Destination,DestinationRequestDTO>().ReverseMap();
        }
    }
}
