(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('VirtualSportsSportsbookDetailController', VirtualSportsSportsbookDetailController);

    VirtualSportsSportsbookDetailController.$inject = ['$compile', '$scope', '$element', 'virtualSportsSportsbookDetailService', 'breadcrumbHelper'];
    function VirtualSportsSportsbookDetailController($compile, $scope, $element, virtualSportsSportsbookDetailService, breadcrumbHelper) {
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