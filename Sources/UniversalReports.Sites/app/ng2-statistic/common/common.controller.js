import angular from "angular";
import numeral from "numeral";
import moment from "moment";
(function (angular) {
    'use strict';

    angular
        .module('app.numberGame2StatisticApp')
        .controller('CommonController', CommonController);

    CommonController.$inject = ['$rootScope', '$element', '$scope', 'fanexGridService', 'ngDialog', '$injector', 'grandtotalService'];
    function CommonController($rootScope, $element, $scope, fanexGridService, ngDialog, $injector, grandtotalService) {
        var pane = $scope.pane;
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.generateCurrencyReport = generateCurrencyReport;
        $scope.generateGrandtotalReport = generateGrandtotalReport;


        function generateCurrencyReport(idCurrency, dateCurrency) {
            var data = {};
            angular.extend(data, pane.data);
            angular.extend(data, {
                drilldownType: "Currency",
                currency: pane.data.currency === -1 ? -1: idCurrency,
                startDate: moment.utc(dateCurrency).startOf('day'),
                endDate: moment.utc(dateCurrency).startOf('day'),
                isDrilldown: true
            }
            );
            tab.goForward(data);
        }

        function generateGrandtotalReport() {

            var data = {
                drilldownType: "Grandtotal",
                currency: pane.data.currency,
                isDrilldown: true,
                endDate: pane.data.endDate,
                startDate: pane.data.startDate,
                betType: pane.data.betType,
                username: pane.data.username,
                balanceUpDate: pane.data.balanceUpDate
            };

            grandtotalService.getData(data).then(function (data) {
                renderPopup(data);
            });
        }

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                checkDrilldown(data);
                renderGrid(data);
                pane.compileAll();
            });
        }

        function renderGrid(data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showExcelButton: true,
                exportExcelFunction: exportExcel
            };
            var sortOptions = {
                serverSortFunction: generateSort
            };
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            data.titleInfo = titleInfo;
            data.sortOption = sortOptions;
            gridElement.fanexGrid(data);
        }

        function checkDrilldown(data) {
            if (!pane.data.isDrilldown) {
                createLinks(data);
            }
        }

        function generateSort(sortColumnName, sortDirection) {
            pane.data.sortColumnName = sortColumnName;
            pane.data.sortDirection = sortDirection;
            pane.service.getDataSort(pane.data).then(function (data) {
                checkDrilldown(data);
                renderGrid(data);
                pane.compileAll();
            });
        }

        function createLinks(data) {
            if (pane.data.reportType !== "username") {
                for (var i = 0; i < data.bodyRows.length; i++) {
                    var row = data.bodyRows[i];
                    var currencyColumn = row.Columns.length === 11 ? row.Columns[3] : row.Columns[2];
                    var dateCurrency = row.Columns.length === 11 ? row.Columns[0].Value : row.Columns[1].CustomAttr;

                    currencyColumn.Value = '<a class="drill-down" href data-nap-click="generateCurrencyReport(' + currencyColumn.CustomAttr + ',\''
                                                                                                                + dateCurrency + '\')">'
                                                                                                                + currencyColumn.Value + '</a>';
                }
            }

            data.footerRows[0].Columns[0].Value = '<a class="drill-down" href data-nap-click="generateGrandtotalReport()">' + data.footerRows[0].Columns[0].Value + '</a>';
        }

        function exportExcel() {
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane.data, pane.getFileName());
        }

        function exportExcelGrandTotal() {
            var title = "GRAND TOTAL BY CURRENCY";
            grandtotalService.exportExcel(title, pane.data, pane.getFileName());
        }

        function renderPopup(data) {

            var titleInfo = {
                text: "GRAND TOTAL BY CURRENCY",
                showExcelButton: true,
                exportExcelFunction: exportExcelGrandTotal
            };

            data.titleInfo = titleInfo;
            ngDialog.open({
                template: 'templateId',
                plain: false,
                width: 1400,
                closeByDocument: false,
                data: data
            });

            $rootScope.$on('ngDialog.opened', function (e, $dialog) {
                $('#myGrid').fanexGrid(data);
            });
        }
    }
})(angular);