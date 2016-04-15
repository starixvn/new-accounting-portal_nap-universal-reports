using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.Common.ColumnBuilders
{
    public interface GridOptionBuilder
    {
        GridOptions BuildBasicGridOptions(GridOptions gridOptions, string mainColumnText, int mainColumnWidth = 200);

        GridOptions BuildExtraPTGridOptions(GridOptions gridOptions, string mainColumnText, int mainColumnWidth = 200);

        GridOptions BuildFullGridOptions(GridOptions gridOptions, string mainColumnText, int mainColumnWidth = 200);

        GridOptions BuildVirtualGridOptions(GridOptions gridOptions, string mainColumnText, int mainColumnWidth = 200);

        GridOptions BuildBasicMatchDetailOptions(GridOptions gridOptions);

        GridOptions BuildFullMatchDetailOptions(GridOptions gridOptions);
    }
}