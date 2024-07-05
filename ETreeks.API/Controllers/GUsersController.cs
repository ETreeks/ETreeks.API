using ETreeks.Core.Data;
using ETreeks.Core.DTO;
using ETreeks.Core.IService;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GUsersController : ControllerBase
    {
        private readonly IGUsersService  _gUsersService  ;

        public GUsersController(IGUsersService gUsersService)
        {
            _gUsersService = gUsersService;
        }

        [HttpGet]
        [Route("GetById/{id}")]
        //public async Task<Guser> GetUserById(int id)
        //{
        //    return await _gUsersService.GetUserById(id);
        //}
        public async Task<StudentInfo> GetStudentById(int id)
        {
            return await _gUsersService.GetStudentById(id);
        }



        [HttpGet]
        [Route("GetTrainerById/{id}")]
        public async Task<Guser> GetTrainerById(int id)
        {
            return await _gUsersService.GetTrainerById(id);
        }
    }
}
