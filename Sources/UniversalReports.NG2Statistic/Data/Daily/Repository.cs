namespace UniversalReports.NG2Statistic.Data.Daily
{
    public interface Repository
    {
        DailyModel Query(QueryModel queryModel);
    }
}