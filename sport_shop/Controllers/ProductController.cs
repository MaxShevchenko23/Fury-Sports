using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using sport_shop_bll.Models.Filter;
using sport_shop_bll.Models.GET;
using sport_shop_bll.Models.POST;
using sport_shop_bll.Models.UPDATE;
using sport_shop_bll.Services;

namespace sport_shop.Controllers
{
    [EnableCors(PolicyName = "AllowLocalHost")]
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService service;

        public ProductController(ProductService service)
        {
            this.service = service;
        }

        [HttpGet("{id}/short")]
        [ProducesResponseType(200, Type = typeof(ProductShortGet))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ProductShortGet>> GetProductByIdShortAsync(int id)
        {
            var model = await service.GetByIdAsyncShort(id);
            if (model != null)
            {
                return Ok(model);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}/full")]
        [ProducesResponseType(200, Type = typeof(ProductFullGet))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ProductFullGet>> GetProductByIdFullAsync(int id)
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

        [HttpGet("all")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProductShortGet>))]
        public async Task<ActionResult<IEnumerable<ProductShortGet>>> GetAllProductsAsync()
        {
            var models = await service.GetAllAsync();
            return Ok(models);
        }

        [HttpPost("filter")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProductFullGet>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<ProductFullGet>>> GetFilteredProducts(string? name, int? categoryId, int? manufacturerId,
            string? description, decimal? minPrice, decimal? maxPrice, int? quantity, IEnumerable<SpecificationFilter>? specs, int pageNumber = 1, int pageSize = 10)
        {

            var models = await service.GetFiltered(name, categoryId, manufacturerId, description, minPrice, maxPrice, quantity, pageSize, pageNumber, specs);

            if (!models.IsNullOrEmpty())
            {
                return Ok(models);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost("add")]
        [ProducesResponseType(201, Type = typeof(ProductFullGet))]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ProductFullGet>> PostProductAsync(ProductPost model)
        {
            var created = await service.AddAsync(model);
            if (created != null)
            {
                return Ok(created);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut("{id}/edit")]
        [ProducesResponseType(200, Type = typeof(ProductFullGet))]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ProductFullGet>> PutProductAsync([FromBody] ProductUpdate model, int id)
        {
            var updated = await service.UpdateAsync(model, id);
            if (updated != null)
            {
                return Ok(updated);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}/delete")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> RemoveProductAsync([FromQuery] int id)
        {
            var isDeleted = await service.DeleteByIdAsync(id);
            if (isDeleted)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPatch("{id}/edit")]
        public async Task<ActionResult<ProductFullGet>> EditProductAsync(int id, [FromBody] JsonPatchDocument<ProductFullGet> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }

            var model = await service.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            patchDocument.ApplyTo(model, ModelState);

            var updated = await service.UpdateAsync(model, id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }

    }
}
