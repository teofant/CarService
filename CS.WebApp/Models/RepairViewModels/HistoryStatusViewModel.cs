using CS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS.WebApp.Models.RepairViewModels
{
    public class HistoryStatusViewModel
    {
        public HistoryStatusViewModel(Repair repair, IEnumerable<HistoryStatus> historyStatuses)
        {
            Repair = repair;
            HistoryStatus = historyStatuses;
        }

        public HistoryStatusViewModel() { }

        public Repair Repair { get; set; }
        public IEnumerable<HistoryStatus> HistoryStatus { get; set; }
    }
}
