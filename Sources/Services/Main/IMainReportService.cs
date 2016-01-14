using NAP.Reports.CompanyWinLoss.Models.Main;
using NAP.Reports.CompanyWinLoss.QueryModels.Main;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Services.Main
{
    public interface IMainService
    {
        MainWinLoss Query(MainQuery query);

        ProductWinLoss CalculateGrandTotal(IEnumerable<RawWinLoss> rawWinLosses);

        MainWinLoss CalculateMainWinLoss(IEnumerable<RawWinLoss> rawWinLosses);

        IEnumerable<ProductWinLoss> CalculateProductWinLoss(IEnumerable<RawWinLoss> rawWinLosses);

        List<WinLoss> CalculateSportsbookDetail(IEnumerable<RawWinLoss> rawWinLosses);
    }
}
