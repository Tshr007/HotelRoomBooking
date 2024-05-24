using BagelBooking.Exceptions;
using BagelBooking.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BagelBooking.Repository
{
    public class ReviewRepository:IReviewRepository
    {
        private readonly AppDbContext db;

        public ReviewRepository(AppDbContext db)
        {
            this.db = db;
        }
        public int AddReview(Review review)
        {
            db.Reviews.Add(review);
            return db.SaveChanges();
        }

        public int DeleteReview(int id)
        {
            Review c = db.Reviews.Where(x => x.ReviewId == id).FirstOrDefault();
            db.Reviews.Remove(c);
            return db.SaveChanges();
        }

        public Review GetReview(int id)
        {
            return db.Reviews.Where(x => x.ReviewId == id).FirstOrDefault();
        }

        public List<Review> GetReviews()
        {
            return db.Reviews.ToList();
        }

        public int UpdateReview(int id, Review review)
        {
            Review c = db.Reviews.Where(x => x.RoomId == id).FirstOrDefault();
            c.UserId = review.UserId;
            c.RoomId = review.RoomId;
            c.Comment = review.Comment;
            c.Rating = review.Rating;

            db.Entry<Review>(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges();
        }
        public List<Review> GetReviewsByRating(int rating)
        {
            string rav = "exec GetReviewsByRating @rating";
            var parameter = new SqlParameter("@rating", rating);
            return db.Reviews.FromSqlRaw(rav, parameter).ToList();
        }
    }
}
