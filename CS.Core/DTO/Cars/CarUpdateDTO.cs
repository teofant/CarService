﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CS.Core.DTO.Cars
{
    public class CarUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateIssue { get; set; }
        [Required]
        [DisplayName("Owner")]
        public int OwnerId { get; set; }
        [Required]
        public int Mileage { get; set; }
        [Required]
        [DisplayName("Brand")]
        public int CarBrandId { get; set; }
        [Required]
        [DisplayName("Model")]
        public int CarModelId { get; set; }
    }
}
