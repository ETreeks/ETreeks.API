using ETreeks.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Core.IService
{
    public interface IReviewService
    {
        Task<int> CreateReview(Review review);
        Task<int> UpdateReview(Review review);
        Task<int> DeleteReview(int reviewId);
        Task<List<Review>> GetAllReviews();
        Task<Review> GetReviewById(int reviewId);
    }
}
