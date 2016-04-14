using UniversalReports.CompanyWinLoss.Common.MatchDetailServices;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Extensions
{
    public static class ExcelValueExtension
    {
        public static object ExcelRealMargin(this WinLoss item)
        {
            return item.RealTurnover == 0 ? "N/A" : (object)item.RealMargin;
        }

        public static object ExcelVirtualMargin(this WinLoss item)
        {
            return item.VirtualTurnover == 0 ? "N/A" : (object)item.VirtualMargin;
        }

        public static object ExcelRealMargin(this MatchDetailWinLoss item)
        {
            return item.RealTurnover == 0 ? "N/A" : (object)item.RealMargin;
        }

        public static object ExcelVirtualMargin(this MatchDetailWinLoss item)
        {
            return item.VirtualTurnover == 0 ? "N/A" : (object)item.VirtualMargin;
        }
    }
}
