using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CS.Core.DTO.CarOwner
{
    public class CarOwnerCreateDTO
    {
        [Required]
        public int CarId { get; set; }
        [Required]
        public int OwnerId { get; set; }
    }
}
