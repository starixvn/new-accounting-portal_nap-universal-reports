(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('VirtualSportsBetTypeController', VirtualSportsBetTypeController);

    VirtualSportsBetTypeController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'sites', 'companyWinlossService', 'virtualSportsService'];
    function VirtualSportsBetTypeController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, sites, companyWinlossService, virtualSportsService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateProduct = function () {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };
        $scope.generateSportType = function () {
            companyWinlossService.generate({
                level: levels.SPORT_TYPE
            });
        };
        $scope.generateDetail = function (betType, betTypeName) {
            companyWinlossService.generate({
                level: levels.DETAIL,
                betType: betType,
                betTypeName: betTypeName
            });
        };
        $scope.generateCreditSite = function (betType, betTypeName) {
            generateSite(betType, betTypeName, sites.CREDIT);
        };
        $scope.generateDepositSite = function (betType, betTypeName) {
            generateSite(betType, betTypeName, sites.DEPOSIT);
        };

        function generateSite(betType, betTypeName, site) {
            companyWinlossService.generate({
                level: levels.SITE,
                betType: betType,
                betTypeName: betTypeName,
                site: site
            });
        };

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function generate(startDate, endDate) {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            virtualSportsService.getBetType(dateRange.startDate, dateRange.endDate, gridModel.sportType).then(function (data) {
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
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li><a href data-ng-click="generateSportType()">' + gridModel.productName + '</a></li><li class="active">' + gridModel.sportTypeName + ' Product Win/Loss Report</li></ol>',
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
                var betTypeData = betTypes[i];
                bodyData.push(createBetTypeWinLossDataRow(betTypeData));
            }

            return bodyData;
        }

        function createBetTypeWinLossDataRow(betTypeWinLossItem) {
            var betTypeName = betTypeWinLossItem.Total.Name;
            return {
                Columns: createWinLossDataRow(betTypeWinLossItem.Total, false, 'generateDetail', betTypeName),
                SubRows: [
                    { Columns: createWinLossDataRow(betTypeWinLossItem.Credit, true, 'generateCreditSite', betTypeName) },
                    { Columns: createWinLossDataRow(betTypeWinLossItem.Deposit, true, 'generateDepositSite', betTypeName) }
                ]
            };
        }

        function createWinLossDataRow(winLoss, isTextRight, generateFunc, betTypeName) {
            var sportTypeColumn = !generateFunc
                ? { Name: "BetType", Value: winLoss.Name }
                : {
                    Name: "BetType", Value: winLoss.Name, CustomCellRender: function (cellValue) {
                        return '<a class="drill-down" href data-ng-click="' + generateFunc + '(' + winLoss.Id + ',\'' + betTypeName + '\')">' + winLoss.Name + '</a>';
                    }
                };
            if (isTextRight) {
                sportTypeColumn.CellAlign = 'right';
            }
            return [
                sportTypeColumn,
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
                { Columns: createWinLossDataRow(grandTotal.Total, true) },
                { Columns: createWinLossDataRow(grandTotal.Credit, true) },
                { Columns: createWinLossDataRow(grandTotal.Deposit, true) }
            ];
        }

        function exportExcel() {

        }
    }
})();