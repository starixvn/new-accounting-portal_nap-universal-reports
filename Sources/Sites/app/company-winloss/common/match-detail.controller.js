(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('MatchDetailController', MatchDetailController);

    MatchDetailController.$inject = ['$scope', '$element', 'fanexGridService', 'showHideColumnService'];
    function MatchDetailController($scope, $element, fanexGridService, showHideColumnService) {
        var pane = $scope.pane;
        var showHideColumnBuilder = new showHideColumnService(pane);
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.show = showHideColumnBuilder.toggle;
        $scope.generate = generate;

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                if (pane.data.sportType === 180) {
                    showHideColumnBuilder.updateOptions({ hiddenColumns: [4, 5] });
                } else {
                    showHideColumnBuilder.updateOptions({ hiddenColumns: [1, 2] });
                }
                showHideColumnBuilder.build(gridElement, data);
                renderGrid(data);
                pane.compileAll();
            });
        }

        function renderGrid(data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showExcelButton: true,
                exportExcelFunction: exportExcel,
                customButtons: showHideColumnBuilder.getButtonHtml()
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
            gridElement.fanexGrid(data);
        }

        function exportExcel() {
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane.data, pane.getFileName());
        }
    }
})(angular);