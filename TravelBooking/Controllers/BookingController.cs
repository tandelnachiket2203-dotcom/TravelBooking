using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelBooking.Models.DTO;


namespace TravelBooking.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class BookingController : ControllerBase
    {
        [HttpPost]
        [Route("CreateBooking"  )]
        public async Task<IActionResult> CreateBooking([FromBody]CreateBookingRequestDTO createBookingRequest)
        {
            return Ok();
        }
        }
    }
    
}