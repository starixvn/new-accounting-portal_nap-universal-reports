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
            var sortOptions = {
                serverSortFunction: generateSort
            };

            gridOptions.titleInfo = titleInfo;
            gridOptions.sortOption = sortOptions;
            gridElement.fanexGrid(gridOptions);
        }

        function checkDrilldown(data){
            if(!pane.data.isDrilldown){
                createLinks(data);
            }
        }

        function generateSort(sortColumnName, sortDirection){
            pane.data.sortColumnName = sortColumnName;
            pane.data.sortDirection = sortDirection;
            pane.service.getDataSort(pane.data).then(function(data){
                checkDrilldown(data);
                renderGrid(data);
                pane.compileAll();
            });
        }

        function createLinks(data){
            
            for (var i = 0; i < data.bodyRows.length; i++) {
                var row = data.bodyRows[i];
                var currencyColumn = row.Columns[3];
                var dateCurrency = row.Columns[0].Value;

                if(row.Columns.length == 10){
                    currencyColumn = row.Columns[2];
                    dateCurrency = row.Columns[1].CustomAttr;
                }
                
                var idCurrency = currencyColumn.CustomAttr;
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