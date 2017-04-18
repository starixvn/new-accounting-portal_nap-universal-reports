using MediatR;
using OfficeOpenXml;
using System;

namespace UniversalReports.PlayForFun.Summary.Model
{
    public class HttpParameterExcel : IRequest<ExcelPackage>
    {
        public string Username { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int ProductId { get; set; }

        public int StatusId { get; set; }

        public bool ExcludeTest { get; set; }

        public string Title { get; set; }

        public string ProductName { get; set; }
    }
}