using Microsoft.AspNetCore.Mvc;
using sport_shop_bll.Models.GET;
using sport_shop_bll.Models.POST;
using sport_shop_bll.Models.UPDATE;
using sport_shop_bll.Services;

namespace sport_shop.Controllers
{
    [ApiController]
    [Route("category")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService service;

        public CategoryController(CategoryService service) 
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(CategoryGet))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CategoryGet>> GetCategoryByIdAsync(int id)
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
        [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryGet>))]
        public async Task<ActionResult<IEnumerable<CategoryGet>>> GetAllCategoriesAsync()
        {
            var models = await service.GetAllAsync();
            return Ok(models);
        }

        [HttpGet("all/children")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryForCatalogueGet>))]
        public async Task<ActionResult<List<CategoryForCatalogueGet>>> GetAllCategoriesWithChildAsync()
        {
            var models = await service.GetCategoriesWithChildListAsync();
            return Ok(models);
        }


        [HttpPost("add")]
        [ProducesResponseType(201, Type = typeof(CategoryGet))]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<CategoryGet>> PostCategoryAsync([FromBody] CategoryPost model)
        {
            var created = await service.AddAsync(model);
            if (created != null)
            {
                return CreatedAtAction("GetCategoryByIdAsync", created.Id);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut("{id}/edit")]
        [ProducesResponseType(200, Type = typeof(CategoryGet))]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CategoryGet>> PutCategoryAsync([FromBody] CategoryUpdate model, [FromQuery] int id)
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
        public async Task<ActionResult> RemoveCategoryAsync([FromQuery] int id)
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
    }
}
