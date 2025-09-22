using Domain.Models;
namespace Application.Countries

{
    public interface ICountryServices
    {
        Task<List<Country>> GetAllCountriesAsync();

        Task<Country?> GetCountryByIdAsync(int id);

        Task<Country?> CreateCountryAsync(Country country);

        Task<bool> DeleteCountryAsync(int id);

        Task<bool> EditCountryAsync(Country country);
    }
}


