using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using sport_shop_bll.Models.GET;
using sport_shop_bll.Models.POST;
using sport_shop_bll.Services;

namespace sport_shop.Controllers
{
    [EnableCors(PolicyName = "AllowLocalHost")]
    [Route("order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService service;

        public OrderController(OrderService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderGet>> GetOrderByIdAsync(int id)
        {
            var model = await service.GetByIdAsync(id);
            if (model != null)
            {
                return Ok(model);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderGet>>> GetAllOrdersAsync()
        {
            var models = await service.GetAllAsync();

            return Ok(models);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<OrderGet>>> PostOrderAsync(IEnumerable<OrderPost> model)
        {
            var toReturn = new List<OrderGet>();
            var badOrders = new List<OrderPost>();

            foreach (var order in model)
            {
                var created = await service.AddAsync(order);
                if (created != null)
                {
                    toReturn.Add(created);
                }
                else
                {
                    badOrders.Add(order);
                }
            }

            if (badOrders.Any())
            {
                return BadRequest(badOrders);
            }

            return Ok(toReturn);
        }


        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<OrderGet>>> GetOrdersByUserIdAsync(int userId)
        {
            var model = await service.GetByUserId(userId);
            return Ok(model);
        }

        [HttpDelete("{orderId}")]
        public async Task<ActionResult> DeleteOrder(int orderId)
        {
            var isDeleted = await service.DeleteByIdAsync(orderId);
            if (isDeleted)
            {
                return Ok();
            }
            return NotFound();

        }


        [HttpPut]
        public async Task<ActionResult<OrderGet>> ChangeOrderStatus(int orderId, int statusCode)
        {
            var changed = await service.ChangeStatusAsync(orderId, statusCode);
            if(changed != null)
            {
                return Ok(changed);

            }
            return NotFound();
        }
    }
}
