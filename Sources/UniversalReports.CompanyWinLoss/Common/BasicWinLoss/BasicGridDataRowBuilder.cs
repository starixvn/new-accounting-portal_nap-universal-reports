using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.BasicWinLoss
{
    public interface BasicGridDataRowBuilder
    {
        GridDataRow BuildDataRow(WinLoss item, HAlignment mainTextAlignment, bool hasExtraPT = true);
    }
}
