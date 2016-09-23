import angular from "angular";
import numeral from "numeral";
(function (angular) {
    'use strict';

    angular
        .module('app.numberGame2StatisticApp')
        .controller('DailyController', DailyController);

    DailyController.$inject = ['$element', '$scope', 'fanexGridService'];
    function DailyController($element, $scope, fanexGridService) {
        var pane = $scope.pane;
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.generateCurrencyReport = generateCurrencyReport;
        $scope.generateGrandtotalReport = generateGrandtotalReport;

        function generateCurrencyReport(){
            var data = { drilldownType: "Currency"}; 
            pane.data.isDrilldown = true;

            angular.extend(data, pane.data);
            tab.goForward(data);
        }

        function generateGrandtotalReport(){
            var data = { drilldownType: "Grandtotal"};
            pane.data.isDrilldown = true;

            angular.extend(data, pane.data);
            tab.goForward(data);
        }

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
            //    if (customAttr === 'Currency') {
            //        var productName = productRow.Columns[0].Value;
            //        productRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateReport()">' + '</a>';
            //    }
            //}
            for (var i = 0; i < data.bodyRows.length; i++) {
                var productColumn = data.bodyRows[i].Columns[0];
                var productId = productColumn.CustomAttr;
                var productName = productColumn.Value;
                productColumn.Value = '<a class="drill-down" href data-nap-click="generateCurrencyReport(' + productId + ',\'' + productName.replace('\'', '\\\'') + '\')">' + productName + '</a>';
            }

            var grandTotalColumn = data.footerRows[0].Columns[0];
            grandTotalColumn.Value = '<a class="drill-down" href data-nap-click="generateGrandtotalReport()">' + grandTotalColumn.Value + '</a>';
        }

        function exportExcel(){
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane.data, pane.getFileName());
        }
    }
})(angular);