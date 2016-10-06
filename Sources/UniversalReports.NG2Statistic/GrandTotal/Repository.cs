using UniversalReports.NG2Statistic.Common;

namespace UniversalReports.NG2Statistic.GrandTotal
{
    public interface Repository
    {
        GrandTotalModel Query(QueryModel queryModel);
    }
}