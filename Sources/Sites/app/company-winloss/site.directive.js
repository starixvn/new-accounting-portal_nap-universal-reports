(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .directive('napSite', napSite);

    napSite.$inject = ['$controller'];
    function napSite($controller) {
        var directive = {
            restrict: 'EA',
            scope: {},
            controller: controller
        };
        return directive;

        controller.$inject = ['$compile', '$timeout', '$element', '$scope', 'config', 'levels', 'levelSettings', '$templateRequest', 'companyWinlossService'];
        function controller($compile, $timeout, $element, $scope, config, levels, levelSettings, $templateRequest, companyWinlossService) {
            var dateRange,
                currentScope;

            $scope.$on('generate', function (event, level) {
                if (level === levels.SITE) {
                    $timeout(function () {
                        dateRange = companyWinlossService.filterModel.getDateRange();
                        generate();
                    });
                }
            });

            $scope.$on('show', function (event, level) {
                if (level === levels.SITE) {
                    companyWinlossService.filterModel.updateDateRange(dateRange);
                    currentScope.show();
                }
            });

            function generate() {
                var gridModel = companyWinlossService.gridModel;
                var siteSetting = levelSettings[gridModel.productName].site;
                $templateRequest(siteSetting.templateUrl, true).then(function (response) {
                    var templateScope = $scope.$new();
                    var templateElement = $element.html(response);
                    var templateCtrl = $controller(siteSetting.controller, { $scope: templateScope, $element: templateElement });
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