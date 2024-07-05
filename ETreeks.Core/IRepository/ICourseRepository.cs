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
        Task<int> CreateCourseAsync(Course course);
        Task<int> UpdateCourseAsync(Course course);
        Task<int> DeleteCourseAsync(int courseId);
        Task<List<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseByIdAsync(int courseId);
    }
}
