using ETreeks.Core.Data;
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
        public async Task<int> CreateBookingRequest([FromBody] Reservation reservation)
        {
            return await _studentService.CreateBookingRequest(reservation);
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
    }
}
