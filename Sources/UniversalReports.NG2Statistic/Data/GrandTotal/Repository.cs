namespace UniversalReports.NG2Statistic.Data.GrandTotal
{
    public interface Repository
    {
        GrandTotalModel Query(QueryModel queryModel);
    }
}