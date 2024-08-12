using ETreeks.API.Hubs;
using ETreeks.Core.Data;
using ETreeks.Core.DTO;
using ETreeks.Core.IService;
using ETreeks.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IHubContext<NotificationHub> _hubContext;

        public StudentController(IStudentService studentService, IHubContext<NotificationHub> hubContext)
        {
            _studentService = studentService;
            _hubContext = hubContext;
        }
        [HttpPost]
        public async Task CreateBookingRequest([FromBody] Reservation reservation)
        {
            await _studentService.CreateBookingRequest(reservation);
            //Console.WriteLine($"Attempting to send notification to user {reservation.Gusers_Id}.");

            // await _hubContext.Clients.User(reservation.Gusers_Id.ToString()).SendAsync("ReceiveNotification", "Your booking request has been created.");
            //await _hubContext.Clients.Users(reservation.Gusers_Id.ToString()).SendAsync("ReceiveNotification", "hi");
            // Console.WriteLine($"Notification sent to user {reservation.Gusers_Id}.");
            //  await _hubContext.Clients.All.SendAsync("ReceiveNotification", "Your booking request has been created.");

            // Notify the user
            await _hubContext.Clients.Group(reservation.Gusers_Id.ToString()).SendAsync("ReceiveNotification", "Your booking request has been created and reservation status is pending ");
          
            
            // Console.WriteLine($"Notification sent to user {reservation.Gusers_Id}");
        }


        [HttpGet("notifications/{userId}")]
        public async Task<List<Notification>> GetNotifications(int userId)
        {
            return await _studentService.GetNotificationsForUser(userId);
        }
        [HttpDelete("notifications/{id}")]
        public async Task DeleteNotification(int id)
        {
            await _studentService.DeleteNotification(id);
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
