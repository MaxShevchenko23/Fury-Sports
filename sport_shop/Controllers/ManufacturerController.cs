using Microsoft.AspNetCore.Mvc;
using sport_shop_bll.Models.GET;
using sport_shop_bll.Models.POST;
using sport_shop_bll.Models.UPDATE;
using sport_shop_bll.Services;

namespace sport_shop.Controllers
{
    [ApiController]
    [Route("Manufacturer")]
    public class ManufacturerController : ControllerBase
    {

        private readonly ManufacturerService service;

        public ManufacturerController(ManufacturerService service)
        {
            this.service = service;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ManufacturerGet))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ManufacturerGet>> GetProductByIdAsync(int id)
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
        [ProducesResponseType(200, Type = typeof(IEnumerable<ManufacturerGet>))]
        public async Task<ActionResult<IEnumerable<ManufacturerGet>>> GetAllProductsAsync()
        {
            var models = await service.GetAllAsync();
            return Ok(models);
        }


        [HttpPost("add")]
        [ProducesResponseType(201, Type = typeof(ManufacturerGet))]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ManufacturerGet>> PostProductAsync([FromBody] ManufacturerPost model)
        {
            var created = await service.AddAsync(model);
            if (created != null)
            {
                return CreatedAtAction("GetProductByIdFullAsync", created.Id);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut("{id}/edit")]
        [ProducesResponseType(200, Type = typeof(ManufacturerGet))]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ManufacturerGet>> PutProductAsync([FromBody] ManufacturerUpdate model, [FromQuery] int id)
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

    }
}
