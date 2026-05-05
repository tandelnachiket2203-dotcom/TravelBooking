using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelBooking.Models.DTO;
using TravelBooking.Repository;

namespace TravelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        public DestinationsController(IDestinationRepository destinationRepository)
        {
            DestinationRepository = destinationRepository;
        }

        public IDestinationRepository DestinationRepository { get; }

        [HttpGet]
        public async Task<IActionResult> GetAllDestinations()
        {
            var destination=await DestinationRepository.GetAllDestinations();
            return Ok(destination);
        }

        [HttpPost]
        [Route("AddDestination")]
      
        public async Task<IActionResult> AddDestination([FromBody] DestinationRequestDTO destinationRequest)
        {

            var addedDestination = await DestinationRepository.AddDestination(destinationRequest);

            return Ok(addedDestination);
        }
    }
}
