using Domain.Models;
namespace Application.Medforms

{
    public interface IMedformServices
    {
        Task<List<Medform>> GetAllMedformsAsync();

        Task<Medform?> GetMedformByIdAsync(int id);

        Task<Medform?> CreateMedformAsync(Medform medform);

        Task<bool> DeleteMedformAsync(int id);

        Task<bool> EditMedformAsync(Medform medform);
    }
}

