using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Models.Main;
using NAP.Reports.CompanyWinLoss.Services.Criteria;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public interface IProductService
    {
        MainWinLoss Query(WinLossCriteria criteria);

        MainWinLoss CalculateMainWinLoss(IEnumerable<RawWinLoss> rawWinLosses);

        List<WinLoss> CalculateSportsbookDetail(IEnumerable<RawWinLoss> rawWinLosses);
    }
}
