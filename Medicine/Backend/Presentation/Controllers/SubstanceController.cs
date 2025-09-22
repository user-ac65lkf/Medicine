using Application.Substances;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("substances")]
    [ApiController]
    public class SubstanceController : ControllerBase
    {

        private readonly ISubstanceServices _substanceService;

        public SubstanceController(ISubstanceServices substanceService)
        {
            _substanceService = substanceService;
        }
      
        [HttpGet]
        public async Task<IActionResult> GetAllSubstances()
        {
            var allSubstances = await _substanceService.GetAllSubstancesAsync();
            return Ok(allSubstances);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubstanceById(int id)
        {
            var res = await _substanceService.GetSubstanceByIdAsync(id);
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
        public async Task<IActionResult> CreateSubstance(Substance substance)
        {
            var createdSubstance = await _substanceService.CreateSubstanceAsync(substance);
            if (createdSubstance == null)
            {
                return BadRequest("Entry already exists");
            }
            return CreatedAtAction(nameof(GetSubstanceById), new { id = createdSubstance.Id }, createdSubstance);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubstance(int id)
        {
            var res = await _substanceService.DeleteSubstanceAsync(id);
            if (res)
                return NoContent();
            
            return NotFound(new
            {
                statusCode = 404,
                message = "record not found"
            });            
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSubstance(Substance substance)
        {
            var editedSubstance = await _substanceService.EditSubstanceAsync(substance);
            if (editedSubstance)            
                return NoContent(); ;
            
            return NotFound(new
            {
                statusCode = 404,
                message = "record not found"
            });
        }
    }
}
