using System;
using MediatR;
using OfficeOpenXml;

namespace UniversalReports.Exchange.Report
{
    public class HttpParameterExcel : IRequest<ExcelPackage>
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string LicenseeId { get; set; }

        public string SportType { get; set; }
    }
}
