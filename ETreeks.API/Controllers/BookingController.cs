using ETreeks.Core.Data;
using ETreeks.Core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

     

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<Reservation> GetBookingRequestById(int id)
        {
            return await _bookingService.GetBookingRequestById(id);
        }

        [HttpGet]
        [Route("GetAllBookingRequest")]
        public async Task<List<Reservation>> GetAllBookingRequest() 
        {
            return await _bookingService.GetAllBookingRequest();
        }


        [HttpGet]
        [Route("GetAllPendingBooking")]
        public async Task<List<Reservation>> GetAllPendingBooking()
        {
            return await _bookingService.GetAllPendingBooking();
        }


    }
}
