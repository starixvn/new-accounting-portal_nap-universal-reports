using MediatR;
using System;

namespace UniversalReports.PunterAnalysis.BetType.Model
{
    public class HttpParameterJson : IRequest<ViewModelJson>
    {
        public int PeriodType { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int CustId { get; set; }

        public string ListCombinationId { get; set; }

        public int SportId { get; set; }

        public int OrderBy { get; set; } = 1;

        public int SortBy { get; set; } = 1;
    }
}