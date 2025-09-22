
using Application.Doses;
using Domain.Models;
using Infrastructure.Persistance.MSSqlServer;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class DoseRepository : IDoseRepository
    {
        private readonly DbContextMSSqlServer _dbContextMSSqlServer;
        public DoseRepository(DbContextMSSqlServer dbContext)
        {
            _dbContextMSSqlServer = dbContext;
        }

        public async Task<List<Dose>> GetAllDosesAsync()
        {
            var allDoses = await _dbContextMSSqlServer.Doses.ToListAsync();
            return allDoses;
        }

        public async Task<Dose?> GetDoseAsync(int id)
        {
            return await _dbContextMSSqlServer.Doses.FindAsync(id);
        }

        public async Task<Dose?> CreateDoseAsync(Dose dose)
        {
            var exist = await _dbContextMSSqlServer.Doses.AnyAsync(x => x.Title == dose.Title && x.Dosage == dose.Dosage);
            if (exist)
            {
                return null;
            }

            _dbContextMSSqlServer.Doses.Add(dose);
            await _dbContextMSSqlServer.SaveChangesAsync();
            return dose;
        }

        public async Task<bool> DeleteDoseAsync(int id)
        {
            var rows = await _dbContextMSSqlServer.Doses.Where(x => x.Id == id).ExecuteDeleteAsync();
            return rows > 0;
        }

        public async Task<bool> EditDoseAsync(Dose dose)
        {
            var rows = await _dbContextMSSqlServer.Doses.Where(x => x.Id == dose.Id)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(x => x.Title, dose.Title));

            return rows > 0;
        }
    }
}