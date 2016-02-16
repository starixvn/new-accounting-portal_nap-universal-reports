(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .directive('napMain', napMain);

    function napMain() {
        var directive = {
            restrict: 'EA',
            scope: {},
            templateUrl: '/app/company-winloss/shared/fanex-grid-with-title.html',
            controller: controller
        };
        return directive;

        controller.$inject = ['$compile', '$timeout', '$element', '$scope', 'formatStrings', 'mainService', 'fanexGridHelper', 'levels', 'levelSettings', 'companyWinlossService'];
        function controller($compile, $timeout, $element, $scope, formatStrings, mainService, fanexGridHelper, levels, levelSettings, companyWinlossService) {
            var gridElement = $element.find('.freegrid');
            var dateRange;

            $scope.generateProduct = function (productName) {
                var level = levelSettings[productName].level;
                companyWinlossService.generate({
                    level: level,
                    productName: productName
                });
            };

            $scope.$on('generate', function (event, level) {
                if (level === levels.PRODUCT) {
                    $timeout(function () {
                        dateRange = companyWinlossService.filterModel.getDateRange();
                        generate(dateRange.startDate, dateRange.endDate);
                    });
                }
            });

            $scope.$on('show', function (event, level) {
                if (level === levels.PRODUCT) {
                    $timeout(function () {
                        companyWinlossService.filterModel.updateDateRange(dateRange);
                        gridElement.fanexGrid('resizeGrid');
                    });
                }
            });

            function generate(startDate, endDate) {
                mainService.getData(startDate, endDate).then(function (data) {
                    renderGrid(data);
                });
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
                        text: '<ol class="breadcrumb"><li class="active">PRODUCT WIN/LOSS REPORT</li></ol>',
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
                            return '<a class="drill-down" href data-ng-click="generateProduct(\'' + winLoss.Name + '\')">' + winLoss.Name + '</a>';
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
                return [
                    { Columns: createWinLossDataRow(grandTotal.Total, false, true) },
                    { Columns: createWinLossDataRow(grandTotal.Credit, false, true) },
                    { Columns: createWinLossDataRow(grandTotal.Deposit, false, true) }
                ];
            }

            function exportExcel() {

            }
        }
    }
})();