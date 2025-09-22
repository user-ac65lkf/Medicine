using Domain.Models;
namespace Application.Substances
{
    public class SubstanceServices : ISubstanceServices
    {
        private readonly ISubstanceRepository _substanceRepository;
        public SubstanceServices(ISubstanceRepository substanceRepository)
        {
            _substanceRepository = substanceRepository;
        }
        public async Task<List<Substance>> GetAllSubstancesAsync()
        {
            return await _substanceRepository.GetAllSubstancesAsync();
        }

        public async Task<Substance?> GetSubstanceByIdAsync(int id)
        {
            return await _substanceRepository.GetSubstanceAsync(id);
        }

        public async Task<Substance?> CreateSubstanceAsync(Substance substance)
        {
            return await _substanceRepository.CreateSubstanceAsync(substance);
        }

        public async Task<bool> DeleteSubstanceAsync(int id)
        {
            return await _substanceRepository.DeleteSubstanceAsync(id);
        }

        public async Task<bool> EditSubstanceAsync(Substance substance)
        {
            return await _substanceRepository.EditSubstanceAsync(substance);
        }
    }
}
