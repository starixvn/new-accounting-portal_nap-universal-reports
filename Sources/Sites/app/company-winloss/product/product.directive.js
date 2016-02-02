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
            var vm = this;

            var productConfig = {
                'Live Casino': {
                    templateUrl: 'app/company-winloss/product/live-casino/live-casino.html',
                    controller: 'LiveCasinoController'
                },
                'Number Game': {
                    templateUrl: 'app/company-winloss/product/number-game/number-game.html',
                    controller: 'NumberGameController'
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
                    companyWinlossService.filterModel.updateDateRange(dateRange);
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
                        dateRange = companyWinlossService.filterModel.getDateRange();
                        scope.generate(dateRange.startDate, dateRange.endDate);
                    });
                });
            }
        }
    }
})();