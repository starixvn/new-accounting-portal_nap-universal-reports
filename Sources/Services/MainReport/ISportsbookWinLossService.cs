using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.QueryModels;
using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Services.MainReport
{
    public interface ISportsbookWinLossService
    {
        List<WinLoss> Query(MainReportQuery query);
    }
}
