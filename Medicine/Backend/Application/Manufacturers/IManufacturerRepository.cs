
using Domain.Models;

namespace Application.Manufacturers
{
    public interface IManufacturerRepository
    {
        Task<List<Manufacturer>> GetAllManufacturersAsync();
        Task<Manufacturer?> GetManufacturerAsync(int id);
        Task<Manufacturer?> CreateManufacturerAsync(Manufacturer manufacturer);
        Task<bool> DeleteManufacturerAsync(int id);
        Task<bool> EditManufacturerAsync(Manufacturer manufacturer);
    }
}
