using Domain.Models;
using Application.AppDTO;
using Application.Helper;

namespace Application.Medicines
{
    public interface IMedicineRepository
    {
        Task<PagedMedicinesDTO> GetAllMedicinesAsync(QueryObject query);
        Task<MedicineDTO?> GetMedicineAsync(int id);
        Task<Medicine?> CreateMedicineAsync(MedicineReqDTO medicine);
        Task<bool> DeleteMedicineAsync(int id);
        Task<bool?> EditMedicineAsync(MedicineReqDTO medicineReqDTO);
    }
}
