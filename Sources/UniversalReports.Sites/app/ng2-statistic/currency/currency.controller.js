import angular from "angular";
import numeral from "numeral";
(function (angular) {
    'use strict';

    angular
        .module('app.numberGame2StatisticApp')
        .controller('CurrencyController', CurrencyController);

    CurrencyController.$inject = ['$element', '$scope', 'fanexGridService'];
    function CurrencyController($element, $scope, fanexGridService) {
        var pane = $scope.pane;
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
             

        function generate() {
            pane.service.getData(pane.data).then(function(data){
                renderGrid(data);
                pane.compileAll();
            });
        }

        function renderGrid(data){
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showExcelButton: true,
                exportExcelFunction: exportExcel,
            };

            data.titleInfo = titleInfo;
            gridElement.fanexGrid(data);
        }
              

        function exportExcel(){
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane.data, pane.getFileName());
        }
    }
})(angular);