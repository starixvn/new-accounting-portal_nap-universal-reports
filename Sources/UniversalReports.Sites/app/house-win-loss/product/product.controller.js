import angular from "angular";
import numeral from "numeral";
(function (angular) {
    'use strict';

    angular
        .module('app.houseWinlossApp')
        .controller('ProductController', ProductController);

    ProductController.$inject = ['$element', '$scope', 'fanexGridService', 'houseWinlossService', 'productShowHideColumnService'];
    function ProductController($element, $scope, fanexGridService, houseWinlossService, productShowHideColumnService) {
        var pane = $scope.pane;
        var showHideColumnBuilder = new productShowHideColumnService.Builder(pane);
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.show = showHideColumnBuilder.toggle;
        $scope.generate = generate;
        $scope.generateProduct = generateProduct;

        function generateProduct(productName) {
            var data = {
                productName: productName
            };
            angular.extend(data, pane.data);
            var level = houseWinlossService.getTemplateSetting(productName)['product'];
            tab.goForward(level, data);
        }

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                showHideColumnBuilder.build(gridElement, data);
                createLinks(data);
                renderGrid(data);
                pane.compileAll();
            });
        }

        function renderGrid(data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showCollapseExpandButton: true,
                showExcelButton: true,
                exportExcelFunction: exportExcel,
                customButtons: showHideColumnBuilder.getButtonHtml()
            };

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            data.bottomBorderWidth = 3;
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