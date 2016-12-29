using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using UniversalReports.HouseWinLoss.Common.Extensions;
using UniversalReports.HouseWinLoss.Common.Models;

namespace UniversalReports.HouseWinLoss.Common.BasicWinLoss
{
    public class BasicGridDataRowBuilderImp : BasicGridDataRowBuilder
    {
        [SuppressMessage("StyleCop.CSharp.StylecopPlus.Rules",
        "SP2100:CodeLineMustNotBeLongerThan",
        Justification = "Reviewed. Suppression is OK here.")]
        public GridDataRow BuildDataRow(WinLoss item, HAlignment mainTextAlignment)
        {
            var columnIndex = 0;
            var customAttributes = $"{item.Id}";
            var columns = new List<Columns>
            {
                new Columns { ColumnIndex = columnIndex++, Name = "Main", Value = string.IsNullOrEmpty(item.Name) ? string.Empty : item.Name, DisplayValue = item.Name, CustomAttributes = customAttributes, CellAlignment = mainTextAlignment },
                new Columns(columnIndex++, "MemberWinLoss", item.MemberWinLoss),
                new Columns(columnIndex++, "SMAWinLoss", item.SMAWinLoss),
                new Columns(columnIndex++, "Commission", item.Commission),
                new Columns(columnIndex++, "VarianceIncome", item.VarianceIncome),
                new Columns(columnIndex++, "VirtualIncome", item.VirtualIncome),
                new Columns(columnIndex++, "RealIncome", item.RealIncome),
                new Columns(columnIndex++, "ExtraPT", item.ExtraPT),
                new Columns(columnIndex++, "AfterExtraPT", item.AfterExtraPT),
                new Columns(columnIndex++, "VirtualTurnover", item.VirtualTurnover),
                new Columns(columnIndex++, "RealTurnover", item.RealTurnover),
                new Columns(columnIndex++, "VirtualMargin", item.ExcelVirtualMargin()),
                new Columns(columnIndex, "RealMargin", item.ExcelRealMargin())
            };

            return new GridDataRow { Columns = columns };
        }
    }
}