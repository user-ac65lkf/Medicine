
using Application.Countries;
using Domain.Models;
using Infrastructure.Persistance.MSSqlServer;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DbContextMSSqlServer _dbContextMSSqlServer;
        public CountryRepository(DbContextMSSqlServer dbContext)
        {
            _dbContextMSSqlServer = dbContext;
        }

        public async Task<List<Country>> GetAllCountriesAsync()
        {
            var allCountries = await _dbContextMSSqlServer.Countries.ToListAsync();
            return allCountries;
        }

        public async Task<Country?> GetCountryAsync(int id)
        {
            return await _dbContextMSSqlServer.Countries.FindAsync(id);
        }

        public async Task<Country?> CreateCountryAsync(Country country)
        {
            var exist = await _dbContextMSSqlServer.Countries.AnyAsync(x => x.CountryName == country.CountryName);
            if (exist)
            {
                return null;
            }

            _dbContextMSSqlServer.Countries.Add(country);
            await _dbContextMSSqlServer.SaveChangesAsync();
            return country;
        }

        public async Task<bool> DeleteCountryAsync(int id)
        {
            var rows = await _dbContextMSSqlServer.Countries.Where(x => x.Id == id).ExecuteDeleteAsync();
            return rows > 0;
        }

        public async Task<bool> EditCountryAsync(Country country)
        {
            var rows = await _dbContextMSSqlServer.Countries.Where(x => x.Id == country.Id)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(x => x.CountryName, country.CountryName));

            return rows > 0;
        }
    }
}