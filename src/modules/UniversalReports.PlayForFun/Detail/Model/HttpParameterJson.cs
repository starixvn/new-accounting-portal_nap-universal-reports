using MediatR;
using System;
using UniversalReports.PlayForFun.Core;

namespace UniversalReports.PlayForFun.Detail.Model
{
    public class HttpParameterJson : IRequest<ReportModelBase<DetailModel>>
    {
        public string Username { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int ProductId { get; set; }

        public int StatusId { get; set; }

        public bool ExcludeTest { get; set; }
    }
}