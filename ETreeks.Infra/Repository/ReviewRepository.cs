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
    public class ReviewRepository : IReviewRepository
    {
        private readonly IDbContext _dbContext;

        public ReviewRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateReview(Review review)
        {
            var param = new DynamicParameters();
            param.Add("review_message", review.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("guser_id", review.Guser_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("course_id", review.Course_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //param.Add("review_id", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var result =  await _dbContext.Connection.ExecuteAsync("Review_Package.CreateReview", param, commandType: CommandType.StoredProcedure);
            //int RID = param.Get<int>("review_id");
            return 1;
        }

        public async Task<int> UpdateReview(Review review)
        {
            var param = new DynamicParameters();
            param.Add("review_id", review.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("new_review_message", review.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("C_id", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var result = await _dbContext.Connection.ExecuteAsync("Review_Package.UpdateReview", param, commandType: CommandType.StoredProcedure);
            int RID = param.Get<int>("C_id");
            return RID;
        }

        public async Task<int> DeleteReview(int id)
        {
            var param = new DynamicParameters();
            param.Add("review_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("C_id", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var result = await _dbContext.Connection.ExecuteAsync("Review_Package.DeleteReview", param, commandType: CommandType.StoredProcedure);
            int RID = param.Get<int>("C_id");
            return RID;
        }

        public async Task<List<Review>> GetAllReviews()
        {
            var result = await _dbContext.Connection.QueryAsync<Review>("Review_Package.GetAllReviews", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Review> GetReviewById(int id)
        {
            var param = new DynamicParameters();
            param.Add("review_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Review>("Review_Package.GetReviewById", param, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
