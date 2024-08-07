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
        public async Task CreateCourseAsync(Course course)
        {
            var param = new DynamicParameters();
            param.Add("course_name", course.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("image_name", course.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("price", course.Price, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("pass_mark", course.Passmark, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("category_id", course.Category_Id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("trainer_id", course.Trainer_Id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            //param.Add("C_id", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var result = await _dbContext.Connection.ExecuteAsync("COURSE_PACKAGE.CreateCourse", param, commandType: CommandType.StoredProcedure);

            //int courseId = param.Get<int>("C_id");
            //return courseId;
        }

        public async Task DeleteCourseAsync(int courseId)
        {
            var param = new DynamicParameters();
            param.Add("course_id", courseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //param.Add("C_id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            var result = await _dbContext.Connection.ExecuteAsync("COURSE_PACKAGE.DeleteCourse", param, commandType: CommandType.StoredProcedure);
            //int CourseId = param.Get<int>("C_id");
            //return CourseId;
        }


        public async Task<List<Course>> GetAllCoursesAsync()
        {
            var result = await _dbContext.Connection.QueryAsync<Course>("COURSE_PACKAGE.GetAllCourses", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public async Task<Course> GetCourseByIdAsync(int courseId)
        {
            var param = new DynamicParameters();
            param.Add("course_id", courseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Course>("COURSE_PACKAGE.GetCourseById", param, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task UpdateCourseAsync(Course course)
        {
            var param = new DynamicParameters();
            param.Add("course_id", course.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("new_course_name", course.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("new_image_name", course.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("new_price", course.Price, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("new_pass_mark", course.Passmark, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("new_category_id", course.Category_Id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("new_trainer_id", course.Trainer_Id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            //param.Add("C_id", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var result = await _dbContext.Connection.ExecuteAsync("COURSE_PACKAGE.UpdateCourse", param, commandType: CommandType.StoredProcedure);
            //int courseId = param.Get<int>("C_id");
            //return courseId;
        }
    }

}
