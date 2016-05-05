(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('SiteController', SiteController);

    SiteController.$inject = ['$injector', '$scope', '$element', 'fanexGridService', 'showHideColumnService'];
    function SiteController($injector, $scope, $element, fanexGridService, showHideColumnService) {
        var pane = $scope.pane;
        var showHideColumnBuilder = new showHideColumnService(pane);
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.show = showHideColumnBuilder.toggle;
        $scope.generate = generate;

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
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
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function exportExcel() {
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane.data, pane.getFileName());
        }
    }
})(angular);