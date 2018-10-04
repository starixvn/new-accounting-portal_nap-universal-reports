using System;
using System.Collections.Generic;
using Linq.DynamicSum;
using MediatR;

namespace UniversalReports.PunterAnalysis.AssociatedAccount.Model
{
    public class HttpParameterJson : IRequest<SummaryEntity<AssociatedSummaryModel>>
    {
        public int CustId { get; set; }

        public string Username { get; set; }

        public int LeagueId { get; set; }

        public int OrderBy { get; set; }

        public int SortBy { get; set; }

        public int PeriodType { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string ListCombinationId { get; set; }
    }
}