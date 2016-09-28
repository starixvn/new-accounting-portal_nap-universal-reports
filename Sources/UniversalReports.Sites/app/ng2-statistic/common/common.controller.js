import angular from "angular";
import numeral from "numeral";
import moment from "moment";
(function (angular) {
    'use strict';

    angular
        .module('app.numberGame2StatisticApp')
        .controller('CommonController', CommonController);

    CommonController.$inject = ['$element', '$scope', 'fanexGridService'];
    function CommonController($element, $scope, fanexGridService) {
        var pane = $scope.pane;
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.generateCurrencyReport = generateCurrencyReport;
        $scope.generateGrandtotalReport = generateGrandtotalReport;

        function generateCurrencyReport(idCurrency, dateCurrency){
            var dataQuery = pane.data;
            dataQuery.drilldownType = "Currency";
            dataQuery.currency = parseInt(idCurrency);
            dataQuery.startDate = moment.utc(dateCurrency).startOf('day');
            dataQuery.endDate = moment.utc(dateCurrency).startOf('day');
            dataQuery.isDrilldown = true;

            tab.goForward(dataQuery);
        }

        function generateGrandtotalReport(){
            var  data = pane.data;
            data.drilldownType = "Grandtotal"; 
            data.isDrilldown = true;

            tab.goForward(data);
        }

        function generate() {
            pane.service.getData(pane.data).then(function(data){
                checkDrilldown(data);
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

        function checkDrilldown(data){
            if(!pane.data.isDrilldown){
                createLinks(data);
            }
        }

        function createLinks(data){
            
            for (var i = 0; i < data.bodyRows.length; i++) {
                var currencyColumn = data.bodyRows[i].Columns[3];
                var idCurrency = currencyColumn.CustomAttr;
                var dateCurrency = data.bodyRows[i].Columns[0].CustomAttr;
                currencyColumn.Value = '<a class="drill-down" href data-nap-click="generateCurrencyReport(' + idCurrency + ',\'' + dateCurrency + '\')">' + currencyColumn.Value + '</a>';
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