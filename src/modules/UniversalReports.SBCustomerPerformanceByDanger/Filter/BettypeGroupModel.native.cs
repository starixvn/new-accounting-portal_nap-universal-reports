using System.Collections.Generic;

namespace UniversalReports.SBCustomerPerformanceByDanger.Filter
{
    public class BettypeGroupModel
    {
        public string BettypeGroupName { get; set; }

        public List<BettypeModel> Bettypes { get; set; }
    }
}