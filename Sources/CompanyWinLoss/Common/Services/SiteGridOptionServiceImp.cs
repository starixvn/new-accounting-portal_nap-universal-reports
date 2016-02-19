using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public class SiteGridOptionServiceImp : SiteGridOptionService
    {
        public GridOptions FromWinLossModel(SiteWinLossModel winLoss, string site, string breadCrumb)
        {
            return new GridOptions
            {
                CustomizeHeader = true,
                ShowTitle = true,
                TitleInfoText = breadCrumb,
                TitleType = TitleType.TwoLineBlue,
                Columns = BuildHeader(site),
                GroupHeaderRows = BuildGroupHeaderRows(),
                BodyRows = BuildBodyRows(winLoss.Sites),
                FooterRows = BuildFooter(winLoss.Total),
                ShowFooter = true
            };
        }

        [SuppressMessage("StyleCop.CSharp.Nexcel.NexcelCustomRules",
          "SP2100:CodeLineMustNotBeLongerThan",
          Justification = "Reviewed. Suppression is OK here.")]
        private List<HeaderColumns> BuildHeader(string site)
        {
            var header = new List<HeaderColumns>();
            header.AddRange(
                new List<HeaderColumns>
                {
                    new HeaderColumns { HeaderText = site, Width = 150, Name = "Site", HeaderAlign = "center", CellAlignment = HAlignment.Center },
                    new HeaderColumns { HeaderText = "Member Win Loss", Width = 120, Name = "MemberWinLoss", HeaderAlign = "center", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                    new HeaderColumns { HeaderText = "SMA Win Loss", Width = 120, Name = "SMAWinLoss", HeaderAlign = "center", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                    new HeaderColumns { HeaderText = "Commission", Width = 120, Name = "Commission", HeaderAlign = "center", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                    new HeaderColumns { HeaderText = "Company Income", Width = 120, Name = "RealIncome", HeaderAlign = "center", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                    new HeaderColumns { HeaderText = "Company Turnover", Width = 120, Name = "RealTurnover", HeaderAlign = "center", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                    new HeaderColumns { HeaderText = "Margin", Width = 120, Name = "Margin", HeaderAlign = "center", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.PercentageRedPositive }
                });

            return header;
        }

        private List<GroupHeaderRows> BuildGroupHeaderRows()
        {
            List<GroupHeaderRows> groupHeaderRows = new List<GroupHeaderRows>();

            var groupHeader = new GroupHeaderRows();
            groupHeader.Columns.AddRange(
                new List<HeaderColumns>
                {
                    new HeaderColumns { HeaderText = "Site", Name = "Site", Width = 150 },
                    new HeaderColumns { HeaderText = "Member Win Loss", Name = "MemberWinLoss", MergeRowNumber = 2, Width = 120 },
                    new HeaderColumns { HeaderText = "SMA Win Loss", Name = "SMAWinLoss", MergeRowNumber = 2, Width = 120 },
                    new HeaderColumns { HeaderText = "Commission", Name = "Commission", MergeRowNumber = 2, Width = 120 },
                    new HeaderColumns { HeaderText = "Company Income", Name = "RealIncome", MergeRowNumber = 2, Width = 120 },
                    new HeaderColumns { HeaderText = "Company Turnover", Name = "RealTurnover", MergeRowNumber = 2, Width = 120 },
                    new HeaderColumns { HeaderText = "Margin", Name = "Margin", MergeRowNumber = 2, Width = 120 }
                });

            groupHeaderRows.Add(groupHeader);
            return groupHeaderRows;
        }

        private List<GridDataRow> BuildBodyRows(List<WinLoss> winLoss)
        {
            var bodyRows = new List<GridDataRow>();
            foreach (var item in winLoss)
            {
                var row = BuildDataRow(item, HAlignment.Center);
                bodyRows.Add(row);
            }

            return bodyRows;
        }

        private List<GridDataRow> BuildFooter(WinLoss item)
        {
            var footerRow = new List<GridDataRow>();
            footerRow.Add(BuildDataRow(item, HAlignment.Right));
            return footerRow;
        }

        private GridDataRow BuildDataRow(WinLoss item, HAlignment alignment)
        {
            var row = new GridDataRow();
            row.Columns = BuildWinLossRow(item, alignment);
            return row;
        }

        private List<Columns> BuildWinLossRow(WinLoss item, HAlignment alignment)
        {
            int columnIndex = 0;
            var columns = new List<Columns>();
            columns.AddRange(
               new List<Columns>
               {
                    new Columns(columnIndex++, "Site", item.Name, alignment),
                    new Columns(columnIndex++, "MemberWinLoss", item.MemberWinLoss),
                    new Columns(columnIndex++, "SMAWinLoss", item.SMAWinLoss),
                    new Columns(columnIndex++, "Commission", item.Commission),
                    new Columns(columnIndex++, "RealIncome", item.RealIncome),
                    new Columns(columnIndex++, "RealTurnover", item.RealTurnover),
                    new Columns(columnIndex++, "Margin", item.RealTurnover == 0 ? "N/A" : (object)item.RealMargin)
               });

            return columns;
        }
    }
}
