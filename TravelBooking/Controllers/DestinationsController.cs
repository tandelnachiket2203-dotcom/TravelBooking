using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return Ok("This will return all destinations");
        }
    }
}
