using System.Collections.Generic;
using Fanex.Excel.Models;

namespace UniversalReports.HouseWinLoss.Common.ColumnDecorators
{
    public interface GridOptionColumnRemoval
    {
        List<Columns> RemoveColumn(List<Columns> columns, int index);
    }
}