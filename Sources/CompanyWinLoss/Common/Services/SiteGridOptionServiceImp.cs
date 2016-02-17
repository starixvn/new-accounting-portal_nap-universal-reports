using Fanex.Excel.Models;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public class SiteGridOptionServiceImp : SiteGridOptionService
    {
        private GridOptions gridOptions;

        public GridOptions FromSiteWinLoss(SiteWinLoss winLoss)
        {
            gridOptions = new GridOptions();

            BuildHeader();
            BuildBodyRows(winLoss);
            BuildFooter(winLoss);

            return gridOptions;
        }

        private void BuildHeader()
        {

        }

        private void BuildBodyRows(SiteWinLoss winLoss)
        {

        }

        private void BuildFooter(SiteWinLoss winLoss)
        {

        }

    }
}
