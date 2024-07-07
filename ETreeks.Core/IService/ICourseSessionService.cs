using ETreeks.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Core.IService
{
	public interface ICourseSessionService
	{

		Task<int> CreateCourseSession(CourseSession courseSession);
		Task<int> UpdateCourseSession(CourseSession courseSession);
		Task<int> DeleteCourseSession(int id);
		Task<List<CourseSession>> GetAllCourseSessions();
		Task<CourseSession> GetCourseSessionById(int id);
	}
}
