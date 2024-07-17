using ETreeks.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Core.IRepository
{
    public interface ICourseRepository
    {
        Task CreateCourseAsync(Course course);
        Task UpdateCourseAsync(Course course);
        Task DeleteCourseAsync(int courseId);
        Task<List<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseByIdAsync(int courseId);
    }
}
