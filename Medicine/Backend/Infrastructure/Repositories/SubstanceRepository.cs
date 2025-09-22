
using Application.Substances;
using Domain.Models;
using Infrastructure.Persistance.MSSqlServer;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SubstanceRepository : ISubstanceRepository
    {
        private readonly DbContextMSSqlServer _dbContextMSSqlServer;
        public SubstanceRepository(DbContextMSSqlServer dbContext)
        {
            _dbContextMSSqlServer = dbContext;
        }

        public async Task<List<Substance>> GetAllSubstancesAsync()
        {
            var allSubstances = await _dbContextMSSqlServer.Substances.ToListAsync();
            return allSubstances;
        }

        public async Task<Substance?> GetSubstanceAsync(int id)
        {
            return await _dbContextMSSqlServer.Substances.FindAsync(id);
        }

        public async Task<Substance?> CreateSubstanceAsync(Substance substance)
        {
            var exist = await _dbContextMSSqlServer.Substances.AnyAsync(x => x.TradeName == substance.TradeName);
            if (exist)
            {
                return null;
            }

            _dbContextMSSqlServer.Substances.Add(substance);
            await _dbContextMSSqlServer.SaveChangesAsync();
            return substance;
        }

        public async Task<bool> DeleteSubstanceAsync(int id)
        {
            var rows = await _dbContextMSSqlServer.Substances.Where(x => x.Id == id).ExecuteDeleteAsync();
            return rows > 0;
        }

        public async Task<bool> EditSubstanceAsync(Substance substance)
        {
            var rows = await _dbContextMSSqlServer.Substances.Where(x => x.Id == substance.Id)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(x => x.TradeName, substance.TradeName)
                    .SetProperty(x => x.InternationalName, substance.InternationalName));

            return rows > 0;
        }
    }
}