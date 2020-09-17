using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CS.Core.DTO.Repairs
{
    public class RepairUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Сause { get; set; }
        [Required]
        public string Result { get; set; }
        [Required]
        public int OwnerId { get; set; }
        [Required]
        public int MasterId { get; set; }
        [Required]
        public int RepairStatusId { get; set; }
    }
}
