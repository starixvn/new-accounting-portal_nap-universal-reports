using MediatR;
using OfficeOpenXml;
using System;

namespace UniversalReports.PlayForFun.Detail.Model
{
    public class HttpParameterExcel : IRequest<ExcelPackage>
    {
        public int TopRow { get; set; }

        public int OrderBy { get; set; }

        public int SortBy { get; set; }

        public int PeriodType { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int Depth { get; set; }

        public string UserName { get; set; }

        public string ListCombinationId { get; set; }

        public string Title { get; set; }

        public string Filter { get; set; }
    }
}