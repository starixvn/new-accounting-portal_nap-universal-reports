using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace UniversalReports.CompanyWinLoss.Common.ColumnBuilders
{
    public static class BasicHeaderBuilder
    {
        [SuppressMessage("StyleCop.CSharp.Nexcel.NexcelCustomRules",
            "SP2100:CodeLineMustNotBeLongerThan",
            Justification = "Reviewed. Suppression is OK here.")]
        public static List<HeaderColumns> BuildColumns(string mainColumnText, int mainColumnWidth = 200)
        {
            return new List<HeaderColumns>
            {
                new HeaderColumns { HeaderText = mainColumnText, Width = mainColumnWidth, Name = "Main", CellAlignment = HAlignment.Center, ShowCollapseExpand = true },
                new HeaderColumns { HeaderText = "Member Win Loss", Width = 120, Name = "MemberWinLoss", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "SMA Win Loss", Width = 120, Name = "SMAWinLoss", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Commission", Width = 120, Name = "Commission", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Company Income", Width = 120, Name = "RealIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "Company Turnover", Width = 120, Name = "RealTurnover", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Margin", Width = 120, Name = "RealMargin", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.PercentageRedPositive },
            };
        }

        public static List<GroupHeaderRows> BuildGroupHeaderRows(string mainColumnText, int mainColumnWidth = 200)
        {
            var columns = new List<HeaderColumns>
            {
                new HeaderColumns { HeaderText = mainColumnText, Name = "Main", Width = mainColumnWidth },
                new HeaderColumns { HeaderText = "Member Win Loss", Name = "MemberWinLoss", Width = 120 },
                new HeaderColumns { HeaderText = "SMA Win Loss", Name = "SMAWinLoss", Width = 120 },
                new HeaderColumns { HeaderText = "Commission", Name = "Commission", Width = 120 },
                new HeaderColumns { HeaderText = "Company Income", Name = "RealIncome", Width = 120 },
                new HeaderColumns { HeaderText = "Company Turnover", Name = "RealTurnover", Width = 120 },
                new HeaderColumns { HeaderText = "Margin", Name = "RealMargin", Width = 120 }
            };

            var groupHeader = new GroupHeaderRows { Columns = columns };
            return new List<GroupHeaderRows> { groupHeader };
        }
    }
}
