using Application.Countries;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("countries")]
    [ApiController]
    public class CountryController : ControllerBase
    {

        private readonly ICountryServices _countryService;

        public CountryController(ICountryServices countryService)
        {
            _countryService = countryService;
        }
      
        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            var allCountrys = await _countryService.GetAllCountriesAsync();
            return Ok(allCountrys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountryById(int id)
        {
            var res = await _countryService.GetCountryByIdAsync(id);
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
        public async Task<IActionResult> CreateCountry(Country country)
        {
            var createdCountry = await _countryService.CreateCountryAsync(country);
            if (createdCountry == null)
            {
                return BadRequest("Entry already exists");
            }
            return CreatedAtAction(nameof(GetCountryById), new { id = createdCountry.Id }, createdCountry);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var res = await _countryService.DeleteCountryAsync(id);
            if (res)
                return NoContent();
            
            return NotFound(new
            {
                statusCode = 404,
                message = "record not found"
            });            
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCountry(Country country)
        {
            var editedCountry = await _countryService.EditCountryAsync(country);
            if (editedCountry)            
                return NoContent(); ;
            
            return NotFound(new
            {
                statusCode = 404,
                message = "record not found"
            });
        }
    }
}
