using UniversalReports.Core.SortUtility;
using UniversalReports.NG2Statistic.BaseServices;

namespace UniversalReports.NG2Statistic.Bettype
{
    public class SortingServiceImp : SortingService
    {
        public void SortingData(BettypeModel bettypeModel, QueryModel queryModel)
        {
            foreach (var sporttype in bettypeModel.Rows)
            {
                foreach (var bettype in sporttype.Rows)
                {
                    Sort.SortDataByProperty(bettype.Rows, queryModel.SortDirection, queryModel.SortColumnName);
                }

                Sort.SortDataByProperty(sporttype.Rows, queryModel.SortDirection, queryModel.SortColumnName);
            }
        }
    }
}