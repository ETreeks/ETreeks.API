using ETreeks.Core.Data;
using ETreeks.Core.DTO;
using ETreeks.Core.IService;
using ETreeks.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [HttpGet]
        [Route("Search/{startDate}/{endDate}")]
        public List<TrainerSearch> Search(DateTime startDate, DateTime endDate)
        {
            return _trainerService.Search(startDate, endDate);
        }
        [HttpPost("accept/{id}")]
        public async Task<IActionResult> AcceptReservation(int id)
        {
            await _trainerService.AcceptReservationAsync(id);
            return Ok("Accepted");
        }

        [HttpPost("reject/{id}")]
        public async Task<IActionResult> RejectReservation(int id)
        {
            await _trainerService.RejectReservationAsync(id);
            return Ok("Rejected");

        }

        [HttpGet]
        [Route("GetAllPendingReservation")]
        public async Task<List<Reservation>> GetAllPendingReservation()
        {
            return await _trainerService.GetAllPendingReservation();
        }
    }
}
