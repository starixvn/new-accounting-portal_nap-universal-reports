using UniversalReports.NG2Statistic.Common;

namespace UniversalReports.NG2Statistic.GrandTotal
{
    public interface GrandTotalService
    {
        GrandTotalModel Query(QueryModel queryModel);
    }
}