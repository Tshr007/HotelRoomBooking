using BagelBooking.Models;

namespace BagelBooking.Repository
{
    public interface IReviewRepository
    {
        public List<Review> GetReviews();
        Review GetReview(int id);
        int AddReview(Review review);
        int UpdateReview(int id, Review review);
        int DeleteReview(int id);
        List<Review> GetReviewsByRating(int rating);
    }
}
