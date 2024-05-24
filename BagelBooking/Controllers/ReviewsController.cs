using BagelBooking.Aspects;
using BagelBooking.Models;
using BagelBooking.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BagelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExceptionHandler]
    [EnableCors("policy")]
    public class ReviewsController : ControllerBase
    {
        // GET: api/<ReviewsController>
        private readonly IReviewService service;

        public ReviewsController(IReviewService service)
        {
            this.service = service;
        }
        // GET: api/<UserController>

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.GetReviews());
        }

        // GET api/<ReviewsController>/5
        //[Authorize(Roles = "Admin,User")]
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(service.GetReview(id));
        }

        // POST api/<ReviewsController>
        //[Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult Post(Review review)
        {
            return StatusCode(201, service.AddReview(review));
        }

        // PUT api/<ReviewsController>/5
        //[Authorize(Roles = "User")]
        //[Authorize(Roles = "User")]
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, Review review)
        {
            return Ok(service.UpdateReview(id, review));
        }

        // DELETE api/<ReviewsController>/5
        //[Authorize(Roles = "Admin,User")]
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(service.DeleteReview(id));
        }
        [HttpGet]
        [Route("{rating}/GetReviewsRating")]
        public IActionResult GetReviewsByRating(int rating)
        {
            return Ok(service.GetReviewsByRating(rating));
        }
    }
}
