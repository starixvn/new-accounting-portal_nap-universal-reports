using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fanex.Excel.Models;

namespace UniversalReports.NG2Statistic.Data
{
    public interface GridOptionHeaderColumn
    {
        GridOptions Build(GridOptions gridOptions, string mainColumnText, int mainColumnWidth = 180);
    }
}
