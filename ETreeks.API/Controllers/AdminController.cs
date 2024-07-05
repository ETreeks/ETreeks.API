using ETreeks.Core.Data;
using ETreeks.Core.DTO;
using ETreeks.Core.IService;
using ETreeks.Infra.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.DirectoryServices;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
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
        public async Task<List<Guser>> GetAllPendingTrainer()
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


    }
}
