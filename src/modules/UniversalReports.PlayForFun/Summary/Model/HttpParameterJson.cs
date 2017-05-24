using Linq.DynamicSum;
using MediatR;
using System;

namespace UniversalReports.PlayForFun.Summary.Model
{
    public class HttpParameterJson : IRequest<SummaryEntity<SummaryModel>>
    {
        public string Username { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int ProductId { get; set; }

        public int StatusId { get; set; }

        public bool ExcludeTest { get; set; }
    }
}