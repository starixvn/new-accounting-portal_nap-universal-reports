(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('NumberGameController', NumberGameController);

    NumberGameController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'sites', 'levels', 'companyWinlossService', 'numberGameService'];
    function NumberGameController($compile, $scope, $element, formatStrings, fanexGridHelper, sites, levels, companyWinlossService, numberGameService) {
        var gridElements = $element.find('.freegrid');
        var nonliveGridElement = angular.element(gridElements[0]);
        var liveGridElement = angular.element(gridElements[1]);
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateBetType = function (betType, betTypeName, isLive) {
            companyWinlossService.generate({
                level: levels.BET_TYPE,
                betType: betType,
                betTypeName: betTypeName,
                isLive: isLive
            });
        };
        $scope.generateCreditSite = function (betType, betTypeName, isLive) {
            generateSite(betType, betTypeName, isLive, sites.CREDIT);
        };
        $scope.generateDepositSite = function (betType, betTypeName, isLive) {
            generateSite(betType, betTypeName, isLive, sites.DEPOSIT);
        };
        $scope.generateMain = function () {
            companyWinlossService.generate({
                level: levels.MAIN
            });
        };

        function generateSite(betType, betTypeName, isLive, site) {
            companyWinlossService.generate({
                level: levels.SITE,
                betType: betType,
                betTypeName: betTypeName,
                isLive: isLive,
                site: site
            });
        };

        function generate(startDate, endDate) {
            numberGameService.getSummary(startDate, endDate).then(function (data) {
                var nonLiveData = {
                    Title: 'NUMBER GAME "NON-LIVE" PRODUCT WIN/LOSS REPORT',
                    IsLive: false,
                    GrandTotal: data.NonLiveGrandTotal,
                    BetTypes: data.NonLive
                };
                renderGrid(nonliveGridElement, nonLiveData);
                var liveData = {
                    Title: 'NUMBER GAME "LIVE" PRODUCT WIN/LOSS REPORT',
                    IsLive: true,
                    GrandTotal: data.LiveGrandTotal,
                    BetTypes: data.Live
                };
                renderGrid(liveGridElement, liveData);
                compileLinks();
            });
        }

        function show() {
            nonliveGridElement.fanexGrid('resizeGrid');
            liveGridElement.fanexGrid('resizeGrid');
        }

        function renderGrid(gridElement, data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drillDown');
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

            var gridOptions = {
                columns: columns,
                bodyRows: createBodyData(data),
                showTree: true,
                defaultCollapseAllGroups: true,
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateMain()">MAIN</a></li><li class="active">' + data.Title + '</li></ol>',
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
            var betTypes = data.BetTypes;
            for (var i = 0; i < betTypes.length; i++) {
                var betTypeItem = betTypes[i];
                bodyData.push(createBetTypeWinLossDataRow(betTypeItem, data.IsLive));
            }

            return bodyData;
        }

        function createBetTypeWinLossDataRow(betTypeWinLossItem, isLive) {
            var betTypeName = betTypeWinLossItem.Total.Name;
            var betTypeDataRow = {
                Columns: createWinLossDataRow(betTypeWinLossItem.Total, 'generateBetType', betTypeName, isLive),
                SubRows: []
            };

            betTypeDataRow.SubRows.push({
                Columns: createWinLossDataRow(betTypeWinLossItem.Credit, 'generateCreditSite', betTypeName, isLive), CssClass: 'align-right'
            });
            betTypeDataRow.SubRows.push({
                Columns: createWinLossDataRow(betTypeWinLossItem.Deposit, 'generateDepositSite', betTypeName, isLive), CssClass: 'align-right'
            });

            return betTypeDataRow;
        }

        function createWinLossDataRow(winLoss, generateFunc, betTypeName, isLive) {
            var productColumn = !generateFunc
                ? { Name: "BetType", Value: winLoss.Name }
                : {
                    Name: "BetType", Value: winLoss.Name, CustomCellRender: function (cellValue) {
                        return '<a class="drillDown" href data-ng-click="' + generateFunc + '(' + winLoss.Id + ',\'' + betTypeName + '\',' + isLive + ')">' + winLoss.Name + '</a>';
                    }
                };
            var winLossDataRow = [
                productColumn,
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin }
            ];

            return winLossDataRow;
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