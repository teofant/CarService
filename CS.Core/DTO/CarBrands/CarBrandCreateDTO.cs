using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CS.Core.DTO.CarBrands
{
    public class CarBrandCreateDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
