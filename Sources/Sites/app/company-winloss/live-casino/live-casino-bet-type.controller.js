(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('LiveCasinoBetTypeController', LiveCasinoBetTypeController);

    LiveCasinoBetTypeController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'liveCasinoService', 'breadcrumbHelper'];
    function LiveCasinoBetTypeController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, liveCasinoService, breadcrumbHelper) {
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
        }

        function generate() {
            var dateRange = filterModel.getDateRange();
            liveCasinoService.getBetType(dateRange.startDate, dateRange.endDate, gridModel.thirdPartyProductId, breadcrumbHelper.generateText()).then(function (data) {
                createLinks(data);
                renderGrid(data);
                compileLinks();
            });
        }

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function renderGrid(data) {
            var titleInfo = {
                text: breadcrumbHelper.generateHtml($scope),
                showExcelButton: true,
                exportExcelFunction: exportExcel
            };

            data.titleInfo = titleInfo;
            data.defaultCollapseAllGroups = true;
            gridElement.fanexGrid(data);
        }

        function createLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var bettype = data.bodyRows[i];
                var betTypeName = bettype.Columns[0].Value;
                for (var j = 0; j < bettype.SubRows.length; j++) {
                    var customAttr = data.bodyRows[i].SubRows[j].Columns[0].CustomAttr;
                    var customAttrData = customAttr.split('\,');
                    data.bodyRows[i].SubRows[j].Columns[0].Value = '<a class="drill-down" href data-ng-click="generateSite(' + customAttrData[0] + ',\'' + betTypeName + '\',\'' + customAttrData[1] + '\')">' + customAttrData[1] + '</a>';
                }
            }
        }

        function compileLinks() {
            breadcrumbHelper.compile($element);
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);
        }

        function exportExcel() {
        }
    }
})();