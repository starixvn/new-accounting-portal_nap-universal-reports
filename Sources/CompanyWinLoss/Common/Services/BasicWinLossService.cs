using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public interface BasicWinLossService
    {
        BasicWinLossModel Query(WinLossCriteria criteria);
    }
}