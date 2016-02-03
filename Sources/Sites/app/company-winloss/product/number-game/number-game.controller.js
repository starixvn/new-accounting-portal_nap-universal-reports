(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('NumberGameController', NumberGameController);

    NumberGameController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'companyWinlossService', 'numberGameService'];
    function NumberGameController($compile, $scope, $element, formatStrings, fanexGridHelper, companyWinlossService, numberGameService) {
        var gridElements = $element.find('.freegrid');
        var nonliveGridElement = angular.element(gridElements[0]);
        var liveGridElement = angular.element(gridElements[1]);
        $scope.generate = generate;
        $scope.drillDownBetType = function () {
            console.log('drillDownBetType');
        };
        $scope.drillDownSite = function () {
            console.log('drillDownSite');
        };
        $scope.drillUpMain = function () {
            companyWinlossService.generateMain();
        };

        function generate(startDate, endDate) {
            numberGameService.getData(startDate, endDate).then(function (data) {
                var nonLiveData = {
                    Title: 'NUMBER GAME "NON-LIVE" PRODUCT WIN/LOSS REPORT',
                    GrandTotal: data.NonLiveGrandTotal,
                    BetTypes: data.NonLive
                };
                renderGrid(nonliveGridElement, nonLiveData);
                var liveData = {
                    Title: 'NUMBER GAME "LIVE" PRODUCT WIN/LOSS REPORT',
                    GrandTotal: data.LiveGrandTotal,
                    BetTypes: data.Live
                };
                renderGrid(liveGridElement, liveData);
                compileLinks();
            });
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
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="drillUpMain()">MAIN</a></li><li class="active">' + data.Title + '</li></ol>',
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
                bodyData.push(createBetTypeWinLossDataRow(betTypeItem));
            }

            return bodyData;
        }

        function createWinLossDataRow(winLoss, drillDown) {
            var productColumn = !drillDown
                ? { Name: "BetType", Value: winLoss.Name }
                : {
                    Name: "BetType", Value: winLoss.Name, CustomCellRender: function (cellValue) {
                        return '<a class="drillDown" href data-ng-click="' + drillDown + '(\'' + winLoss.Name + '\')">' + winLoss.Name + '</a>';
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

        function createBetTypeWinLossDataRow(betTypeWinLossItem) {
            var betTypeDataRow = {
                Columns: createWinLossDataRow(betTypeWinLossItem.Total, 'drillDownBetType'),
                SubRows: []
            };

            betTypeDataRow.SubRows.push({
                Columns: createWinLossDataRow(betTypeWinLossItem.Credit, 'drillDownSite'), CssClass: 'align-right'
            });
            betTypeDataRow.SubRows.push({
                Columns: createWinLossDataRow(betTypeWinLossItem.Deposit, 'drillDownSite'), CssClass: 'align-right'
            });

            return betTypeDataRow;
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