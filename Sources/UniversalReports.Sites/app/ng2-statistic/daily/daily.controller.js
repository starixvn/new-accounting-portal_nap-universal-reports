import angular from "angular";
import numeral from "numeral";
(function (angular) {
    'use strict';

    angular
        .module('app.numberGame2StatisticApp')
        .controller('DailyController', DailyController);

    DailyController.$inject = ['$element', '$scope', 'fanexGridService'];
    function DailyController($element, $scope, fanexGridService) {
        console.log("DailyController");
        var pane = $scope.pane;
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;

        function generate() {
            pane.service.getData(pane.data).then(function(data){
                createLinks(data);
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

        function createLinks(data){
            //for (var i = 0; i < data.bodyRows.length; i++) {
            //    var productRow = data.bodyRows[i];
            //    var customAttr = productRow.CustomAttr;
            //    if (customAttr === 'currency') {
            //        var productName = productRow.Columns[0].Value;
            //        productRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateCurrency(\'' + productName.replace('\'', '\\\'') + '\')">' + productName + '</a>';
            //    }
            //}
        }

        function exportExcel(){
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane.data, pane.getFileName());
        }
    }
})(angular);