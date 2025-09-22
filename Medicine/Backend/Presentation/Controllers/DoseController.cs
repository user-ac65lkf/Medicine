using Application.Doses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("doses")]
    [ApiController]
    public class DoseController : ControllerBase
    {

        private readonly IDoseServices _doseService;

        public DoseController(IDoseServices doseService)
        {
            _doseService = doseService;
        }
      
        [HttpGet]
        public async Task<IActionResult> GetAllDoses()
        {
            var allDoses = await _doseService.GetAllDosesAsync();
            return Ok(allDoses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoseById(int id)
        {
            var res = await _doseService.GetDoseByIdAsync(id);
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
        public async Task<IActionResult> CreateDose(Dose dose)
        {
            var createdDose = await _doseService.CreateDoseAsync(dose);
            if (createdDose == null)
            {
                return BadRequest("Entry already exists");
            }
            return CreatedAtAction(nameof(GetDoseById), new { id = createdDose.Id }, createdDose);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDose(int id)
        {
            var res = await _doseService.DeleteDoseAsync(id);
            if (res)
                return NoContent();
            
            return NotFound(new
            {
                statusCode = 404,
                message = "record not found"
            });            
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDose(Dose dose)
        {
            var editedDose = await _doseService.EditDoseAsync(dose);
            if (editedDose)            
                return NoContent(); ;
            
            return NotFound(new
            {
                statusCode = 404,
                message = "record not found"
            });
        }
    }
}
