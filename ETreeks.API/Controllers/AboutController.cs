using ETreeks.Core.Data;
using ETreeks.Core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETreeks.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AboutController : ControllerBase
	{

		private readonly IAboutService _aboutService;

		public AboutController(IAboutService aboutService)
		{
			_aboutService = aboutService;
		}

		[HttpPost]
		public async Task<IActionResult> CreateAbout([FromBody] About about)
		{
			var result = await _aboutService.CreateAbout(about);
			return Ok(result);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAbout([FromBody] About about)
		{
			var result = await _aboutService.UpdateAbout(about);
			return Ok(result);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAbout(int id)
		{
			var result = await _aboutService.DeleteAbout(id);
			return Ok(result);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAbout()
		{
			var result = await _aboutService.GetAllAbout();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAboutById(int id)
		{
			var result = await _aboutService.GetAboutById(id);
			return Ok(result);
		}
	}
}
