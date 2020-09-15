using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Core.Entities
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Car> Cars { get; set; }
    }
}
