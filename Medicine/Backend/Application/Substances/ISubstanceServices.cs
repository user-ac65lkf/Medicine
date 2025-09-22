using Domain.Models;
namespace Application.Substances

{
    public interface ISubstanceServices
    {
        Task<List<Substance>> GetAllSubstancesAsync();

        Task<Substance?> GetSubstanceByIdAsync(int id);

        Task<Substance?> CreateSubstanceAsync(Substance substance);

        Task<bool> DeleteSubstanceAsync(int id);

        Task<bool> EditSubstanceAsync(Substance substance);
    }
}
