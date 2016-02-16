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

        controller.$inject = ['$log', '$compile', '$timeout', '$element', '$scope', 'config', 'levels', 'levelSettings', '$templateRequest', 'companyWinlossService'];
        function controller($log, $compile, $timeout, $element, $scope, config, levels, levelSettings, $templateRequest, companyWinlossService) {
            var dateRange,
                currentScope;

            $scope.$on('generate', function (event, level) {
                if ($scope.level === level) {
                    $timeout(function () {
                        dateRange = companyWinlossService.filterModel.getDateRange();
                        generate();
                    });
                }
            });

            $scope.$on('show', function (event, level) {
                if ($scope.level === level) {
                    $timeout(function () {
                        companyWinlossService.filterModel.updateDateRange(dateRange);
                        currentScope.show();
                    });
                }
            });

            function generate() {
                var gridModel = companyWinlossService.gridModel;
                var levelSetting = undefined;
                switch ($scope.level) {
                    case levels.PRODUCT:
                        levelSetting = levelSettings.product;
                        break;

                    case levels.SPORT_TYPE:
                        levelSetting = levelSettings[gridModel.productName].sportType;
                        break;

                    case levels.BET_TYPE:
                        levelSetting = levelSettings[gridModel.productName].betType;
                        break;

                    case levels.SITE:
                        levelSetting = levelSettings[gridModel.productName].site;
                        break;

                    case levels.DETAIL:
                        levelSetting = levelSettings[gridModel.productName].detail;
                        break;
                }

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