(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('LiveCasinoBetTypeController', LiveCasinoBetTypeController);

    LiveCasinoBetTypeController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'liveCasinoService'];
    function LiveCasinoBetTypeController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, liveCasinoService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateMain = function () {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };
        $scope.generateThirdPartyProduct = function () {
            companyWinlossService.generate({
                level: levels.THIRD_PARTY_PRODUCT
            });
        };
        $scope.generateSite = function (betType, betTypeName, site) {
            companyWinlossService.generate({
                level: levels.SITE,
                betType: betType,
                betTypeName: betTypeName,
                site: site
            });
        }

        function generate() {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            liveCasinoService.getBetType(dateRange.startDate, dateRange.endDate, gridModel.thirdPartyProductId).then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function show() {
            gridElement.fanexGrid('resizeGrid');
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
                     { HeaderText: "Bet Type", Width: 150, Name: "BetType", HeaderAlign: "center", CellAlign: "left", ShowCollapseExpand: true },
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
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateMain()">MAIN</a></li><li><a href data-ng-click="generateThirdPartyProduct()">' + gridModel.productName + '</a></li><li class="active">' + gridModel.thirdPartyProductName + ' Product Win/Loss Report</li></ol>',
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
            var betTypes = data.BetTypes;
            for (var i = 0; i < betTypes.length; i++) {
                var betType = betTypes[i];
                bodyData.push(createBetTypeWinLossDataRow(betType));
            }

            return bodyData;
        }

        function createBetTypeWinLossDataRow(betType) {
            return {
                Columns: createWinLossDataRow(betType.Total, true, false, betType.Total.Name),
                SubRows: [
                    { Columns: createWinLossDataRow(betType.Credit, false, true, betType.Total.Name) },
                    { Columns: createWinLossDataRow(betType.Deposit, false, true, betType.Total.Name) }
                ]
            };
        }

        function createWinLossDataRow(winLoss, isTotal, isTextRight, betTypeName) {
            var betTypeColumn = isTotal
                ? { Name: "BetType", Value: winLoss.Name }
                : {
                    Name: "BetType", Value: winLoss.Name, CustomCellRender: function (cellValue) {
                        return '<a class="drill-down" href data-ng-click="generateSite(' + winLoss.Id + ',\'' + betTypeName + '\',\'' + winLoss.Name + '\')">' + winLoss.Name + '</a>';
                    }
                };

            if (isTextRight) {
                betTypeColumn.CellAlign = 'right';
            }

            return [
                betTypeColumn,
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
                { Columns: createWinLossDataRow(grandTotal.Total, true, true, grandTotal.Total.Name) },
                { Columns: createWinLossDataRow(grandTotal.Credit, true, true, grandTotal.Credit.Name) },
                { Columns: createWinLossDataRow(grandTotal.Deposit, true, true, grandTotal.Deposit.Name) }
            ];
        }

        function exportExcel() {

        }
    }
})();