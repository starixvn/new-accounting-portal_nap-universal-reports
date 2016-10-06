using UniversalReports.NG2Statistic.Common;

namespace UniversalReports.NG2Statistic.Bettype
{
    public interface BettypeService
    {
        BettypeModel Query(QueryModel queryModel);

        BettypeModel SortData(QueryModel queryModel);
    }
}