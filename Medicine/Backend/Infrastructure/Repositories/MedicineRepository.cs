using Application.AppDTO;
using Application.Helper;
using Application.Medicines;
using Domain.Models;
using Infrastructure.Persistance.MSSqlServer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
      
        private readonly DbContextMSSqlServer _dbContextMSSqlServer;
        public MedicineRepository(DbContextMSSqlServer dbContext)
        {
            _dbContextMSSqlServer = dbContext;
        }

        public async Task<PagedMedicinesDTO> GetAllMedicinesAsync(QueryObject query)
        {
            List<MedicineDTO> allMedicinesdto = [];
            var skipNumber = (query.currentpage - 1) * query.limit;
            
            var allMedicines =  _dbContextMSSqlServer.Medicines.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.tradename))
            {
                allMedicines = allMedicines.Where(q => q.TradeName.Contains(query.tradename));
            }


            allMedicinesdto = await allMedicines
                .Select(u => new MedicineDTO
                {
                    MedicineId = u.Id,
                    MedicineTradeName = u.TradeName,
                    MedicineInterName = u.InterName,
                    MedicineImageUrl = u.ImageUrl,
                    MedicineForm = u.Medform,
                    MedicineManufacturer = new ManufacturerDTO
                    {
                        ManufacturerId = u.Manufacturer.Id,
                        ManufacturerName = u.Manufacturer.ManufacturerName,
                        ManufacturerAddress = u.Manufacturer.ManufacturerAddress,
                        ManufacturerCountry = new CountryDTO
                        {
                            CountryId = u.Manufacturer.CountryId,
                            CountryName = u.Manufacturer.Country.CountryName,
                        }
                    },
                    MedSubstances = u.MedicineSubstances.Select(s => s.Substance).ToList(),
                    MedDoses = u.DoseMedicines.Select(d => d.Dose).ToList(),
                }).Skip(skipNumber).Take(query.limit).ToListAsync();
            var pageTotal = Math.Ceiling(allMedicines.Count() / Convert.ToDecimal(query.limit));
            var PagedMedicines = new PagedMedicinesDTO
            {
                PagedMedicines = allMedicinesdto,
                TotalPages = pageTotal,
                CurrentPage = query.currentpage
            };
            return PagedMedicines;
           
        }

        public async Task<MedicineDTO?> GetMedicineAsync(int id)
        {
            return await _dbContextMSSqlServer.Medicines.Where(x=> x.Id == id)
            .Select(u => new MedicineDTO
            {
                MedicineId = u.Id,
                MedicineTradeName = u.TradeName,
                MedicineInterName = u.InterName,
                MedicineImageUrl = u.ImageUrl,
                MedicineForm = u.Medform,
                MedicineManufacturer = new ManufacturerDTO
                {
                    ManufacturerId = u.Manufacturer.Id,
                    ManufacturerName = u.Manufacturer.ManufacturerName,
                    ManufacturerAddress = u.Manufacturer.ManufacturerAddress,
                    ManufacturerCountry = new CountryDTO
                    {
                        CountryId = u.Manufacturer.CountryId,
                        CountryName = u.Manufacturer.Country.CountryName,
                    }
                },
                MedSubstances = u.MedicineSubstances.Select(s => s.Substance).ToList(),
                MedDoses = u.DoseMedicines.Select(d => d.Dose).ToList(),
            }).FirstOrDefaultAsync();
        }

        public async Task<Medicine?> CreateMedicineAsync(MedicineReqDTO medicineReqDTO)
        {
            var _medicine = new Medicine()
            {
                TradeName = medicineReqDTO.TradeName,
                InterName = medicineReqDTO.InterName,
                ManufacturerId = medicineReqDTO.ManufacturerId,
                MedformId = medicineReqDTO.MedFormId,
                ImageUrl = medicineReqDTO.ImageUrl
            };

            ///////////////////////////////////////////////////////////// Adding substances
            var subs = medicineReqDTO.SubstanceIds;

            if (subs == null) return null;

            List<MedicineSubstance> MedSubs = [];

            for (int i = 0; i < subs.Count; i++)
            {
                MedSubs.Add(new MedicineSubstance { SubstanceId = subs[i] });
            }

            _medicine.MedicineSubstances.AddRange(MedSubs);
            ///////////////////////////////////////////////////////////// Adding doses
            var doses = medicineReqDTO.DoseIds;

            if (doses == null) return null;

            List<DoseMedicine> DoseMeds = [];

            for (int i = 0; i < doses.Count; i++)
            {
                DoseMeds.Add(new DoseMedicine { DoseId = doses[i] });
            }

            _medicine.DoseMedicines.AddRange(DoseMeds);
            ///////////////////////////////////////////////////////////// 
            _dbContextMSSqlServer.Medicines.Add(_medicine);
            await _dbContextMSSqlServer.SaveChangesAsync();

            return _medicine;
        }

        public async Task<bool> DeleteMedicineAsync(int id)
        {
            var rows = await _dbContextMSSqlServer.Medicines.Where(x => x.Id == id).ExecuteDeleteAsync();
            return rows > 0;
        }

        public async Task<bool?> EditMedicineAsync(MedicineReqDTO medicineReqDTO)
        {
            List<MedicineSubstance> tmp = [];
            List<DoseMedicine> tmp1 = [];

            var subs = medicineReqDTO.SubstanceIds;
            var doses = medicineReqDTO.DoseIds;

            _dbContextMSSqlServer.MedicineSubstances.Where(x => x.MedicineId == medicineReqDTO.MedId).ExecuteDelete();
            _dbContextMSSqlServer.DoseMedicines.Where(x => x.MedicineId == medicineReqDTO.MedId).ExecuteDelete();

            for (int i = 0; i < subs.Count; i++)
            {
                tmp.Add(new MedicineSubstance { SubstanceId = subs[i], MedicineId = medicineReqDTO.MedId });
            }
            for (int i = 0; i < doses.Count; i++)
            {
                tmp1.Add(new DoseMedicine { DoseId = doses[i], MedicineId = medicineReqDTO.MedId });
            }

            var old = _dbContextMSSqlServer.Medicines.Where(x => x.Id == medicineReqDTO.MedId).FirstOrDefault();
            if (old != null)
            {
                old.TradeName = medicineReqDTO.TradeName;
                old.InterName = medicineReqDTO.InterName;
                old.ManufacturerId = medicineReqDTO.ManufacturerId;
                old.MedformId = medicineReqDTO.MedFormId;
                old.ImageUrl = medicineReqDTO.ImageUrl;
                old.MedicineSubstances = tmp;
                old.DoseMedicines = tmp1;
            }
            var res = await _dbContextMSSqlServer.SaveChangesAsync();

            return res > 0;
        }
    }
}

