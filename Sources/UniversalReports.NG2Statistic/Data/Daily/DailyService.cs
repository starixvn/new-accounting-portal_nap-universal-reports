namespace UniversalReports.NG2Statistic.Data.Daily
{
    public interface DailyService
    {
        DailyModel Query(QueryModel queryModel);

        DailyModel SortData(QueryModel queryModel);
    }
}