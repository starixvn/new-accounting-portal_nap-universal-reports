using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Linq;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.Extensions;
using UniversalReports.HouseWinLoss.Common.Models;
using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.Casino.Product
{
    public class CasinoProductGridOptionsBuilder : BasicGridOptionsBuilderImp
    {
        public CasinoProductGridOptionsBuilder(BasicGridDataRowBuilder gridDataRowBuilder)
            : base(gridDataRowBuilder)
        {
        }

        protected override GridDataRow BuildGroupDataRow(SiteWinLossSummary item, HAlignment alignment)
        {
            var gridDataRow = base.BuildGroupDataRow(item, alignment);
            DecorateExtraPT(gridDataRow, item);

            return gridDataRow;
        }

        private void DecorateExtraPT(GridDataRow gridDataRow, SiteWinLossSummary item)
        {
            var itemHasExtraPT = ItemHasExtraPT(item.Total);
            DecorateExtraPT(gridDataRow, item.Total, itemHasExtraPT);
            DecorateExtraPT(gridDataRow.SubRows[0], item.Credit, itemHasExtraPT);
            DecorateExtraPT(gridDataRow.SubRows[1], item.Deposit, itemHasExtraPT);
        }

        private void DecorateExtraPT(GridDataRow gridDataRow, WinLoss item, bool itemHasExtraPT)
        {
            gridDataRow.Columns.First(c => c.Name == "ExtraPT").Value = item.ExcelExtraPT(itemHasExtraPT);
        }

        private bool ItemHasExtraPT(WinLoss item)
        {
            return !Constants.CasinoProductsNonExtraPT.Contains(item.Name);
        }
    }
}
