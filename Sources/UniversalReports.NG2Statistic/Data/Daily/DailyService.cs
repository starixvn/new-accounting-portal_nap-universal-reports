using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalReports.NG2Statistic.Data.Daily
{
    public interface DailyService
    {
        DailyModel Query(DailyCriteria criteria);
    }
}
