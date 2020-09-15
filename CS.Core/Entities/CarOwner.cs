using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Core.Entities
{
    public class CarOwner
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public virtual Car Car { get; set; }
        public int OwnerId { get; set; }
        public virtual Owner Owner { get; set; }
    }
}
