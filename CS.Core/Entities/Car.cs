using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Core.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public DateTime DateIssue { get; set; }
        public int Mileage { get; set; }

        public virtual List<Owner> Owners { get; set; }

        public int CarBrandId { get; set; }
        public virtual CarBrand CarBrand { get; set; }

        public int CarModelId { get; set; }
        public virtual CarModel CarModel { get; set; }
    }
}
