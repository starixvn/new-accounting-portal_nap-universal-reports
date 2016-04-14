using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.Common.ColumnBuilders
{
    public interface GridOptionBuilder
    {
        GridOptions BuildBasicGridOptions(GridOptions gridOptions, string mainColumnText);

        GridOptions BuildExtraPTGridOptions(GridOptions gridOptions, string mainColumnText);

        GridOptions BuildFullGridOptions(GridOptions gridOptions, string mainColumnText);

        GridOptions BuildVirtualGridOptions(GridOptions gridOptions, string mainColumnText);

        GridOptions BuildBasicMatchDetailOptions(GridOptions gridOptions);

        GridOptions BuildFullMatchDetailOptions(GridOptions gridOptions);
    }
}