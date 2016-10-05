import angular from "angular";
import numeral from "numeral";
import moment from "moment";
(function (angular) {
    'use strict';

    angular
        .module('app.numberGame2StatisticApp')
        .controller('BettypeController', BettypeController);

    BettypeController.$inject = ['$rootScope', '$element', '$scope', 'fanexGridService', 'ngDialog','$injector'];
    function BettypeController($rootScope, $element, $scope, fanexGridService, ngDialog, $injector) {
        var pane = $scope.pane;
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.generateCurrencyReport = generateCurrencyReport;
        $scope.generateGrandtotalReport = generateGrandtotalReport;

        function generateCurrencyReport(idCurrency, betTypeId){
            var dataQuery = pane.data;
            dataQuery.drilldownType = "Currency";
            dataQuery.currency = parseInt(idCurrency);
            dataQuery.betType = betTypeId;
            //dataQuery.startDate = moment.utc(dateCurrency).startOf('day');
            //dataQuery.endDate = moment.utc(dateCurrency).startOf('day');
            dataQuery.isDrilldown = true;

            tab.goForward(dataQuery);
        }

        function generateGrandtotalReport(){
            var  data = pane.data;
            data.drilldownType = "Grandtotal"; 
            data.isDrilldown = true;
            pane.service = $injector.get("grandtotalService");
            pane.controller = 'GrandtotalController';
            generatePopup(data);
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

            data.titleInfo = titleInfo;
            data.sortOption = sortOptions;
            gridElement.fanexGrid(data);
        }

        function checkDrilldown(data){
            if(!pane.data.isDrilldown){
                createLinks(data);
            }
            createLinkTotal(data);
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
                var betTypeId = row.Columns[2];

                //var dateCurrency = row.Columns[0].Value;

                
                var idCurrency = currencyColumn.CustomAttr;
                currencyColumn.Value = '<a class="drill-down" href data-nap-click="generateCurrencyReport(' + idCurrency + ',\'' + betTypeId + '\')">' + currencyColumn.Value + '</a>';
            }
        }

        function createLinkTotal(data){            
            var grandTotalColumn = data.footerRows[0].Columns[0];
            grandTotalColumn.Value = '<a class="drill-down" href data-nap-click="generateGrandtotalReport()">' + grandTotalColumn.Value + '</a>';
        }

        function exportExcel(){
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane.data, pane.getFileName());
        }

        function generatePopup() {
            pane.service.getData(pane).then(function(data){
                renderPopup(data);
            });
        }

        function exportExcelGrandTotal(){
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane, pane.getFileName());
        }

        function renderPopup(data){
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showExcelButton: true,
                exportExcelFunction: exportExcelGrandTotal,
            };
            data.titleInfo = titleInfo;            
            ngDialog.open({template: 'templateId',
                plain: false,                
                width: 1190,
                closeByDocument: false,
                data: data                
            });

            $rootScope.$on('ngDialog.opened', function (e, $dialog) {
                $('#myGrid').fanexGrid(data);
            });
        }
    }
})(angular);