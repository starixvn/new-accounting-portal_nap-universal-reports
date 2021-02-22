using MediatR;
using System.Collections.Generic;

namespace UniversalReports.SBCustomerPerformanceByDanger.Filter
{
    public class LeagueGroupQueryHttpParameter : IRequest<IEnumerable<LeagueGroupModel>>
    {
        public string SportBettype { get; set; }
    }
}