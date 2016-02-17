(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('VirtualSportsBetTypeController', VirtualSportsBetTypeController);

    VirtualSportsBetTypeController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'virtualSportsService', 'breadcrumbHelper'];
    function VirtualSportsBetTypeController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, virtualSportsService, breadcrumbHelper) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateDetail = generateDetail;
        $scope.generateSite = generateSite;

        function generateDetail(betType, betTypeName) {
            companyWinlossService.generate({
                level: levels.DETAIL,
                betType: betType,
                betTypeName: betTypeName
            });
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
            breadcrumbHelper.compile($element);
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);
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
                    { Columns: createWinLossDataRow(betTypeWinLossItem.Credit, true, 'generateSite', betTypeName) },
                    { Columns: createWinLossDataRow(betTypeWinLossItem.Deposit, true, 'generateSite', betTypeName) }
                ]
            };
        }

        function createWinLossDataRow(winLoss, isTextRight, generateFunc, betTypeName) {
            var sportTypeColumn = !generateFunc
                ? { Name: "BetType", Value: winLoss.Name }
                : {
                    Name: "BetType", Value: winLoss.Name, CustomCellRender: function (cellValue) {
                        return '<a class="drill-down" href data-ng-click="' + generateFunc + '(' + winLoss.Id + ',\'' + betTypeName + '\',\'' + winLoss.Name + '\')">' + winLoss.Name + '</a>';
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