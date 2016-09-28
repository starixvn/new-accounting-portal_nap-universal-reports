using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fanex.Excel.Models;

namespace UniversalReports.NG2Statistic.Data.Daily
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(DailyModel dailyModel, string title);
    }
}
