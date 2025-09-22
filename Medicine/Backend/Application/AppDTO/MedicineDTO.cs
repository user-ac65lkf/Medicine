using Domain.Models;
namespace Application.AppDTO
{
    public class MedicineDTO
    {
        public int MedicineId { get; set; }
        public string? MedicineTradeName { get; set; }
        public string? MedicineInterName { get; set; }
        public string? MedicineImageUrl { get; set; }
        public Medform MedicineForm { get; set; } = null!;
        public ManufacturerDTO MedicineManufacturer { get; set; } = null!;
        public List<Substance?> MedSubstances { get; set; } = [];
        public List<Dose> MedDoses { get; set; } = [];
    }
}
