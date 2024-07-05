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
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<int> CreateReview(Review review)
        {
            return await _reviewRepository.CreateReview(review);
        }

        public async Task<int> UpdateReview(Review review)
        {
            return await _reviewRepository.UpdateReview(review);
        }

        public async Task<int> DeleteReview(int reviewId)
        {
            return await _reviewRepository.DeleteReview(reviewId);
        }

        public async Task<List<Review>> GetAllReviews()
        {
            return await _reviewRepository.GetAllReviews();
        }

        public async Task<Review> GetReviewById(int reviewId)
        {
            return await _reviewRepository.GetReviewById(reviewId);
        }
    }
}
