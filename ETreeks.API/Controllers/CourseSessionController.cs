using ETreeks.Core.Data;
using ETreeks.Core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETreeks.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CourseSessionController : ControllerBase
	{

		private readonly ICourseSessionService _courseSessionService;

		public CourseSessionController(ICourseSessionService courseSessionService)
		{
			_courseSessionService = courseSessionService;
		}

		[HttpPost]
		public async Task<IActionResult> CreateCourseSession([FromBody] CourseSession courseSession)
		{
			var result = await _courseSessionService.CreateCourseSession(courseSession);
			return Ok(result);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateCourseSession([FromBody] CourseSession courseSession)
		{
			var result = await _courseSessionService.UpdateCourseSession(courseSession);
			return Ok(result);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCourseSession(int id)
		{
			var result = await _courseSessionService.DeleteCourseSession(id);
			return Ok(result);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllCourseSessions()
		{
			var result = await _courseSessionService.GetAllCourseSessions();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCourseSessionById(int id)
		{
			var result = await _courseSessionService.GetCourseSessionById(id);
			return Ok(result);
		}

	}
}
