using ETreeks.Core.Data;
using ETreeks.Core.IRepository;
using ETreeks.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Infra.Service
{

	public class CourseSessionService : ICourseSessionService
	{
		private readonly ICourseSessionRepository _courseSessionRepository;

		public CourseSessionService(ICourseSessionRepository courseSessionRepository)
		{
			_courseSessionRepository = courseSessionRepository;
		}

		public Task<int> CreateCourseSession(CourseSession courseSession)
		{
			return _courseSessionRepository.CreateCourseSession(courseSession);
		}

		public Task<int> UpdateCourseSession(CourseSession courseSession)
		{
			return _courseSessionRepository.UpdateCourseSession(courseSession);
		}

		public Task<int> DeleteCourseSession(int id)
		{
			return _courseSessionRepository.DeleteCourseSession(id);
		}

		public Task<List<CourseSession>> GetAllCourseSessions()
		{
			return _courseSessionRepository.GetAllCourseSessions();
		}

		public Task<CourseSession> GetCourseSessionById(int id)
		{
			return _courseSessionRepository.GetCourseSessionById(id);
		}
	}
}
