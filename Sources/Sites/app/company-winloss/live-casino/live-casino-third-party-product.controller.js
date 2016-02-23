(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('LiveCasinoThirdPartyProductController', LiveCasinoThirdPartyProductController);

    LiveCasinoThirdPartyProductController.$inject = ['$compile', '$scope', '$element', 'levels', 'companyWinlossService', 'liveCasinoThirdPartyProductService', 'breadcrumbHelper'];
    function LiveCasinoThirdPartyProductController($compile, $scope, $element, levels, companyWinlossService, liveCasinoThirdPartyProductService, breadcrumbHelper) {
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
            liveCasinoThirdPartyProductService.getData().then(function (data) {
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
                var productColumn = data.bodyRows[i].Columns[0];
                var productId = productColumn.CustomAttr;
                var productName = productColumn.Value;
                productColumn.Value = '<a class="drill-down" href data-nap-click="generateBetType(' + productId + ',\'' + productName.replace('\'', '\\\'') + '\')">' + productName + '</a>';
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