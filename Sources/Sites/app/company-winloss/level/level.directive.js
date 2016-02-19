(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .directive('napLevel', napSite);

    napSite.$inject = ['$controller'];
    function napSite($controller) {
        var directive = {
            restrict: 'EA',
            scope: {
                level: '='
            },
            controller: controller
        };
        return directive;

        controller.$inject = ['$log', '$compile', '$timeout', '$element', '$scope', 'levelService', '$templateRequest', 'companyWinlossService'];
        function controller($log, $compile, $timeout, $element, $scope, levelService, $templateRequest, companyWinlossService) {
            var currentScope;

            $scope.$on('generate', function (event, level) {
                if ($scope.level === level) {
                    $timeout(function () {
                        companyWinlossService.filterModel.reloadDateRange();
                        generate();
                    });
                }
            });

            $scope.$on('show', function (event, level) {
                if ($scope.level === level) {
                    $timeout(function () {
                        companyWinlossService.filterModel.reloadDateRange();
                        currentScope.show();
                    });
                }
            });

            function generate() {
                var gridModel = companyWinlossService.gridModel;
                var levelSetting = levelService.getSetting();
                if (angular.isUndefined(levelSetting)) {
                    $log.error('Product level setting is undefined');
                    return;
                }

                $templateRequest(levelSetting.templateUrl, true).then(function (response) {
                    var templateScope = $scope.$new();
                    var templateElement = $element.html(response);
                    var templateCtrl = $controller(levelSetting.controller, { $scope: templateScope, $element: templateElement });
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