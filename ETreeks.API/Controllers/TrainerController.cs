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
    public class TrainerController : ControllerBase
    {
        private ITrainerService _trainerService;
        private readonly IHubContext<NotificationHub> _hubContext;

        public TrainerController(ITrainerService trainerService, IHubContext<NotificationHub> hubContext)
        {
            _trainerService = trainerService;
            _hubContext = hubContext;
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
            //await _trainerService.AcceptReservationAsync(id);
            //return Ok("Accepted");

            // Retrieve the reservation using the provided ID
            var reservation = await _trainerService.GetReservationByIdAsync(id);

            if (reservation == null)
            {
                return NotFound("Reservation not found");
            }

            // Accept the reservation
            await _trainerService.AcceptReservationAsync(id);

            // Notify the user
            var userId = reservation.Gusers_Id.ToString();
            var message = "Your reservation has been accepted.";
            await _hubContext.Clients.Group(userId).SendAsync("ReceiveNotification", message);
            Console.WriteLine($"Notification sent to user {userId}: {message}");

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
		//[HttpGet("{id}")]
		//public async Task<IActionResult> ViewProfile(int id)
		//{
		//	var profile = await _trainerService.ViewProfile(id);
		//	if (profile == null)
		//	{
		//		return NotFound();
		//	}
		//	return Ok(profile);
		//}

		//[HttpPut]
		//public async Task<IActionResult> UpdateProfile([FromBody] ProfileTrainerDTO profileTrainerDto)
		//{
		//	var result = await _trainerService.UpdateProfile(profileTrainerDto);
		//	if (result)
		//	{
		//		return NoContent();
		//	}
		//	return BadRequest();
		//}


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
		[Route("uploadImage")]
		[HttpPost]
		public Guser UploadIMage()
		{

			var file = Request.Form.Files[0];
			var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
			var fullPath = Path.Combine("C:\\Users\\hp\\OneDrive\\Desktop\\FINALONE\\ETreeks_Angular10\\ETreeks\\src\\assets\\Images", fileName);
			using (var stream = new FileStream(fullPath, FileMode.Create))
			{
				file.CopyTo(stream);
			}
			Guser item = new Guser();
			item.Imagename = fileName;
			return item;
		}



	}
}
