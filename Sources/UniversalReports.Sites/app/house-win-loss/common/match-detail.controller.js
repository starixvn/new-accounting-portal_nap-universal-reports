import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.houseWinlossApp')
        .controller('MatchDetailController', MatchDetailController);

    MatchDetailController.$inject = ['$scope', '$element', 'fanexGridService'];
    function MatchDetailController($scope, $element, fanexGridService) {
        var pane = $scope.pane;
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                renderGrid(data);
                pane.compileAll();
            });
        }

        function renderGrid(data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showExcelButton: true,
                exportExcelFunction: exportExcel
            };

            data.titleInfo = titleInfo;
            data.showPager = true;
            data.pagerOption = {
                itemsPerPage: 50,
                currentPage: 0,
                itemsPerPageArray: [50, 100, 200, 500],
                totalItem: data.bodyRows.length
            };

            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            data.headerColumnHeight = 10;
            data.bottomBorderWidth = 3;
            gridElement.fanexGrid(data);
        }

        function exportExcel() {
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane.data, pane.getFileName());
        }
    }
})(angular);