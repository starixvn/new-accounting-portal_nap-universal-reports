namespace UniversalReports.NG2Statistic.Data.Daily
{
    public interface DailyService
    {
        DailyRaw Query(QueryModel queryModel);

        DailyRaw SortData(QueryModel queryModel);
    }
}