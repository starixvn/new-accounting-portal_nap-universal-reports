using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using UniversalReports.HouseWinLoss.Common.Models;

namespace UniversalReports.HouseWinLoss.Common.BasicWinLoss
{
    public interface BasicGridDataRowBuilder
    {
        GridDataRow BuildDataRow(WinLoss item, HAlignment mainTextAlignment);
    }
}