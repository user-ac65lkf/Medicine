using Domain.Models;
namespace Application.Medforms
{
    public class MedformServices : IMedformServices
    {
        private readonly IMedformRepository _medformRepository;
        public MedformServices(IMedformRepository medformRepository)
        {
            _medformRepository = medformRepository;
        }
        public async Task<List<Medform>> GetAllMedformsAsync()
        {
            return await _medformRepository.GetAllMedformsAsync();
        }

        public async Task<Medform?> GetMedformByIdAsync(int id)
        {
            return await _medformRepository.GetMedformAsync(id);
        }

        public async Task<Medform?> CreateMedformAsync(Medform medform)
        {
            return await _medformRepository.CreateMedformAsync(medform);
        }

        public async Task<bool> DeleteMedformAsync(int id)
        {
            return await _medformRepository.DeleteMedformAsync(id);
        }

        public async Task<bool> EditMedformAsync(Medform medform)
        {
            return await _medformRepository.EditMedformAsync(medform);
        }
    }
}
