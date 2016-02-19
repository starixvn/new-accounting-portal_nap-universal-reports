(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('ProductController', ProductController);

    ProductController.$inject = ['$compile', '$timeout', '$element', '$scope', 'formatStrings', 'productService', 'fanexGridHelper', 'levels', 'levelSettings', 'companyWinlossService', 'breadcrumbHelper'];
    function ProductController($compile, $timeout, $element, $scope, formatStrings, productService, fanexGridHelper, levels, levelSettings, companyWinlossService, breadcrumbHelper) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateProduct = generateProduct;

        function generateProduct(productName) {
            var templates = levelSettings[productName].templates;
            var firstTemplate = templates[0];
            companyWinlossService.generate({
                level: firstTemplate.level,
                productName: productName
            });
        };

        function generate() {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            productService.getData(dateRange.startDate, dateRange.endDate).then(function (data) {
                renderGrid(data);
            });
        }

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function renderGrid(data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
            var elements = gridElement.find('.drill-down');
            $compile(elements)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Product", Width: 150, Name: "Product", HeaderAlign: "center", CellAlign: "left", ShowCollapseExpand: true },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Real", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Virtual", Width: 120, Name: "VirtualIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Variance", Width: 120, Name: "Variance", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
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
                    text: breadcrumbHelper.generateHtml($scope, false),
                    showCollapseExpandButton: true,
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                showHighlightRow: false,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
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
                var isSportsBook = i === 0;
                bodyData.push(createProductWinLossDataRow(productItem, isSportsBook));
            }

            return bodyData;
        }

        function createProductWinLossDataRow(productWinLossItem, isSportsBook) {
            var rowCssClass = isSportsBook ? 'sports-book-row' : '';
            return {
                Columns: createWinLossDataRow(productWinLossItem.Total, !isSportsBook),
                SubRows: [
                    { Columns: createWinLossDataRow(productWinLossItem.Credit, false, true), CssClass: rowCssClass },
                    { Columns: createWinLossDataRow(productWinLossItem.Deposit, false, true), CssClass: rowCssClass }
                ],
                CssClass: rowCssClass
            };
        }

        function createWinLossDataRow(winLoss, hasProductDrillDown, isTextRight) {
            var productColumn = !hasProductDrillDown
                ? { Name: "Product", Value: winLoss.Name }
                : {
                    Name: "Product", Value: winLoss.Name, CustomCellRender: function (cellValue) {
                        return '<a class="drill-down" href data-nap-click="generateProduct(\'' + winLoss.Name + '\')">' + winLoss.Name + '</a>';
                    }
                };
            if (isTextRight) {
                productColumn.CellAlign = 'right';
            }
            return [
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
        }

        function createFooterData(data) {
            var grandTotal = data.GrandTotal;
            var reportNote = "* Sportsbook Total: Sportsbook Live + Sportsbook Non-Live + Parlay + Outright" +
                             "<br/>* Grand Total: Sportsbook Total + Number Game + Live Casino + Casino + Virtual Sports + Keno + Racing +  Bingo + Bettrade + Colossus Bets";
            return [
                { Columns: createWinLossDataRow(grandTotal.Total, false, true) },
                { Columns: createWinLossDataRow(grandTotal.Credit, false, true) },
                { Columns: createWinLossDataRow(grandTotal.Deposit, false, true) },
                {
                    Columns: [{
                        Name: "Product",
                        Value: reportNote,
                        MergeColNumber: 11,
                        CellAlign: "left",
                        TdClass: "grand-total-note"
                    }]
                }
            ];
        }

        function exportExcel() {
        }
    }
})();