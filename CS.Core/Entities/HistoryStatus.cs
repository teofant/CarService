using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Core.Entities
{
    public class HistoryStatus
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }
        public int RepairId { get; set; }
        public virtual Repair Repair { get; set; }
        public int RepairStatusId { get; set; }
        public virtual RepairStatus RepairStatus { get; set; }
    }
}
