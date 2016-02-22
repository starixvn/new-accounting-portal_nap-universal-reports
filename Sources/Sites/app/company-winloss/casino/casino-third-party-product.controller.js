(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('CasinoThirdPartyProductController', CasinoThirdPartyProductController);

    CasinoThirdPartyProductController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'casinoService', 'breadcrumbHelper'];
    function CasinoThirdPartyProductController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, casinoService, breadcrumbHelper) {
        var gridModel = companyWinlossService.gridModel;
        var filterModel = companyWinlossService.filterModel;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateBetType = generateBetType;

        function generateBetType(thirdPartyProductId, thirdPartyProductName) {
            companyWinlossService.generate({
                level: levels.BET_TYPE,
                thirdPartyProductId: thirdPartyProductId,
                thirdPartyProductName: thirdPartyProductName
            });
        };

        function generate() {
            var dateRange = filterModel.getDateRange();
            casinoService.getThirdPartyProduct(dateRange.startDate, dateRange.endDate).then(function (data) {
                createLinks(data);
                renderGrid(data);
                compileLinks();
            });
        }

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function createLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var customAttr = data.bodyRows[i].Columns[0].CustomAttr;
                var customAttrData = customAttr.split('\,');
                data.bodyRows[i].Columns[0].Value = '<a class="drill-down" href data-nap-click="generateBetType(' + parseInt(customAttrData[0]) + ',\'' + customAttrData[1] + '\')">' + customAttrData[1] + '</a>';
            }
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

        function compileLinks() {
            breadcrumbHelper.compile($element);
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);
        }

        function exportExcel() {
        }
    }
})();