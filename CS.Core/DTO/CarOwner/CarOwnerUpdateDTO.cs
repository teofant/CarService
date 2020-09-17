using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CS.Core.DTO.CarOwner
{
    public class CarOwnerUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int CarId { get; set; }
        [Required]
        public int OwnerId { get; set; }
    }
}
