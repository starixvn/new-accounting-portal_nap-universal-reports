(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .directive('napBetType', napBetType);

    napBetType.$inject = ['$controller'];
    function napBetType($controller) {
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
                'Number Game': {
                    templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                    controller: 'NumberGameBetTypeController'
                }
            };

            $scope.$on('generate', function (event, level) {
                if (level === levels.BET_TYPE) {
                    $timeout(function () {
                        generate();
                    });
                }
            });

            $scope.$on('show', function (event, level) {
                if (level === levels.BET_TYPE) {
                    companyWinlossService.filterModel.updateDateRange(dateRange);
                    currentScope.show();
                }
            });

            function generate() {
                var gridModel = companyWinlossService.gridModel;
                var productSetting = productConfig[gridModel.productName];
                $templateRequest(productSetting.templateUrl, true).then(function (response) {
                    var templateScope = $scope.$new();
                    var templateElement = $element.children().html(response);
                    var templateCtrl = $controller(productSetting.controller, { $scope: templateScope, $element: templateElement });
                    templateElement.data('$ngControllerController', templateCtrl);
                    $compile(templateElement.contents())(templateScope, function (clonedElement, scope) {
                        scope.generate();
                    });
                });
            }
        }
    }
})();