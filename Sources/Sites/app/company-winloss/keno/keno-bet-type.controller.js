(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('KenoBetTypeController', KenoBetTypeController);

    KenoBetTypeController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'kenoService', 'breadcrumbHelper'];
    function KenoBetTypeController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, kenoService, breadcrumbHelper) {
        var gridModel = companyWinlossService.gridModel;
        var filterModel = companyWinlossService.filterModel;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateSite = generateSite;

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
            var dateRange = filterModel.getDateRange();
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
            breadcrumbHelper.compile($element);
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);
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
            var bettypes = data.BetTypes;
            for (var i = 0; i < bettypes.length; i++) {
                var bettypeItem = bettypes[i];
                bodyData.push(createBetTypeWinLossDataRow(bettypeItem));
            }

            return bodyData;
        }

        function createBetTypeWinLossDataRow(bettypeItem) {
            var betTypeName = bettypeItem.Total.Name;
            return {
                Columns: createWinLossDataRow(bettypeItem.Total, true),
                SubRows: [
                    { Columns: createWinLossDataRow(bettypeItem.Credit, false, betTypeName) },
                    { Columns: createWinLossDataRow(bettypeItem.Deposit, false, betTypeName) }
                ]
            };
        }

        function createWinLossDataRow(winLoss, isTotal, betTypeName) {
            var betTypeColumn = isTotal ? createBetTypeTotalColumn(winLoss) : createBetTypeSiteColumn(winLoss, betTypeName);
            var remainColumn = createColumnWithoutBetType(winLoss);
            return betTypeColumn.concat(remainColumn);
        }

        function createBetTypeTotalColumn(winLoss) {
            return [{
                Name: "Name",
                Value: winLoss.Name,
            }];
        }

        function createBetTypeSiteColumn(winLoss, betTypeName) {
            return [{
                Name: "Name",
                Value: winLoss.Name,
                CellAlign: 'right',
                CustomCellRender: function (cellValue) {
                    return '<a class="drill-down" href data-ng-click="generateSite(' + winLoss.Id + ',\'' + betTypeName + '\',\'' + winLoss.Name + '\')">' + winLoss.Name + '</a>';
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