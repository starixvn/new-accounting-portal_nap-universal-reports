(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .directive('napProduct', napProduct);

    napProduct.$inject = ['$controller'];
    function napProduct($controller) {
        var directive = {
            restrict: 'EA',
            scope: {},
            controller: controller
        };
        return directive;

        controller.$inject = ['$compile', '$timeout', '$element', '$scope', '$templateRequest', 'config', 'levels', 'levelSettings', 'companyWinlossService'];
        function controller($compile, $timeout, $element, $scope, $templateRequest, config, levels, levelSettings, companyWinlossService) {
            var dateRange,
                currentScope;

            $scope.$on('generate', function (event, level) {
                if (level === levels.PRODUCT) {
                    $timeout(function () {
                        dateRange = companyWinlossService.filterModel.getDateRange();
                        generate();
                    });
                }
            });

            $scope.$on('show', function (event, level) {
                if (level === levels.PRODUCT) {
                    $timeout(function () {
                        companyWinlossService.filterModel.updateDateRange(dateRange);
                        currentScope.show();
                    });
                }
            });

            function generate() {
                var gridModel = companyWinlossService.gridModel;
                var productSetting = levelSettings[gridModel.productName].product;
                $templateRequest(productSetting.templateUrl, true).then(function (response) {
                    var templateScope = $scope.$new();
                    var templateElement = $element.html(response);
                    var templateCtrl = $controller(productSetting.controller, { $scope: templateScope, $element: templateElement });
                    templateElement.data('$ngControllerController', templateCtrl);
                    $compile(templateElement.contents())(templateScope, function (clonedElement, scope) {
                        if (currentScope) {
                            currentScope.$destroy();
                            currentScope = null;
                        }

                        currentScope = scope;
                        currentScope.generate();
                    });
                });
            }
        }
    }
})();