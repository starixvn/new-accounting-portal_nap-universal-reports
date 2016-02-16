(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('VirtualSportsDetailController', VirtualSportsDetailController);

    VirtualSportsDetailController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'virtualSportsService'];
    function VirtualSportsDetailController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, virtualSportsService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
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
        $scope.generateBetType = function () {
            companyWinlossService.generate({
                level: levels.BET_TYPE
            });
        };

        function generate(startDate, endDate) {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            virtualSportsService.getGameDetail(dateRange.startDate, dateRange.endDate, gridModel.sportType, gridModel.betType).then(function (data) {
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
                 { HeaderText: "Code", Width: 150, Name: "Code", HeaderAlign: "center", CellAlign: "center" },
                 { HeaderText: "HomeName", Width: 150, Name: "HomeName", HeaderAlign: "center", CellAlign: "center" },
                 { HeaderText: "vs", Width: 30, Name: "vs", HeaderAlign: "center", CellAlign: "center" },
                 { HeaderText: "AwayName", Width: 150, Name: "AwayName", HeaderAlign: "center", CellAlign: "center" },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var groupHeaderRowsColumns = [
                { HeaderText: "Code", Name: "Code" },
                { HeaderText: "Event", Name: "HomeName", MergeColNumber: 3 },
                { HeaderText: "Member Win Loss", Name: "MemberWinLoss" },
                { HeaderText: "SMA Win Loss", Name: "SMAWinLoss" },
                { HeaderText: "Commission", Name: "Commission" },
                { HeaderText: "Company Income", Name: "RealIncome" },
                { HeaderText: "Company Turnover", Name: "RealTurnover" },
                { HeaderText: "Margin", Name: "RealMargin" }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                customizeHeader: true,
                groupHeaderRows: [
                    { Columns: groupHeaderRowsColumns }
                ],
                columns: columns,
                bodyRows: createBodyData(data),
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li><a href data-ng-click="generateSportType()">' + gridModel.productName + '</a> | <a href data-ng-click="generateBetType()">' + gridModel.sportTypeName + '</a></li><li class="active">' + gridModel.betTypeName + '</li></ol>',
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
            var matches = data.Matches;
            for (var i = 0; i < matches.length; i++) {
                var matchData = matches[i];
                bodyData.push({ Columns: createWinLossDataRow(matchData) });
            }

            return bodyData;
        }

        function createWinLossDataRow(winLoss, isFooter) {
            return [
                { Name: "Code", Value: winLoss.MatchCode, CssClass: isFooter ? 'text-right' : '' },
                { Name: "HomeName", Value: winLoss.HomeName },
                { Name: "vs", Value: '-vs-' },
                { Name: "AwayName", Value: winLoss.AwayName },
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.Margin }
            ];
        }

        function createFooterData(data) {
            var gridModel = companyWinlossService.gridModel;
            var total = data.Total;
            total.MatchCode = gridModel.betTypeName + ' Total';
            return [
                { Columns: createWinLossDataRow(total, true) }
            ];
        }

        function exportExcel() {

        }
    }
})();