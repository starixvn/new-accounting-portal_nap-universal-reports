(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('VirtualSportsRacingDetailController', VirtualSportsRacingDetailController);

    VirtualSportsRacingDetailController.$inject = ['$compile', '$scope', '$element', 'virtualSportsRacingDetailService', 'breadcrumbHelper', 'fanexGridHelper'];
    function VirtualSportsRacingDetailController($compile, $scope, $element, virtualSportsRacingDetailService, breadcrumbHelper, fanexGridHelper) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;

        function generate() {
            virtualSportsRacingDetailService.getData().then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var titleInfo = {
                text: breadcrumbHelper.generateHtml($scope),
                showExcelButton: true,
                exportExcelFunction: exportExcel
            };

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridHelper.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function compileLinks() {
            breadcrumbHelper.compile($element);
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);
        }

        function exportExcel() {
            virtualSportsRacingDetailService.exportExcel();
        }
    }
})();