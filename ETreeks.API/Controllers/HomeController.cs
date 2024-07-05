using ETreeks.Core.Data;
using ETreeks.Core.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        [HttpGet]
        public async Task<List<Home>> DisplayAllHomes()
        {
            return await _homeService.DisplayAllHomes();
        }

        [HttpPost]
        public async Task<int> CreateHome([FromBody] Home home)
        {
            return await _homeService.CreateHome(home);
        }

        [HttpPut]
        public async Task<int> UpdateHome([FromBody] Home home)
        {
            return await _homeService.UpdateHome(home);
        }

        [HttpDelete("{id}")]
        [Authorize]
        [CheckClaimsAttribute("RoleId", "1")]
        public async Task<int> DeleteHome(int id)
        {
            return await _homeService.DeleteHome(id);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<Home> GetHomeById(int id)
        {
            return await _homeService.GetHomeById(id);
        }
    }
}
