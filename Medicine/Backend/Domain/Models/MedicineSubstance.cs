
namespace Domain.Models
{
    public class MedicineSubstance
    {
        public int SubstanceId { get; set; }
        public Substance? Substance { get; set; }
        public int MedicineId { get; set; }
        public Medicine? Medicine { get; set; }
    }
}
