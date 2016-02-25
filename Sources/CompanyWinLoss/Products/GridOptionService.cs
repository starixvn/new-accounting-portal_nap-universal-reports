using Fanex.Excel.Models;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Products
{
    public interface GridOptionService
    {
        GridOptions FromWinLossModel(ProductWinLoss winLoss);
    }
}