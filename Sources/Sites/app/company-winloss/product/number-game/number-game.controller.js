(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('NumberGameController', NumberGameController);

    NumberGameController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'dataService', 'fanexGridHelper', 'levels', 'companyWinlossService'];
    function NumberGameController($compile, $scope, $element, formatStrings, dataService, fanexGridHelper, levels, companyWinlossService) {
        $scope.generate = generate;
        $scope.drillUpMain = function () {
            companyWinlossService.generateMain();
        };

        function generate(startDate, endDate) {
            dataService.getData(startDate, endDate).then(function (data) {
                renderGrid(data);
            });
        }

        function renderGrid(data) {
            var gridElement = $element.find('.freegrid');
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
            var elements = gridElement.find('.product-drilldown');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Product", Width: 150, Name: "Product", HeaderAlign: "center", CellAlign: "left", ShowCollapseExpand: true },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Real", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Virtual", Width: 120, Name: "VirtualIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Variance", Width: 120, Name: "Variance", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Real", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Virtual", Width: 120, Name: "VirtualTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Real", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER },
                 { HeaderText: "Virtual", Width: 120, Name: "VirtualMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var groupHeaderRowsColumns = [
                { HeaderText: "Product", Name: "Product", MergeRowNumber: 2 },
                { HeaderText: "Member Win Loss", Name: "MemberWinLoss", MergeRowNumber: 2 },
                { HeaderText: "SMA Win Loss", Name: "SMAWinLoss", MergeRowNumber: 2 },
                { HeaderText: "Commission", Name: "Commission", MergeRowNumber: 2 },
                { HeaderText: "Company Income", Name: "RealIncome", MergeColNumber: 2 },
                { HeaderText: "Variance", Name: "Variance", MergeRowNumber: 2 },
                { HeaderText: "Company Turnover", Name: "RealTurnover", MergeColNumber: 2 },
                { HeaderText: "Margin", Name: "RealMargin", MergeColNumber: 2 }
            ];

            var gridOptions = {
                customizeHeader: true,
                groupHeaderRows: [
                    { Columns: groupHeaderRowsColumns }
                ],
                columns: columns,
                bodyRows: createBodyData(data),
                showTree: true,
                defaultCollapseAllGroups: true,
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="drillUpMain()">MAIN</a></li><li class="active">NUMBER GAME "NON - LIVE" PRODUCT WIN/LOSS REPORT</li></ol>',
                    showCollapseExpandButton: true,
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var sportsbookDetail = data.SportsbookDetail;
            for (var i = 0; i < sportsbookDetail.length; i++) {
                var sportsbookItem = sportsbookDetail[i];
                bodyData.push({
                    Columns: createWinLossDataRow(sportsbookItem)
                });
            }

            var products = data.Products;
            for (var i = 0; i < products.length; i++) {
                var productItem = products[i];
                var isHighlight = i === 0;
                bodyData.push(createProductWinLossDataRow(productItem, isHighlight));
            }

            return bodyData;
        }

        function createWinLossDataRow(winLoss, hasDrilldown) {
            var productColumn = !hasDrilldown
                ? { Name: "Product", Value: winLoss.Name }
                : {
                    Name: "Product", Value: winLoss.Name, CustomCellRender: function (cellValue) {
                        return '<a class="product-drilldown" href data-ng-click="drillDownProduct(\'' + winLoss.Name + '\')">' + winLoss.Name + '</a>';
                    }
                };
            var winLossDataRow = [
                productColumn,
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "VirtualIncome", Value: winLoss.VirtualIncome },
                { Name: "Variance", Value: winLoss.VarianceIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "VirtualTurnover", Value: winLoss.VirtualTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin },
                { Name: "VirtualMargin", Value: winLoss.VirtualMargin }
            ];

            return winLossDataRow;
        }

        function createProductWinLossDataRow(productWinLossItem, isHighlight) {
            var productDataRow = {
                Columns: createWinLossDataRow(productWinLossItem.Total, !isHighlight),
                SubRows: [],
                CssClass: isHighlight ? 'highlight-product' : ''
            };

            productDataRow.SubRows.push({
                Columns: createWinLossDataRow(productWinLossItem.Credit), CssClass: isHighlight ? 'highlight-product' : 'align-right'
            });
            productDataRow.SubRows.push({
                Columns: createWinLossDataRow(productWinLossItem.Deposit), CssClass: isHighlight ? 'highlight-product' : 'align-right'
            });

            return productDataRow;
        }

        function createFooterData(data) {
            var footerRow = [];
            var grandTotal = data.GrandTotal;
            footerRow.push({ Columns: createWinLossDataRow(grandTotal.Total) });
            footerRow.push({ Columns: createWinLossDataRow(grandTotal.Credit) });
            footerRow.push({ Columns: createWinLossDataRow(grandTotal.Deposit) });

            return footerRow;
        }

        function exportExcel() {

        }
    }
})();