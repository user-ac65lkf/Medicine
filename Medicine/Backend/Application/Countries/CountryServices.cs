using Domain.Models;
namespace Application.Countries
{
    public class CountryServices : ICountryServices
    {
        private readonly ICountryRepository _countryRepository;
        public CountryServices(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public async Task<List<Country>> GetAllCountriesAsync()
        {
            return await _countryRepository.GetAllCountriesAsync();
        }

        public async Task<Country?> GetCountryByIdAsync(int id)
        {
            return await _countryRepository.GetCountryAsync(id);
        }

        public async Task<Country?> CreateCountryAsync(Country country)
        {
            return await _countryRepository.CreateCountryAsync(country);
        }

        public async Task<bool> DeleteCountryAsync(int id)
        {
            return await _countryRepository.DeleteCountryAsync(id);
        }

        public async Task<bool> EditCountryAsync(Country country)
        {
            return await _countryRepository.EditCountryAsync(country);
        }
    }
}
