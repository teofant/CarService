using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Core.Entities
{
    public class Repair
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Сause { get; set; }
        public string Result { get; set; }

        public int OwnerId { get; set; }
        public virtual Owner Owner { get; set; }
        public int MasterId { get; set; }
        public virtual Master Master { get; set; }
        public int RepairStatusId { get; set; }
        public virtual RepairStatus RepairStatus { get; set; }
    }
}
