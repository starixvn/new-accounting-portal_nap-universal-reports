using Fanex.Excel.Models;
using System.Collections.Generic;

namespace UniversalReports.HouseWinLoss.Common.ColumnDecorators
{
    public interface GridOptionColumnRemoval
    {
        List<Columns> RemoveColumn(List<Columns> columns, int index);
    }
}