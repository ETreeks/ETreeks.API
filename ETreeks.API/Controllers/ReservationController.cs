using ETreeks.Core.Data;
using ETreeks.Core.IService;
using ETreeks.Infra.Service;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public ReservationController (IReservationService reservationService)
        {
            _reservationService = reservationService;
        }


        [HttpGet]
        public async Task<List<Reservation>> GetAllReservations()
        {
            return await _reservationService.GetAllReservations();
        }
      

        [HttpGet("GetById/{id}")]
        public async Task<Reservation> GetReservationById(int id)
        {
            return await _reservationService.GetReservationById(id);
        }
    
        [HttpPost]
        public async Task<int> CreateReservation([FromBody] Reservation reservation)
        {
            return await _reservationService.CreateReservation(reservation);
        }

        [HttpPut]
        public async Task UpdateReservation(Reservation reservation)
        {
            await _reservationService.UpdateReservation(reservation);
        }

        [HttpDelete("{id}")]
        public async Task DeleteReservation(int id)
        {
            await _reservationService.DeleteReservation(id);
        }


    }
}
