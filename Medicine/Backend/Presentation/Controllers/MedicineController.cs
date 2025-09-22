using Application.AppDTO;
using Application.Medicines;
using Domain.Models;
using Infrastructure.Persistance.MSSqlServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application.Helper;

namespace Presentation.Controllers
{
    [Route("medicines")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineServices _medicineService;
        private readonly DbContextMSSqlServer _rrcon;

        public MedicineController(IMedicineServices medicineService, DbContextMSSqlServer dbContext)
        {
            _medicineService = medicineService;
            _rrcon = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMedicines([FromQuery] QueryObject query)
        {
            var allMedicines = await _medicineService.GetAllMedicinesAsync(query);
            return Ok(allMedicines);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicineById(int id)
        {
            var res = await _medicineService.GetMedicineByIdAsync(id);
            if (res == null)
            {
                return NotFound(new
                {
                    statusCode = 404,
                    message = "record not found"
                });
            }
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMedicine(MedicineReqDTO medicineReqDTO)
        {
            var createdMedicine = await _medicineService.CreateMedicineAsync(medicineReqDTO);
            if (createdMedicine == null)
            {
                return BadRequest("Entry already exists");
            }
            return CreatedAtAction(nameof(GetMedicineById), new { id = createdMedicine.Id }, createdMedicine);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicine(int id)
        {
            var res = await _medicineService.DeleteMedicineAsync(id);
            if (res)
                return NoContent();

            return NotFound(new
            {
                statusCode = 404,
                message = "record not found"
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMedicine(MedicineReqDTO medicineReqDTO)
        {
            var editedMedicine = await _medicineService.EditMedicineAsync(medicineReqDTO);
            if ((bool)editedMedicine)
                return NoContent();

            return NotFound(new
            {
                statusCode = 404,
                message = "record not found"
            });
        }
    }
}

