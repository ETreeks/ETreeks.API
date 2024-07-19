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
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpPost]
        public async Task CreateBookingRequest([FromBody] Reservation reservation)
        {
             await _studentService.CreateBookingRequest(reservation);
        }

        [HttpGet("GetTrainerSessionsByUsername/{Username}")]
        public IActionResult GetTrainerSessionsByUsername(string username)
        {
            var sessions = _studentService.GetTrainerSessionsByUsername(username);
            if (sessions == null || !sessions.Any())
            {
                return NotFound("No sessions found for the given username.");
            }
            return Ok(sessions);
        }

        [HttpGet("GetTrainerSessionsByID/{Id}")]
        public IActionResult GetTrainerSessionsByID(int trainerId)
        {
            var sessions = _studentService.GetTrainerSessionsByID(trainerId);
            if (sessions == null || !sessions.Any())
            {
                return NotFound("No sessions found for the given trainer ID.");
            }
            return Ok(sessions);
        }
		[HttpGet("{id}")]
		public async Task<IActionResult> ViewProfile(int id)
		{
			var profile = await _studentService.ViewProfile(id);
			if (profile == null)
			{
				return NotFound();
			}
			return Ok(profile);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateProfile([FromBody] ProfileStudentDTO profileStudentDto)
		{
			var result = await _studentService.UpdateProfile(profileStudentDto);
			if (result)
			{
				return NoContent();
			}
			return BadRequest();
		}
	}
}
