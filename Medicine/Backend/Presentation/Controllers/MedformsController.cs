using Application.Medforms;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("medforms")]
    [ApiController]
    public class MedformController : ControllerBase
    {

        private readonly IMedformServices _medformService;

        public MedformController(IMedformServices medformService)
        {
            _medformService = medformService;
        }
      
        [HttpGet]
        public async Task<IActionResult> GetAllMedforms()
        {
            var allMedforms = await _medformService.GetAllMedformsAsync();
            return Ok(allMedforms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedformById(int id)
        {
            var res = await _medformService.GetMedformByIdAsync(id);
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
        public async Task<IActionResult> CreateMedform(Medform medform)
        {
            var createdMedform = await _medformService.CreateMedformAsync(medform);
            if (createdMedform == null)
            {
                return BadRequest("Entry already exists");
            }
            return CreatedAtAction(nameof(GetMedformById), new { id = createdMedform.Id }, createdMedform);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedform(int id)
        {
            var res = await _medformService.DeleteMedformAsync(id);
            if (res)
                return NoContent();
            
            return NotFound(new
            {
                statusCode = 404,
                message = "record not found"
            });            
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMedform(Medform medform)
        {
            var editedMedform = await _medformService.EditMedformAsync(medform);
            if (editedMedform)            
                return NoContent(); ;
            
            return NotFound(new
            {
                statusCode = 404,
                message = "record not found"
            });
        }
    }
}
