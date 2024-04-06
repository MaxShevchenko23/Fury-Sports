using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace sport_shop.Controllers
{
    [EnableCors(PolicyName = "AllowLocalHost")]
    [ApiController]
    [Route("cart")]
    public class CartController
    {
    }
}
