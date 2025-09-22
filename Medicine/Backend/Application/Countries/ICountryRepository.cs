using Domain.Models;
namespace Application.Countries
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllCountriesAsync();
        Task<Country?> GetCountryAsync(int id);
        Task<Country?> CreateCountryAsync(Country country);
        Task<bool> DeleteCountryAsync(int id);
        Task<bool> EditCountryAsync(Country country);
    }
}
