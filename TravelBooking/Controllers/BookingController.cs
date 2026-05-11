using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelBooking.Models.DTO;
using TravelBooking.Repository;


namespace TravelBooking.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class BookingController : ControllerBase
    {
        public BookingController(IBookingRepository bookingRepository)
        {
            BookingRepository = bookingRepository;
        }

        public IBookingRepository BookingRepository { get; }

        [HttpPost]
        [Route("CreateBooking/{userId}")]

        public async Task<IActionResult> CreateBooking([FromBody]CreateBookingRequestDTO createBookingRequest,[FromHeader]Guid userId)
        {
            var booking = await BookingRepository.CreateBooking(userId, createBookingRequest);
            return Ok(booking);
        }
        }
}
    
