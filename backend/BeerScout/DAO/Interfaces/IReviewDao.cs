using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO.Interfaces

{
    public interface IReviewDao
    {
        public IList<Review> GetReviewsByBeerId(int beerId);
        public Review CreateReview(Review review);
        public Review GetReviewById(int id);
    }
}
