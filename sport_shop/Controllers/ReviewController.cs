using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using sport_shop_bll.Models.GET;
using sport_shop_bll.Models.POST;
using sport_shop_bll.Services;
using System.Net;

namespace sport_shop.Controllers
{
    [ApiController]
    [Route("review")]
    [EnableCors(PolicyName = "AllowLocalHost")]

    public class ReviewController : ControllerBase
    {
        private readonly ReviewService service;

        public ReviewController(ReviewService service)
        {
            this.service = service;
        }

        [HttpGet("product/{productId}")]
        public async Task<ActionResult<IEnumerable<ReviewGet>>> GetReviewsByProductIdAsync(int productId)
        {
            var models = await service.GetByProductIdAsync(productId);
            if (models == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(models);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewGet>> GetReviewByIdAsync(int id)
        {
            var model = await service.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(model);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ReviewGet>> AddReviewAsync(ReviewPost model)
        {
            //if (model.AccountId <= 0)
            //{
            //    return Unauthorized();
            //}

            
            var created = await service.AddAsync(model);
            
            if (created != null)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }


    }
}
