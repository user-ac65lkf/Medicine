using Domain.Models;


namespace Application.Substances
{
    public interface ISubstanceRepository
    {
        Task<List<Substance>> GetAllSubstancesAsync();
        Task<Substance?> GetSubstanceAsync(int id);
        Task<Substance?> CreateSubstanceAsync(Substance substance);
        Task<bool> DeleteSubstanceAsync(int id);
        Task<bool> EditSubstanceAsync(Substance substance);
    }
}
