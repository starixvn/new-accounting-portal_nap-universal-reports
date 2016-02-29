(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('VirtualSportsSportsbookDetailController', VirtualSportsSportsbookDetailController);

    VirtualSportsSportsbookDetailController.$inject = ['$compile', '$scope', '$element', 'virtualSportsSportsbookDetailService', 'breadcrumbHelper', 'fanexGridHelper'];
    function VirtualSportsSportsbookDetailController($compile, $scope, $element, virtualSportsSportsbookDetailService, breadcrumbHelper, fanexGridHelper) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;

        function generate() {
            virtualSportsSportsbookDetailService.getData().then(function (data) {
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
            fanexGridHelper.highlightFooterColumns(data);
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