(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('MatchDetailController', MatchDetailController);

    MatchDetailController.$inject = ['$scope', '$element', 'fanexGridService', 'showHideColumnService'];
    function MatchDetailController($scope, $element, fanexGridService, showHideColumnService) {
        var pane = $scope.pane;
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                showHideColumnService.build($scope, gridElement, data);
                renderGrid(data);
                pane.compileAll();
            });
        }

        function renderGrid(data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showExcelButton: true,
                exportExcelFunction: exportExcel,
                customButtons: showHideColumnService.getButtonHtml()
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