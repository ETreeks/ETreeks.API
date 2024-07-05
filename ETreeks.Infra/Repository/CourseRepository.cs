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
    public class CourseRepository : ICourseRepository
    {
        private readonly IDbContext _dbContext;

        public CourseRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateCourseAsync(Course course)
        {
            var param = new DynamicParameters();
            param.Add("C_CourseName", course.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("C_ImageName", course.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("C_Price", course.Price, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("C_PassMark", course.Passmark, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("C_CategoryId", course.CategoryId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("C_TrainerId", course.TrainerId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("C_id", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var result = await _dbContext.Connection.ExecuteAsync("COURSE_PACKAGE.CreateCourse", param, commandType: CommandType.StoredProcedure);

            int courseId = param.Get<int>("C_id");
            return courseId;
        }

        public async Task<int> DeleteCourseAsync(int courseId)
        {
            var param = new DynamicParameters();
            param.Add("C_CourseID", courseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("C_id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            var result = await _dbContext.Connection.ExecuteAsync("COURSE_PACKAGE.DeleteCourse", param, commandType: CommandType.StoredProcedure);
            int CourseId = param.Get<int>("C_id");
            return CourseId;
        }


        public async Task<List<Course>> GetAllCoursesAsync()
        {
            var result = await _dbContext.Connection.QueryAsync<Course>("COURSE_PACKAGE.GetAllCourses", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public async Task<Course> GetCourseByIdAsync(int courseId)
        {
            var param = new DynamicParameters();
            param.Add("C_CourseID", courseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Course>("COURSE_PACKAGE.GetCourseById", param, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<int> UpdateCourseAsync(Course course)
        {
            var param = new DynamicParameters();
            param.Add("C_CourseID", course.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("C_CourseName", course.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("C_ImageName", course.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("C_Price", course.Price, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("C_PassMark", course.Passmark, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("C_CategoryId", course.CategoryId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("C_TrainerId", course.TrainerId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("C_id", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var result = await _dbContext.Connection.ExecuteAsync("COURSE_PACKAGE.UpdateCourse", param, commandType: CommandType.StoredProcedure);
            int courseId = param.Get<int>("C_id");
            return courseId;
        }
    }

}
