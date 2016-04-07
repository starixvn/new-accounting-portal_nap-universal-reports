(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('ProductController', ProductController);

    ProductController.$inject = ['$element', '$scope', 'fanexGridService'];
    function ProductController($element, $scope, fanexGridService) {
        var pane = $scope.pane;
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.generateProduct = generateProduct;

        function generateProduct(productName) {
            var data = {
                productName: productName
            };
            angular.extend(data, pane.data);
            tab.goForward('product', data);
        };

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
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
                exportExcelFunction: exportExcel
            };

            data.titleInfo = titleInfo;
            data.defaultCollapseAllGroups = true;
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