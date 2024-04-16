using System;
using System.Threading.Tasks;
using AutoMapper;
using CineTixx.Core.DTOs;
using CineTixx.Core.Ports.Driving;
using Microsoft.AspNetCore.Mvc;

namespace CineTixx.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDto>>> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            return Ok(bookings);
        }

        [HttpGet("{BookingId}")]
        public async Task<ActionResult<BookingDto>> GetBooking(int BookingId)
        {
            var bookings = await _bookingService.GetBookingAsync(BookingId);
            if (bookings == null)
            {
                return NotFound();
            }
            return bookings;
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking(BookingDto bookingdto)
        {
            await _bookingService.AddBookingAsync(bookingdto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] BookingDto bookingdto)
        {
            if (id != bookingdto.BookingId)
            {
                return BadRequest("BookingId in the route parameter does not match the BookingId in the request body.");
            }

            await _bookingService.UpdateBookingAsync(bookingdto);
            return NoContent();
        }


        [HttpDelete("{BookingId}")]
        public async Task<IActionResult> DeleteBooking(int BookingId)
        {
            await _bookingService.DeleteBookingAsync(BookingId);
            return NoContent();
        }
    }
}
