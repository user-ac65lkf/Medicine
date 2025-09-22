using Application.Manufacturers;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("manufacturers")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {

        private readonly IManufacturerServices _manufacturerService;

        public ManufacturerController(IManufacturerServices manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllManufacturers()
        {
            var allManufacturers = await _manufacturerService.GetAllManufacturersAsync();
            return Ok(allManufacturers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetManufacturerById(int id)
        {
            var res = await _manufacturerService.GetManufacturerByIdAsync(id);
            if (res == null)
            {
                return NotFound(new
                {
                    statusCode = 404,
                    message = "record not found"
                });
            }
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateManufacturer(Manufacturer manufacturer)
        {
            var createdManufacturer = await _manufacturerService.CreateManufacturerAsync(manufacturer);
            if (createdManufacturer == null)
            {
                return BadRequest("Entry already exists");
            }
            return CreatedAtAction(nameof(GetManufacturerById), new { id = createdManufacturer.Id }, createdManufacturer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManufacturer(int id)
        {
            var res = await _manufacturerService.DeleteManufacturerAsync(id);
            if (res)
                return NoContent();

            return NotFound(new
            {
                statusCode = 404,
                message = "record not found"
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateManufacturer(Manufacturer manufacturer)
        {
            var editedManufacturer = await _manufacturerService.EditManufacturerAsync(manufacturer);
            if (editedManufacturer)
                return NoContent(); ;

            return NotFound(new
            {
                statusCode = 404,
                message = "record not found"
            });
        }
    }
}
