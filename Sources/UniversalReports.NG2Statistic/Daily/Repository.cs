using UniversalReports.NG2Statistic.Common;

namespace UniversalReports.NG2Statistic.Daily
{
    public interface Repository
    {
        DailyModel Query(QueryModel queryModel);
    }
}