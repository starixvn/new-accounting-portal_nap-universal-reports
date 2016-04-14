(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('ProductController', ProductController);

    ProductController.$inject = ['$element', '$scope', 'fanexGridService', 'templateSetting'];
    function ProductController($element, $scope, fanexGridService, templateSetting) {
        var enableHiddenColumns = false;
        var hiddenColumns = [1, 2];
        var gridOptions;
        var pane = $scope.pane;
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.generateProduct = generateProduct;
        $scope.showHideColumns = showHideColumns;

        function showHideColumns() {
            if (enableHiddenColumns) {
                gridElement.fanexGrid("hideColumns", gridOptions, hiddenColumns);
            } else {
                gridElement.fanexGrid("hideColumns", gridOptions, []);
            }
            enableHiddenColumns = !enableHiddenColumns;
        }

        function generateProduct(productName) {
            var data = {
                productName: productName
            };
            angular.extend(data, pane.data);
            var level = templateSetting[productName]['product'];
            tab.goForward(level, data);
        }

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                gridOptions = data;
                createLinks(data);
                renderGrid(data);
                pane.compileLinks();
            });
        }

        function renderGrid(data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showCollapseExpandButton: true,
                showExcelButton: true,
                exportExcelFunction: exportExcel,
                customButtons: '<input type="button" class="btn-show-hide nap-component" title="Show/Hide" data-ng-click="showHideColumns()" />'
            };

            data.titleInfo = titleInfo;
            data.defaultCollapseAllGroups = true;
            data.hiddenColumns = hiddenColumns;
            data.enableHiddenColumns = enableHiddenColumns;
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function createLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var productRow = data.bodyRows[i];
                var customAttr = productRow.CustomAttr;
                if (customAttr === 'product') {
                    var productName = productRow.Columns[0].Value;
                    productRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateProduct(\'' + productName.replace('\'', '\\\'') + '\')">' + productName + '</a>';
                }
            }
        }

        function exportExcel() {
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane.data, pane.getFileName());
        }
    }
})(angular);