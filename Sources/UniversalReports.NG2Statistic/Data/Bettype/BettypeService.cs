namespace UniversalReports.NG2Statistic.Data.Bettype
{
    public interface BettypeService
    {
        BettypeModel Query(QueryModel queryModel);

        BettypeModel SortData(QueryModel queryModel);
    }
}