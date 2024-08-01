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
        [Route("Search/{startDate}/{endDate}/{trainerId}")]
        public List<TrainerSearch> Search(DateTime startDate, DateTime endDate, int trainerId)
        {
            return _trainerService.Search(startDate, endDate, trainerId);
        }
        [HttpGet]
        [Route("GetAllReservationT/{id}")]
        public async Task<List<ReservationDate>> GetAllReservationT(int id)
        {
            return await _trainerService.GetAllReservationT(id);
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
		[HttpGet("{id}")]
		public async Task<IActionResult> ViewProfile(int id)
		{
			var profile = await _trainerService.ViewProfile(id);
			if (profile == null)
			{
				return NotFound();
			}
			return Ok(profile);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateProfile([FromBody] ProfileTrainerDTO profileTrainerDto)
		{
			var result = await _trainerService.UpdateProfile(profileTrainerDto);
			if (result)
			{
				return NoContent();
			}
			return BadRequest();
		}
	}
}
