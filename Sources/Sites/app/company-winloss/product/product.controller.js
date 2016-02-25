(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('ProductController', ProductController);

    ProductController.$inject = ['$compile', '$timeout', '$element', '$scope', 'formatStrings', 'productService', 'fanexGridHelper', 'levels', 'levelSettings', 'companyWinlossService', 'breadcrumbHelper'];
    function ProductController($compile, $timeout, $element, $scope, formatStrings, productService, fanexGridHelper, levels, levelSettings, companyWinlossService, breadcrumbHelper) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateProduct = generateProduct;

        function generateProduct(productName) {
            var templates = levelSettings[productName].templates;
            var firstTemplate = templates[0];
            companyWinlossService.generate({
                level: firstTemplate.level,
                productName: productName
            });
        };

        function generate() {
            productService.getData().then(function (data) {
                createLinks(data);
                renderGrid(data);
                compileLinks();
            });
        }

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function renderGrid(data) {
            var titleInfo = {
                text: breadcrumbHelper.generateHtml($scope),
                showCollapseExpandButton: true,
                showExcelButton: true,
                exportExcelFunction: exportExcel
            };

            data.titleInfo = titleInfo;
            data.defaultCollapseAllGroups = true;
            data.gridExpandHeight = fanexGridHelper.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function createLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var productRow = data.bodyRows[i];
                if (angular.isDefined(productRow.SubRows)) {
                    var productName = productRow.Columns[0].Value;
                    var isSportsbookTotal = productName === 'Sportsbook Total';
                    if (!isSportsbookTotal) {
                        productRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateProduct(\'' + productName.replace('\'', '\\\'') + '\')">' + productName + '</a>';
                    }
                }
            }
        }

        function compileLinks() {
            breadcrumbHelper.compile($element);
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);
        }

        function exportExcel() {
        }
    }
})();