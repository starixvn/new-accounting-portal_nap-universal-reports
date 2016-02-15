using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public interface SportTypeService
    {
        SportTypeWinLossModel Query(WinLossCriteria criteria);
    }
}