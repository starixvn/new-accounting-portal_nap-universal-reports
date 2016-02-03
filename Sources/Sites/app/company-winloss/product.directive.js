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
            template: '<div></div>',
            controller: controller,
            controllerAs: 'vm',
            bindToController: true
        };
        return directive;

        controller.$inject = ['$compile', '$timeout', '$element', '$scope', 'config', 'levels', '$templateRequest', 'companyWinlossService'];
        function controller($compile, $timeout, $element, $scope, config, levels, $templateRequest, companyWinlossService) {
            var dateRange;
            var currentScope;
            var vm = this;

            var productConfig = {
                'Number Game': {
                    templateUrl: 'app/company-winloss/number-game/number-game.html',
                    controller: 'NumberGameController'
                },
                'Live Casino': {
                    templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                    controller: 'LiveCasinoController'
                }
            };

            $scope.$on('generate', function (event, data) {
                if (data.level === levels.PRODUCT) {
                    $timeout(function () {
                        generate(data.product);
                    });
                }
            });

            $scope.$on('show', function (event, data) {
                if (data.level === levels.PRODUCT) {
                    $timeout(function () {
                        companyWinlossService.filterModel.updateDateRange(dateRange);
                        currentScope.show();
                    });
                }
            });

            function generate(product) {
                var productSetting = productConfig[product];
                $templateRequest(productSetting.templateUrl, true).then(function (response) {
                    var templateScope = $scope.$new();
                    var templateElement = $element.children().html(response);
                    var templateCtrl = $controller(productSetting.controller, { $scope: templateScope, $element: templateElement });
                    templateElement.data('$ngControllerController', templateCtrl);
                    $compile(templateElement.contents())(templateScope, function (clonedElement, scope) {
                        currentScope = scope;
                        dateRange = companyWinlossService.filterModel.getDateRange();
                        currentScope.generate(dateRange.startDate, dateRange.endDate);
                    });
                });
            }
        }
    }
})();