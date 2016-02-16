(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('KenoBetTypeController', KenoBetTypeController);

    KenoBetTypeController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'kenoService'];
    function KenoBetTypeController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, kenoService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateProduct = generateProduct;
        $scope.generateSite = generateSite;

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };
        
        function generateSite(betType, site) {
            companyWinlossService.generate({
                level: levels.SITE,
                betType: betType,
                site: site
            });
        };

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function generate(startDate, endDate) {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            kenoService.getBetType(dateRange.startDate, dateRange.endDate).then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Bet Type", Width: 150, Name: "Name", HeaderAlign: "center", CellAlign: "left", ShowCollapseExpand: true },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                columns: columns,
                bodyRows: createBodyData(data),
                showTree: true,
                defaultCollapseAllGroups: true,
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li class="active">' + gridModel.productName + '</li></ol>',
                    showCollapseExpandButton: true,
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var bettypes = data.BetTypes;
            for (var i = 0; i < bettypes.length; i++) {
                var bettypeItem = bettypes[i];
                bodyData.push(createBetTypeWinLossDataRow(bettypeItem));
            }

            return bodyData;
        }

        function createBetTypeWinLossDataRow(bettypeItem) {
            return {
                Columns: createWinLossDataRow(bettypeItem.Total, true),
                SubRows: [
                    { Columns: createWinLossDataRow(bettypeItem.Credit, false) },
                    { Columns: createWinLossDataRow(bettypeItem.Deposit, false) }
                ]
            };
        }

        function createWinLossDataRow(winLoss, isTotal) {
            var betTypeColumn = isTotal ? createBetTypeTotalColumn(winLoss) : createBetTypeSiteColumn(winLoss);
            var remainColumn = createColumnWithoutBetType(winLoss);
            return betTypeColumn.concat(remainColumn);
        }
        
        function createBetTypeTotalColumn(winLoss) {
            return [{
                Name: "Name",
                Value: winLoss.Name,
            }];
        }

        function createBetTypeSiteColumn(winLoss) {
            return [{
                Name: "Name",
                Value: winLoss.Name,
                CellAlign: 'right',
                CustomCellRender: function (cellValue) {
                    return '<a class="drill-down" href data-ng-click="generateSite(' + winLoss.Id + ',\'' + winLoss.Name + '\')">' + winLoss.Name + '</a>';
                }
            }];
        }

        function createColumnWithoutBetType(winLoss) {
            return [
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin }
            ];
        }

        function createFooterData(data) {
            var grandTotal = data.GrandTotal;
            return [
                { Columns: createGrandTotalColumn(grandTotal.Total) },
                { Columns: createGrandTotalColumn(grandTotal.Credit) },
                { Columns: createGrandTotalColumn(grandTotal.Deposit) }
            ];
        }

        function createGrandTotalColumn(winLoss) {
            var betTypeColumn = [{
                Name: "Name",
                Value: winLoss.Name,
                CellAlign: 'right',
            }];
            var remainColumn = createColumnWithoutBetType(winLoss);
            return betTypeColumn.concat(remainColumn);
        }

        function exportExcel() {

        }
    }
})();