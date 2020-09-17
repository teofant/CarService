using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CS.Core.DTO.OwnerRepairs
{
    public class OwnerRepairCreateDTO
    {
        [Required]
        public int OwnerId { get; set; }
        [Required]
        public int RepairId { get; set; }
    }
}
