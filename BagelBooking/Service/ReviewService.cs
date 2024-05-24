using BagelBooking.Exceptions;
using BagelBooking.Models;
using BagelBooking.Repository;

namespace BagelBooking.Service
{
    public class ReviewService:IReviewService
    {
        private readonly IReviewRepository repo;
        public ReviewService(IReviewRepository repo)
        {

            this.repo = repo;
        }

        public int AddReview(Review review)
        {

            if (repo.GetReview(review.ReviewId) != null)
            {
                throw new ReviewAlreadyExistsException($"Review with Review id {review.ReviewId} already exists");
            }
            return repo.AddReview(review);
        }

        public int DeleteReview(int id)
        {
            if (repo.GetReview(id) == null)
            {
                throw new ReviewNotFoundException($"Review with Review id {id} not Found");
            }
            return repo.DeleteReview(id);
        }

        public Review GetReview(int id)
        {
            Review c = repo.GetReview(id);
            if (c == null)
            {
                throw new ReviewNotFoundException($"Review with Review id {id} does not exists");
            }
            return c;
        }

        public List<Review> GetReviews()
        {
            return repo.GetReviews();
        }

        public int UpdateReview(int id, Review review)
        {
            if (repo.GetReview(id) == null)
            {
                throw new ReviewNotFoundException($"Review with Review id {id} does not exists");
            }
            return repo.UpdateReview(id, review);
        }
        public List<Review> GetReviewsByRating(int rating)
        {
            return(repo.GetReviewsByRating(rating));
        }
    }
}
