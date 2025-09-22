using Domain.Models;
namespace Application.Doses
{
    public class DoseServices : IDoseServices
    {
        private readonly IDoseRepository _doseRepository;
        public DoseServices(IDoseRepository doseRepository)
        {
            _doseRepository = doseRepository;
        }
        public async Task<List<Dose>> GetAllDosesAsync()
        {
            return await _doseRepository.GetAllDosesAsync();
        }

        public async Task<Dose?> GetDoseByIdAsync(int id)
        {
            return await _doseRepository.GetDoseAsync(id);
        }

        public async Task<Dose?> CreateDoseAsync(Dose dose)
        {
            return await _doseRepository.CreateDoseAsync(dose);
        }

        public async Task<bool> DeleteDoseAsync(int id)
        {
            return await _doseRepository.DeleteDoseAsync(id);
        }

        public async Task<bool> EditDoseAsync(Dose dose)
        {
            return await _doseRepository.EditDoseAsync(dose);
        }
    }
}
