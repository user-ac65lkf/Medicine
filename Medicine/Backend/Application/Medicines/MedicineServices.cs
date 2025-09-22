using Application.AppDTO;
using Application.Helper;
using Domain.Models;

namespace Application.Medicines
{
    public class MedicineServices : IMedicineServices
    {
        private readonly IMedicineRepository _medicineRepository;
        public MedicineServices(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }
        public async Task<PagedMedicinesDTO> GetAllMedicinesAsync(QueryObject query)
        {
            return await _medicineRepository.GetAllMedicinesAsync(query);
        }
        public async Task<MedicineDTO?> GetMedicineByIdAsync(int id)
        {
            return await _medicineRepository.GetMedicineAsync(id);
        }

        public async Task<Medicine?> CreateMedicineAsync(MedicineReqDTO medicineReqDTO)
        {                   

            return await _medicineRepository.CreateMedicineAsync(medicineReqDTO);
        }

        public async Task<bool> DeleteMedicineAsync(int id)
        {
            return await _medicineRepository.DeleteMedicineAsync(id);
        }

        public async Task<bool?> EditMedicineAsync(MedicineReqDTO medicineReqDTO)
        {           
            return await _medicineRepository.EditMedicineAsync(medicineReqDTO);
        }
    }
}
