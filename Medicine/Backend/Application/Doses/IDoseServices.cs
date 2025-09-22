using Domain.Models;
namespace Application.Doses

{
    public interface IDoseServices
    {
        Task<List<Dose>> GetAllDosesAsync();

        Task<Dose?> GetDoseByIdAsync(int id);

        Task<Dose?> CreateDoseAsync(Dose dose);

        Task<bool> DeleteDoseAsync(int id);

        Task<bool> EditDoseAsync(Dose dose);
    }
}

