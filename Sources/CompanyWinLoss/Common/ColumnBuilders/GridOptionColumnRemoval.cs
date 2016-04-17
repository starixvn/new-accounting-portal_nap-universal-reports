using Fanex.Excel.Models;
using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.Common.ColumnBuilders
{
    public interface GridOptionColumnRemoval
    {
        List<Columns> RemoveColumn(List<Columns> columns, int index);
    }
}