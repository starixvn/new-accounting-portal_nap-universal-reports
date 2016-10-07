using UniversalReports.NG2Statistic.BaseServices;

namespace UniversalReports.NG2Statistic.Daily
{
    public interface DailyService
    {
        DailyModel Query(QueryModel queryModel);

        DailyModel SortData(QueryModel queryModel);
    }
}