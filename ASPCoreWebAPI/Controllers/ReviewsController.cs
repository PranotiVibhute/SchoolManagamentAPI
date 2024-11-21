using ASPCoreWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly EcommerceDbContext _dbContext;

        public ReviewsController(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get
        [HttpGet(Name ="Get Review")]
        public IEnumerable<Review> Get()
        {
            return _dbContext.Reviews.ToList();
        }


        [HttpGet("{id}")]
        public ActionResult<Review> Get(int id)
        {
            var Review=_dbContext.Reviews.FirstOrDefault(r=>r.ReviewId == id);
            if(Review == null)
            {
                return NotFound("Review Not Found");
            }
            return Review;
        }
        //Post
        [HttpPost("PostReview")]
        public ActionResult<Review> PostReview([FromBody]Review review)
        {
            _dbContext.Reviews.Add(review);
            _dbContext.SaveChanges();
            return Ok();
        }



        //Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Review=_dbContext.Reviews.FirstOrDefault(r=>r.ReviewId == id);
            if(Review==null)
            {
                return NotFound("Record Not Found");
            }
            _dbContext.Reviews.Remove(Review);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
