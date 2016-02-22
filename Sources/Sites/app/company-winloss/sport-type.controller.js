(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('SportTypeController', SportTypeController);

    SportTypeController.$inject = ['$injector', '$compile', '$scope', '$element', 'companyWinlossService', 'breadcrumbHelper'];
    function SportTypeController($injector, $compile, $scope, $element, companyWinlossService, breadcrumbHelper) {
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