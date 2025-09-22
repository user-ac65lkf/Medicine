
using Application.Medforms;
using Domain.Models;
using Infrastructure.Persistance.MSSqlServer;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MedformRepository : IMedformRepository
    {
        private readonly DbContextMSSqlServer _dbContextMSSqlServer;
        public MedformRepository(DbContextMSSqlServer dbContext)
        {
            _dbContextMSSqlServer = dbContext;
        }

        public async Task<List<Medform>> GetAllMedformsAsync()
        {
            var allMedforms = await _dbContextMSSqlServer.Medforms.ToListAsync();
            return allMedforms;
        }

        public async Task<Medform?> GetMedformAsync(int id)
        {
            return await _dbContextMSSqlServer.Medforms.FindAsync(id);
        }

        public async Task<Medform?> CreateMedformAsync(Medform medform)
        {
            var exist = await _dbContextMSSqlServer.Medforms.AnyAsync(x => x.Title == medform.Title);
            if (exist)
            {
                return null;
            }

            _dbContextMSSqlServer.Medforms.Add(medform);
            await _dbContextMSSqlServer.SaveChangesAsync();
            return medform;
        }

        public async Task<bool> DeleteMedformAsync(int id)
        {
            var rows = await _dbContextMSSqlServer.Medforms.Where(x => x.Id == id).ExecuteDeleteAsync();
            return rows > 0;
        }

        public async Task<bool> EditMedformAsync(Medform medform)
        {
            var rows = await _dbContextMSSqlServer.Medforms.Where(x => x.Id == medform.Id)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(x => x.Title, medform.Title));

            return rows > 0;
        }
    }
}