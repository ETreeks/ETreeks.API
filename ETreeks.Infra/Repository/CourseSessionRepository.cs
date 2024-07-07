using Dapper;
using ETreeks.Core.Data;
using ETreeks.Core.ICommon;
using ETreeks.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Infra.Repository
{

	public class CourseSessionRepository : ICourseSessionRepository
	{
		private readonly IDbContext _dbContext;

		public CourseSessionRepository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<int> CreateCourseSession(CourseSession courseSession)
		{
			var param = new DynamicParameters();
			param.Add("Name", courseSession.Name, dbType: DbType.String, direction: ParameterDirection.Input);
			param.Add("Start_Date", courseSession.Startdate, dbType: DbType.Date, direction: ParameterDirection.Input);
			param.Add("End_Date", courseSession.Enddate, dbType: DbType.Date, direction: ParameterDirection.Input);
			param.Add("Available_Status", courseSession.AvailableStatus, dbType: DbType.String, direction: ParameterDirection.Input);
			param.Add("Course_ID", courseSession.CourseId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

			var result = await _dbContext.Connection.ExecuteAsync("COURSE_SESSION_PACKAGE.CREATE_COURSE_SESSION", param, commandType: CommandType.StoredProcedure);

			return result;
		}

		public async Task<int> UpdateCourseSession(CourseSession courseSession)
		{
			var param = new DynamicParameters();
			param.Add("Session_ID", courseSession.Id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
			param.Add("new_Name", courseSession.Name, dbType: DbType.String, direction: ParameterDirection.Input);
			param.Add("new_Start_Date", courseSession.Startdate, dbType: DbType.Date, direction: ParameterDirection.Input);
			param.Add("new_End_Date", courseSession.Enddate, dbType: DbType.Date, direction: ParameterDirection.Input);
			param.Add("new_Available_Status", courseSession.AvailableStatus, dbType: DbType.String, direction: ParameterDirection.Input);
			param.Add("new_Course_ID", courseSession.CourseId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

			var result = await _dbContext.Connection.ExecuteAsync("COURSE_SESSION_PACKAGE.UPDATE_COURSE_SESSION", param, commandType: CommandType.StoredProcedure);

			return result;
		}

		public async Task<int> DeleteCourseSession(int id)
		{
			var param = new DynamicParameters();
			param.Add("Session_ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

			var result = await _dbContext.Connection.ExecuteAsync("COURSE_SESSION_PACKAGE.DELETE_COURSE_SESSION", param, commandType: CommandType.StoredProcedure);

			return result;
		}

		public async Task<List<CourseSession>> GetAllCourseSessions()
		{
			var result = await _dbContext.Connection.QueryAsync<CourseSession>("COURSE_SESSION_PACKAGE.GET_ALL_COURSE_SESSIONS", commandType: CommandType.StoredProcedure);
			return result.ToList();
		}

		public async Task<CourseSession> GetCourseSessionById(int id)
		{
			var param = new DynamicParameters();
			param.Add("Session_ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

			var result = await _dbContext.Connection.QueryAsync<CourseSession>("COURSE_SESSION_PACKAGE.GET_COURSE_SESSION_BY_ID", param, commandType: CommandType.StoredProcedure);
			return result.FirstOrDefault();
		}
	}
}