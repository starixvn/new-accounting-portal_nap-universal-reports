using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Models.Main;
using NAP.Reports.CompanyWinLoss.Services.Criteria;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public interface IProductWinLossService
    {
        MainWinLoss Query(WinLossCriteria criteria);

        List<WinLoss> CalculateSportsbookDetail(IEnumerable<RawWinLoss> rawWinLosses);
    }
}
