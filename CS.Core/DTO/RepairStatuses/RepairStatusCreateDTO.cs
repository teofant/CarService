using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CS.Core.DTO.RepairStatuses
{
    public class RepairStatusCreateDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
