using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CS.Core.DTO.CarModels
{
    public class CarModelCreateDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
