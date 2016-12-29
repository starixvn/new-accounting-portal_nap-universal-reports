import angular from "angular";
import numeral from "numeral";
import moment from "moment";
(function (angular) {
    'use strict';

    angular
        .module('app.ng2StatisticsApp')
        .controller('CommonController', CommonController);

    CommonController.$inject = ['$rootScope', '$element', '$scope', 'fanexGridService', 'ngDialog', '$injector', 'grandtotalService'];
    function CommonController($rootScope, $element, $scope, fanexGridService, ngDialog, $injector, grandtotalService) {
        var pane = $scope.pane;
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.generateCurrencyReport = generateCurrencyReport;
        $scope.generateGrandtotalReport = generateGrandtotalReport;


        function generateCurrencyReport(currency, dateCurrency) {
            var data = {};
            angular.extend(data, pane.data);
            angular.extend(data, {
                drilldownType: "Currency",
                currency: pane.data.currency === -1 ? -1: currency,
                currencyName: pane.data.currencyName,
                startDate: moment.utc(dateCurrency).startOf('day'),
                endDate: moment.utc(dateCurrency).startOf('day'),
                isDrilldown: true
            }
            );
            tab.goForward(data);
        }

        function generateGrandtotalReport() {

            var model = {
                drilldownType: "Grandtotal",
                currency: pane.data.currency,
                currencyName: pane.data.currencyName,
                isDrilldown: true,
                endDate: pane.data.endDate,
                startDate: pane.data.startDate,
                betType: pane.data.betType,
                username: pane.data.username,
                balanceUpDate: pane.data.balanceUpDate
            };

            grandtotalService.getData(model).then(function (data) {
                renderPopup(model, data);
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
            data.pagerOption = {
                itemsPerPage: 50,
                currentPage: 0,
                itemsPerPageArray: [50, 100, 200, 500],
                totalItem: data.bodyRows.length
            };
            data.sortOption = sortOptions;
            data.gridHeight = 575;
            data.fullHeight = false;
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
                    var currencyColumn = row.Columns.length === 12 ? row.Columns[3] : row.Columns[2];
                    var date = row.Columns.length === 12 ? row.Columns[0].Value : row.Columns[1].CustomAttr;

                    currencyColumn.Value = '<a class="drill-down" href data-nap-click="generateCurrencyReport(\'' + currencyColumn.CustomAttr + '\',\''
                                                                                                                + date + '\')">'
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
            var title = grandtotalService.getTitle(pane.data);
            grandtotalService.exportExcel(title, pane.data, pane.getFileName());
        }

        function renderPopup(model, data) {

            var titleInfo = {
                text: grandtotalService.getTitle(model),
                showExcelButton: true,
                exportExcelFunction: exportExcelGrandTotal
            };

            data.titleInfo = titleInfo;
            ngDialog.open({
                template: 'templateId',
                plain: false,
                width: 1245,
                height: 650,
                closeByDocument: false,
                data: data
            });

            $rootScope.$on('ngDialog.opened', function (e, $dialog) {
                data.gridHeight = 575;
                data.fullHeight = false;
                $('#myGrid').fanexGrid(data);
            });
        }
    }
})(angular);