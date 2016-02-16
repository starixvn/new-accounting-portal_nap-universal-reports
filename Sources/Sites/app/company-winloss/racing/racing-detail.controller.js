(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('RacingDetailController', RacingDetailController);

    RacingDetailController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'racingService'];
    function RacingDetailController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, racingService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.generateProduct = generateProduct;
        $scope.generateSportType = generateSportType;
        $scope.generateBetType = generateBetType;

        function generateSportType() {
            companyWinlossService.generate({
                level: levels.SPORT_TYPE
            });
        };

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };
        function generateBetType() {
            companyWinlossService.generate({
                level: levels.BET_TYPE
            });
        };

        function generate(startDate, endDate) {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            racingService.getGameDetail(dateRange.startDate, dateRange.endDate, gridModel.sportType, gridModel.betType).then(function (data) {
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
                 { HeaderText: "Race", Width: 150, Name: "Name", HeaderAlign: "center", CellAlign: "center" },
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
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li><a href data-ng-click="generateSportType()">' + gridModel.productName + '</a></li><li><a href data-ng-click="generateBetType()">' + gridModel.sportTypeName + '</a></li><li class="active">' + gridModel.betTypeName + '</li></ol>',
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
            var leagues = data.Leagues;
            for (var i = 0; i < leagues.length; i++) {
                var leagueData = leagues[i];

                appendLeagueHeaderRow(bodyData, leagueData);
                appendRaceWinLossDataRow(bodyData, leagueData);
            }

            return bodyData;
        }


        function appendLeagueHeaderRow(bodyData, leagueData) {
            var leagueRowHeader = {
                Columns: [{
                    Name: "Name", Value: leagueData.LeagueName, MergeColNumber: 7, CellAlign: "left",
                }]
            };
            bodyData.push(leagueRowHeader);
        }

        function appendRaceWinLossDataRow(bodyData, leagueData) {

            var races = leagueData.Races;
            for (var i = 0; i < races.length; i++) {
                appendRaceDataRow(bodyData, races[i], "center");
            }

            appendRaceDataRow(bodyData, leagueData.Total, "right");
        }

        function appendRaceDataRow(bodyData, winLoss, align) {
            var row = createRaceDataRow(winLoss, align);
            bodyData.push(row);
        }

        function createRaceDataRow(winLoss, align) {
            return {
                Columns: [
                    { Name: "Name", Value: winLoss.Name, CellAlign: align },
                    { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                    { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                    { Name: "Commission", Value: winLoss.Commission },
                    { Name: "RealIncome", Value: winLoss.RealIncome },
                    { Name: "RealTurnover", Value: winLoss.RealTurnover },
                    { Name: "RealMargin", Value: winLoss.RealMargin }
                ]
            };
        }

        function createWinLossDataRowFooter(winLoss) {
            return;
        }

        function createFooterData(data) {
            return createRaceDataRow(data.Total, "right");
        }

        function exportExcel() {

        }
    }
})();