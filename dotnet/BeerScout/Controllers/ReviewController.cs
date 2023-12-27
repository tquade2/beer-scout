using Capstone.DAO.Interfaces;
using Capstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        public IReviewDao reviewDao;

        public ReviewController(IReviewDao reviewDao)
        {
            this.reviewDao = reviewDao;
        }

        [HttpGet("Bybeer/{id}")]
        public ActionResult<List<Review>> GetReviewsByBeerId(int id)
        {
            return Ok(reviewDao.GetReviewsByBeerId(id));
        }


        [HttpGet("{id}")]
        public ActionResult<Review> GetReviewById(int id)
        {
            return Ok(reviewDao.GetReviewById(id));
        }

        [HttpPost("createReview")]
        public ActionResult<Review> CreateReview(Review newReview)
        {
            Review result = reviewDao.CreateReview(newReview);

            if (result.Id == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok(result);
            }
        }

    }
}
