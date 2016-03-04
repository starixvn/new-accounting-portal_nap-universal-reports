(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('NumberGameSiteController', NumberGameSiteController);

    NumberGameSiteController.$inject = ['$compile', '$scope', '$element', 'companyWinlossService', 'breadcrumbHelper', 'fanexGridHelper', 'numberGameSiteService'];
    function NumberGameSiteController($compile, $scope, $element, companyWinlossService, breadcrumbHelper, fanexGridHelper, numberGameSiteService) {
        var gridElement = $element.find('.freegrid');
        var gridModel = companyWinlossService.gridModel;
        $scope.generate = generate;
        $scope.show = show;

        function generate() {
            numberGameSiteService.getData().then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function renderGrid(data) {
            var titleInfo = {
                text: breadcrumbHelper.generateHtml($scope, gridModel.isLive),
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
            numberGameSiteService.exportExcel();
        }
    }
})();