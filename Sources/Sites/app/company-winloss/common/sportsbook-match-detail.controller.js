(function (angular) {
    'use strict';
    angular
        .module('app.companyWinlossApp')
        .controller('SportsbookMatchDetailController', SportsbookMatchDetailController);

    SportsbookMatchDetailController.$inject = ['$scope', '$element', 'fanexGridService'];
    function SportsbookMatchDetailController($scope, $element, fanexGridService) {
        var pane = $scope.pane;
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                renderGrid(data);
                pane.compileLinks();
            });
        }

        function renderGrid(data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showExcelButton: true,
                exportExcelFunction: exportExcel
            };

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function exportExcel() {
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane.data, pane.getFileName());
        }
    }

})(angular);