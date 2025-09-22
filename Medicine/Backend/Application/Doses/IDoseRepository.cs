using Domain.Models;
namespace Application.Doses
{
    public interface IDoseRepository
    {
        Task<List<Dose>> GetAllDosesAsync();
        Task<Dose?> GetDoseAsync(int id);
        Task<Dose?> CreateDoseAsync(Dose dose);
        Task<bool> DeleteDoseAsync(int id);
        Task<bool> EditDoseAsync(Dose dose);
    }
}
