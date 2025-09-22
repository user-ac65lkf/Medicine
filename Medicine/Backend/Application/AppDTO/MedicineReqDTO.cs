
namespace Application.AppDTO
{
    public class MedicineReqDTO
    {
        public int MedId{ get; set; }
        public required string TradeName { get; set; }
        public string? InterName { get; set; } 
        public int ManufacturerId { get; set; }
        public int MedFormId { get; set; }
        public string? ImageUrl { get; set; }
        public List<int> SubstanceIds { get; set; } = null!;
        public List<int> DoseIds { get; set; } = null!;
    }
}
