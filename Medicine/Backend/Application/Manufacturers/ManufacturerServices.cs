
using Domain.Models;

namespace Application.Manufacturers
{
    public class ManufacturerServices : IManufacturerServices
    {
        private readonly IManufacturerRepository _manufacturerRepository;
        public ManufacturerServices(IManufacturerRepository manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }
        public async Task<List<Manufacturer>> GetAllManufacturersAsync()
        {
            return await _manufacturerRepository.GetAllManufacturersAsync();
        }

        public async Task<Manufacturer?> GetManufacturerByIdAsync(int id)
        {
            return await _manufacturerRepository.GetManufacturerAsync(id);
        }

        public async Task<Manufacturer?> CreateManufacturerAsync(Manufacturer manufacturer)
        {
            return await _manufacturerRepository.CreateManufacturerAsync(manufacturer);
        }

        public async Task<bool> DeleteManufacturerAsync(int id)
        {
            return await _manufacturerRepository.DeleteManufacturerAsync(id);
        }

        public async Task<bool> EditManufacturerAsync(Manufacturer manufacturer)
        {
            return await _manufacturerRepository.EditManufacturerAsync(manufacturer);
        }
    }
}
