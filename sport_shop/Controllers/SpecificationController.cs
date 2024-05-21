using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sport_shop_bll.Models.GET;
using sport_shop_bll.Models.POST;
using sport_shop_bll.Models.UPDATE;
using sport_shop_bll.Services;

namespace sport_shop.Controllers
{
    [Route("specification")]
    [ApiController]
    public class SpecificationController : ControllerBase
    {
        private readonly SpecificationService service;

        public SpecificationController(SpecificationService service)
        {
            this.service = service;
        }

        [HttpGet("product/{id}")]
        [ProducesResponseType(200, Type = typeof(SpecificationGet))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<SpecificationGet>>> GetSpecificationsByProductIdAsync(int id)
        {
            var model = await service.GetSpecificationsByProductIdAsync(id);
            if (model != null)
            {
                return Ok(model);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(SpecificationGet))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<SpecificationGet>> GetSpecificationByIdAsync(int id)
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
        [ProducesResponseType(200, Type = typeof(IEnumerable<SpecificationGet>))]
        public async Task<ActionResult<IEnumerable<SpecificationGet>>> GetAllSpecificationsAsync()
        {
            var models = await service.GetAllAsync();
            return Ok(models);
        }


        [HttpPost("add")]
        [ProducesResponseType(201, Type = typeof(SpecificationGet))]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<SpecificationGet>> PostSpecificationAsync([FromBody] SpecificationPost model)
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
        [ProducesResponseType(200, Type = typeof(SpecificationGet))]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<SpecificationGet>> PutSpecificationAsync([FromBody] SpecificationUpdate model, [FromQuery] int id)
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
        public async Task<ActionResult> RemoveSpecificationAsync([FromQuery] int id)
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
