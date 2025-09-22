using Application.Manufacturers;
using Domain.Models;
using Infrastructure.Persistance.MSSqlServer;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class ManufacturerRepository : IManufacturerRepository
    {
        private readonly DbContextMSSqlServer _dbContextMSSqlServer;
        public ManufacturerRepository(DbContextMSSqlServer dbContext)
        {
            _dbContextMSSqlServer = dbContext;
        }

        public async Task<List<Manufacturer>> GetAllManufacturersAsync()
        {
            var allManufacturers = await _dbContextMSSqlServer.Manufacturers.ToListAsync();
            return allManufacturers;
        }

        public async Task<Manufacturer?> GetManufacturerAsync(int id)
        {
            return await _dbContextMSSqlServer.Manufacturers.FindAsync(id);
        }

        public async Task<Manufacturer?> CreateManufacturerAsync(Manufacturer manufacturer)
        {
            var exist = await _dbContextMSSqlServer.Manufacturers.AnyAsync(x => x.ManufacturerName == manufacturer.ManufacturerName);
            if (exist)
            {
                return null;
            }

            _dbContextMSSqlServer.Manufacturers.Add(manufacturer);
            await _dbContextMSSqlServer.SaveChangesAsync();
            return manufacturer;
        }

        public async Task<bool> DeleteManufacturerAsync(int id)
        {
            var rows = await _dbContextMSSqlServer.Manufacturers.Where(x => x.Id == id).ExecuteDeleteAsync();
            return rows > 0;
        }

        public async Task<bool> EditManufacturerAsync(Manufacturer manufacturer)
        {
            var rows = await _dbContextMSSqlServer.Manufacturers.Where(x => x.Id == manufacturer.Id)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(x => x.ManufacturerName, manufacturer.ManufacturerName)
                    .SetProperty(x => x.ManufacturerAddress, manufacturer.ManufacturerAddress));

            return rows > 0;
        }
    }
}
