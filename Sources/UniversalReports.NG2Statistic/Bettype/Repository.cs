using UniversalReports.NG2Statistic.Common;

namespace UniversalReports.NG2Statistic.Bettype
{
    public interface Repository
    {
        BettypeModel Query(QueryModel queryModel);
    }
}