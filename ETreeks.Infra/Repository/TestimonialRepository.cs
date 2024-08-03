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
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly IDbContext _dbContext;

        public TestimonialRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public async Task<int> CreateTestimonial(Testimonial testimonial)
        //{
        //    var param = new DynamicParameters();
        //    param.Add("testimonial_text", testimonial.Testimonialstext, dbType: DbType.String, direction: ParameterDirection.Input);
        //    param.Add("gusers_id", testimonial.Gusers_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //    param.Add("C_id", dbType: DbType.Int32, direction: ParameterDirection.Output);

        //    var result = await _dbContext.Connection.ExecuteAsync("Testimonial_Package.CreateTestimonial", param, commandType: CommandType.StoredProcedure);
        //    int TID = param.Get<int>("C_id");
        //    return TID;
        //}
        public async Task<int> CreateTestimonial(Testimonial testimonial)
        {
            var param = new DynamicParameters();
            param.Add("testimonial_text", testimonial.Testimonialstext, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("gusers_id", testimonial.Gusers_Id, dbType: DbType.Decimal, direction: ParameterDirection.Input); // Changed to DbType.Decimal

            var result = await _dbContext.Connection.ExecuteAsync("Testimonial_Package.CreateTestimonial", param, commandType: CommandType.StoredProcedure);
            return result;
        }

        ////public async Task<int> UpdateTestimonial(Testimonial testimonial)
        ////{
        ////    var param = new DynamicParameters();
        ////    param.Add("testimonial_id", testimonial.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
        ////    param.Add("new_testimonial_text", testimonial.Testimonialstext, dbType: DbType.String, direction: ParameterDirection.Input);
        ////    param.Add("C_id", dbType: DbType.Int32, direction: ParameterDirection.Output);

        ////    var result = await _dbContext.Connection.ExecuteAsync("Testimonial_Package.UpdateTestimonial", param, commandType: CommandType.StoredProcedure);
        ////    int TID = param.Get<int>("C_id");
        ////    return TID;
        ////}
        public async Task<int> UpdateTestimonial(Testimonial testimonial)
        {
            var param = new DynamicParameters();
            param.Add("testimonial_id", testimonial.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("new_testimonial_text", testimonial.Testimonialstext, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("Testimonial_Package.UpdateTestimonial", param, commandType: CommandType.StoredProcedure);
            return result;
        }
        public async Task DeleteTestimonial(int id)
        {
            var param = new DynamicParameters();
            param.Add("testimonial_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //param.Add("C_id", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var result = await _dbContext.Connection.ExecuteAsync("Testimonial_Package.DeleteTestimonial", param, commandType: CommandType.StoredProcedure);
            //int TID = param.Get<int>("C_id");
            //return TID;
        }



        public async Task<List<Testimonial>> GetAllTestimonials()
        {
            var result = await _dbContext.Connection.QueryAsync<Testimonial>("Testimonial_Package.GetAllTestimonials", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Testimonial> GetTestimonialById(int id)
        {
            var param = new DynamicParameters();
            param.Add("testimonial_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Testimonial>("Testimonial_Package.GetTestimonialById", param, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
