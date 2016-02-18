(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('RacingSportTypeController', RacingSportTypeController);

    RacingSportTypeController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'racingService', 'breadcrumbHelper'];
    function RacingSportTypeController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, racingService, breadcrumbHelper) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateBetType = generateBetType;

        function generateBetType(sportType, sportTypeName) {
            companyWinlossService.generate({
                level: levels.BET_TYPE,
                sportType: sportType,
                sportTypeName: sportTypeName
            });
        };

        function generate() {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            racingService.getSportType(dateRange.startDate, dateRange.endDate).then(function (data) {
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
            breadcrumbHelper.compile($element);
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);
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

            var gridOptions = {
                columns: columns,
                bodyRows: createBodyData(data),
                showTree: true,
                defaultCollapseAllGroups: true,
                showTitle: true,
                titleInfo:
                {
                    text: breadcrumbHelper.generateHtml($scope),
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
                        return '<a class="drill-down" href data-ng-click="generateBetType(' + winLoss.Id + ',\'' + winLoss.Name + '\')">' + winLoss.Name + '</a>';
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