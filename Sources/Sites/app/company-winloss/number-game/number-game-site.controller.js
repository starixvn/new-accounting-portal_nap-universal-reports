(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('NumberGameSiteController', NumberGameSiteController);

    NumberGameSiteController.$inject = ['$scope', '$element', 'fanexGridService'];
    function NumberGameSiteController($scope, $element, fanexGridService) {
        var pane = $scope.pane;
        pane.getTitle = getTitle;
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;

        function getTitle(isLast) {
            return pane.data.betTypeName + ' "' + (pane.data.isLive ? 'Live' : 'Non-Live') + ' | Product Win/Loss By ' + pane.data.site + ' Site';
        }

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