using ETreeks.Core.Data;
using ETreeks.Core.IService;
using ETreeks.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        //[CheckClaims("RoleId", "2")]
        [HttpPost]
        public async Task CreateCourse(Course course)
        {
            //var courseId = await _courseService.CreateCourseAsync(course);
            //return Ok(new { Id = courseId });
            await _courseService.CreateCourseAsync(course);
        }
        //[CheckClaims("RoleId", "2")]
        [HttpDelete("{courseId}")]
        public async Task DeleteCourse(int courseId)
        {
            //var result = await _courseService.DeleteCourseAsync(courseId);
            //if (result == 0)
            //{
            //    return NotFound();
            //}
            //return Ok(new { Id = result });
            await _courseService.DeleteCourseAsync(courseId);
        }
       
        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }


        [HttpGet("{courseId}")]

        public async Task<IActionResult> GetCourseById(int courseId)
        {
            var course = await _courseService.GetCourseByIdAsync(courseId);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }
        //[CheckClaims("RoleId", "2")]
        [HttpPut]
        public async Task UpdateCourse(Course course)
        {
            //var result = await _courseService.UpdateCourseAsync(course);
            //if (result == 0)
            //{
            //    return NotFound();
            //}
            //return Ok(new { Id = result });
            await _courseService.UpdateCourseAsync(course);
        }

        [HttpPost]
        [Route("UploadImage")]
        public Course UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;

            var fullPath = Path.Combine("C:\\Users\\Lenovo\\Desktop\\ETreeks_Angular10\\ETreeks\\src\\assets\\Images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Course item = new Course();
            //item.Imagename = file.FileName;
            item.Imagename = fileName; 
            return item;
        }
    }
}
