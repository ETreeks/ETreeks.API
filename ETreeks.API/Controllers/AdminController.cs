using ETreeks.API.Helper;
using ETreeks.Core.Data;
using ETreeks.Core.DTO;
using ETreeks.Core.IService;
using ETreeks.Infra.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.DirectoryServices;
using System.Linq.Expressions;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        // TesTTTTTTTTTTT

        private readonly IAdminService _adminService;
        private readonly IEmailService emailService;

        public AdminController(IAdminService adminService, IEmailService service)
        {
            _adminService = adminService;
            this.emailService = service;
        }
        [HttpGet]
        [Route("GetAllReservation")]
        public async Task<List<ReservationDate>> GetAllReservation()
        {
            return await _adminService.GetAllReservation();
        }

        [HttpDelete("{id}")]
        public async Task<int> DeleteUser(int id)
        {
            return await _adminService.DeleteUser(id);
        }

        [HttpGet]
        [Route("DisplayAllStudents")]
        //public async Task<List<Guser>> DisplayAllStudents()
        //{
        //    return await _adminService.DisplayAllStudents();
        //}
        public async Task<List<StudentInfo>> DisplayAllStudents()
        {
            return await _adminService.DisplayAllStudents();
        }
        [HttpGet]
        [Route("DisplayAllTrainers")]
        public async Task<List<Guser>> DisplayAllTrainers()
        {
            return await _adminService.DisplayAllTrainers();
        }
        [HttpGet]
        [Route("DisplayAllUsers")]
        public async Task<List<Guser>> DisplayAllUsers()
        {
            return await _adminService.DisplayAllUsers();
        }
        [HttpGet]
        [Route("GetAllPendingTrainer")]
        public async Task<List<PendingTrainerDTO>> GetAllPendingTrainer()
        {
            return await _adminService.GetAllPendingTrainer();
        }


        [HttpGet]
        [Route("GetCountStudents")]
        public async Task<int> GetCountStudents()
        {
            return await _adminService.GetCountStudents();
        }
        [HttpGet]
        [Route("GetCountTrainers")]
        public async Task<int> GetCountTrainers()
        {
            return await _adminService.GetCountTrainers();
        }
        [HttpGet]
        [Route("GetCountUsers")]
        public async Task<int> GetCountUsers()
        {
            return await _adminService.GetCountUsers();
        }


        [HttpGet]
        [Route("GetCountAdmin")]
        public async Task<int> GetCountAdmin()
        {
            return await _adminService.GetCountAdmin();
        }
        [HttpGet]
        [Route("GetCountPendingTrainers")]
        public async Task<int> GetCountPendingTrainers()
        {
            return await _adminService.GetCountPendingTrainers();
        }
        [HttpGet]
        [Route("GetCountAcceptedTrainers")]
        public async Task<int> GetCountAcceptedTrainers()
        {
            return await _adminService.GetCountAcceptedTrainers();
        }
        [HttpGet]
        [Route("GetCountCategories")]
        public async Task<int> GetCountCategories()
        {
            return await _adminService.GetCountCategories();
        }
        [HttpGet]
        [Route("GetCountCourses")]
        public async Task<int> GetCountCourses()
        {
            return await _adminService.GetCountCourses();
        }


        [HttpGet]
        [Route("TotalStudentInEachCourse")]
        public async Task<List<TotalStudents>> TotalStudentInEachCourse()
        {
            return await _adminService.TotalStudentInEachCourse();
        }

        [HttpGet]
        [Route("TotalCoursesInEachCategory")]
        public async Task<List<TotalCourses>> TotalCoursesInEachCategory()
        {
            return await _adminService.TotalCoursesInEachCategory();
        }

        [HttpGet]
        [Route("TotalStudentsPerTrainer")]
        public async Task<List<TotalStdPerTrainer>> TotalStudentsPerTrainer()
        {
            return await _adminService.TotalStudentsPerTrainer();
        }

        //[HttpGet]
        //[Route("GetStudentsPerTrainer")]

        //public async Task<List<GetStdPerTrainer>> GetStudentsPerTrainer()
        //{
        //    return await _adminService.GetStudentsPerTrainer();
        //}

        [HttpGet]
        [Route("GetStudentsPerTrainer")]

        public async Task<List<TrainerWithStudents>> GetStudentsPerTrainer()
        {
            return await _adminService.GetStudentsPerTrainer();
        }

        [HttpGet]
        [Route("GetCountPendingReservation")]
        public async Task<int> GetCountPendingReservation()
        {
            return await _adminService.GetCountPendingReservation();
        }
        [HttpGet]
        [Route("GetCountAcceptedReservation")]
        public async Task<int> GetCountAcceptedReservation()
        {
            return await _adminService.GetCountAcceptedReservation();
        }


        [HttpPut]
        [Route("AcceptT/{id}")]
        public async Task AcceptTestimonial(int id)
        {
            await _adminService.AccepttesTimonial(id);
        }

        [HttpPut]
        [Route("AcceptC/{id}")]
        public async Task AccepttesCourse(int id)
        {
            await _adminService.AccepttesCourse(id);
        }

        [HttpPost("accept-profile-admin")]
        public async Task<IActionResult> AcceptProfileAdmin(int userId, string newRegistrationStatus)
        {
            await _adminService.AcceptProfileAdmin(userId, newRegistrationStatus);
            return Ok();
        }

        [HttpGet("get-profile-admin/{userId}")]
        public async Task<IActionResult> GetProfileAdmin(int userId)
        {
            var user = await _adminService.GetProfileAdmin(userId);
            if (user == null)
            {
                return NotFound();
            }

            var userDto = new GuserDto
            {
                Username = user.Username,
                Password = user.Password,
                Fname = user.Fname,
                Lname = user.Lname,
                Email = user.Email,
                ImageName = user.Imagename,
                Gender = user.Gender,
                Phone = (decimal)user.Phone
            };

            return Ok(userDto);
        }


        [HttpPut("update-profile-admin")]
        public async Task<IActionResult> UpdateProfileAdmin([FromBody] UpdateProfileAdminDto updateProfileAdminDto)
        {
            await _adminService.UpdateProfileAdmin(updateProfileAdminDto);
            return Ok();
        }
		[HttpGet("SearchTrainerByName")]
		public IActionResult SearchTrainerByName(string trainerName)
		{
			var trainers = _adminService.SearchTrainerByName(trainerName);
			if (trainers == null || trainers.Count == 0)
			{
				return NotFound("No trainers found with the specified name.");
			}
			return Ok(trainers);
		}
		//[HttpPost]
		//[Route("ApproveTrainer/{trainerId}")]
		//public async Task<IActionResult> ApproveTrainer(int trainerId)
		//{
		//	var result = await _adminService.ApproveTrainer(trainerId);
		//	return Ok(result);
		//}

		[HttpDelete]
        [Route("RemoveTrainer/{trainerId}")]
        public async Task<IActionResult> RemoveTrainer(int trainerId)
        {
            var result = await _adminService.RemoveTrainer(trainerId);
            return Ok(result);
        }
		//      [HttpGet]
		//      [Route("GetTrainerEmail/{trainerId}")]

		//public async Task<IActionResult> GetTrainerEmail(int trainerId)
		//{
		//	var email = await _adminService.GetTrainerEmail(trainerId);

		//	if (string.IsNullOrEmpty(email))
		//	{
		//		return NotFound("Trainer email not found.");
		//	}

		//	return Ok(new { Email = email });
		//}
		[HttpPost("ApproveTrainer/{TrainerId}")]
		public async Task<IActionResult> ApproveTrainer(int TrainerId)
		{
			try
			{
				var result = await _adminService.ApproveTrainer(TrainerId);

				if (result < 0) // Assuming result > 0 indicates success
				{
					return Ok(new { Message = "Trainer approved successfully." });
				}
				else
				{
					// Return a 404 Not Found if no rows were updated
					return NotFound(new { Message = "Trainer not found or already approved." });
				}
			}
			catch (Exception ex)
			{
				// Log the exception (use a logging framework in production)
				Console.WriteLine($"Error approving trainer: {ex.Message}");
				return StatusCode(500, new { Message = "An error occurred while approving the trainer." });
			}
		}

		[HttpGet]
		[Route("GetTrainerEmail/{trainerId}")]
		public async Task<IActionResult> GetTrainerEmail(int trainerId)
		{
			var email = await _adminService.GetTrainerEmail(trainerId);

			if (string.IsNullOrEmpty(email))
			{
				return NotFound("Trainer email not found.");
			}

			return Ok(new { Email = email });
		}


		[HttpPost("SendMail")]

        public async Task<IActionResult> SendMail()
        {
            try
            {
                MailRequest mailRequest = new MailRequest();
                mailRequest.TOEmail = "lutfitala35@gmail.com";
                mailRequest.Subject = "Welcome Our New Trainer , You Have Access To Login In Now";
                mailRequest.Body = "Have A Great Day.";
                await emailService.SendEmailAsync(mailRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    } }