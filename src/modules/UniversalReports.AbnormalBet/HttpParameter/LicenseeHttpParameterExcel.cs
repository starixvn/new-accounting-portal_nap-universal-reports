using MediatR;
using OfficeOpenXml;
using System;

namespace UniversalReports.AbnormalBet.HttpParameter
{
    public class LicenseeHttpParameterExcel : IRequest<ExcelPackage>
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int Reason { get; set; }

        public int Sport { get; set; }

        public int BetType { get; set; }

        public int Licensee { get; set; }

        public bool IsTest { get; set; }

        public string Title { get; set; }
    }
}
