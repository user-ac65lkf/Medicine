using Application.AppDTO;
using Application.Helper;
using Domain.Models;

namespace Application.Medicines
{
    public interface IMedicineServices
    {
        Task<PagedMedicinesDTO> GetAllMedicinesAsync(QueryObject query);

        Task<MedicineDTO?> GetMedicineByIdAsync(int id);

        Task<Medicine?> CreateMedicineAsync(MedicineReqDTO medicineReqDTO);

        Task<bool> DeleteMedicineAsync(int id);

        Task<bool?> EditMedicineAsync(MedicineReqDTO medicineReqDTO);
    }
}
