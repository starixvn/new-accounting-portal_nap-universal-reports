using UniversalReports.NG2Statistics.BaseServices;

namespace UniversalReports.NG2Statistics.Daily
{
    public interface DailyService
    {
        DailyModel Query(QueryModel queryModel);

        DailyModel SortData(DailyModel dataRaw, QueryModel queryModel);
    }
}