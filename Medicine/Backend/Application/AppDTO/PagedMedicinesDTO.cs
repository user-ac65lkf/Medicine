using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppDTO
{
    public class PagedMedicinesDTO
    {
        public List<MedicineDTO> PagedMedicines { get; set; } = [];

        public decimal TotalPages { get; set; }
        public decimal CurrentPage { get; set;}
    }
}
