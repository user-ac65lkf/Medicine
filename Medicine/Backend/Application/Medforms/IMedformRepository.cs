using Domain.Models;
namespace Application.Medforms
{
    public interface IMedformRepository
    {
        Task<List<Medform>> GetAllMedformsAsync();
        Task<Medform?> GetMedformAsync(int id);
        Task<Medform?> CreateMedformAsync(Medform medform);
        Task<bool> DeleteMedformAsync(int id);
        Task<bool> EditMedformAsync(Medform medform);
    }
}
