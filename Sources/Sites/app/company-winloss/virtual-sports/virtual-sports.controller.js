(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('VirtualSportsController', VirtualSportsController);

    VirtualSportsController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'sites', 'levels', 'companyWinlossService', 'virtualSportsService'];
    function VirtualSportsController($compile, $scope, $element, formatStrings, fanexGridHelper, sites, levels, companyWinlossService, virtualSportsService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateSportType = function (sportType, sportTypeName) {
            companyWinlossService.generate({
                level: levels.SPORT_TYPE,
                sportType: sportType,
                sportTypeName: sportTypeName
            });
        };
        $scope.generateMain = function () {
            companyWinlossService.generate({
                level: levels.MAIN
            });
        };

        function generate() {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            virtualSportsService.getSummary(dateRange.startDate, dateRange.endDate).then(function (data) {
                renderGrid(gridElement, data);
                compileLinks();
            });
        }

        function show() {
            gridElement.fanexGrid('resizeGrid');
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
                 { HeaderText: "Sport Type", Width: 150, Name: "SportType", HeaderAlign: "center", CellAlign: "left", ShowCollapseExpand: true },
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
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateMain()">MAIN</a></li><li class="active">' + gridModel.productName + '</li></ol>',
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
            var sports = data.Sports;
            for (var i = 0; i < sports.length; i++) {
                var sportTypeItem = sports[i];
                bodyData.push(createSportTypeWinLossDataRow(sportTypeItem));
            }

            return bodyData;
        }

        function createSportTypeWinLossDataRow(sportTypeWinLossItem) {
            return {
                Columns: createWinLossDataRow(sportTypeWinLossItem.Total, false, true),
                SubRows: [
                    { Columns: createWinLossDataRow(sportTypeWinLossItem.Credit, true, false) },
                    { Columns: createWinLossDataRow(sportTypeWinLossItem.Deposit, true, false) }
                ]
            };
        }

        function createWinLossDataRow(winLoss, isTextRight, isTotal) {
            var sportTypeColumn = !isTotal
                ? { Name: "SportType", Value: winLoss.Name }
                : {
                    Name: "SportType", Value: winLoss.Name, CustomCellRender: function (cellValue) {
                        return '<a class="drillDown" href data-ng-click="generateSportType(' + winLoss.Id + ',\'' + winLoss.Name + '\')">' + winLoss.Name + '</a>';
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