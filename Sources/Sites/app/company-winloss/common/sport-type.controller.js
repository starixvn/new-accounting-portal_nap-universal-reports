(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('SportTypeController', SportTypeController);

    SportTypeController.$inject = ['$injector', '$compile', '$scope', '$element', 'companyWinlossService', 'breadcrumbHelper', 'fanexGridHelper'];
    function SportTypeController($injector, $compile, $scope, $element, companyWinlossService, breadcrumbHelper, fanexGridHelper) {
        var gridElement = $element.find('.freegrid');
        var service = getService();

        $scope.generate = generate;
        $scope.generateBetType = service.generateBetType;
        $scope.show = show;

        function getService() {
            var productName = companyWinlossService.gridModel.productName.replace(/\s+/g, '');
            var camelProductName = productName.charAt(0).toLowerCase() + productName.slice(1);
            var serviceName = camelProductName + 'SportTypeService';
            return $injector.get(serviceName);
        };

        function generate() {
            service.getData().then(function (data) {
                service.createLinks(data);
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
                showCollapseExpandButton: true,
                showExcelButton: true,
                exportExcelFunction: exportExcel
            };

            data.titleInfo = titleInfo;
            data.defaultCollapseAllGroups = true;
            data.gridExpandHeight = fanexGridHelper.calculateExpandHeight(gridElement, true);
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