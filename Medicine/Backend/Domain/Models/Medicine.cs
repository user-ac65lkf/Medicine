
namespace Domain.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public required string TradeName { get; set; }
        public string? InterName { get; set; }
        public string? ImageUrl { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; } = null!;
        public int MedformId { get; set; }
        public Medform Medform { get; set; } = null!;
        public List<MedicineSubstance> MedicineSubstances { get; set; } = [];
        public List<DoseMedicine> DoseMedicines { get; set; } = [];
    }
    
}
