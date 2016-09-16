import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .directive('napTab', napTab);

    napTab.$inject = ['napPane'];
    function napTab(Pane) {
        var directive = {
            restrict: 'EA',
            scope: {
                panes: '='
            },
            templateUrl: 'app/house-win-loss/tab/tab.directive.html',
            controller: controller,
            controllerAs: 'vm',
            bindToController: true
        };
        return directive;
    }

    controller.$inject = ['$scope', '$rootScope', 'napTab', 'napPane'];
    function controller($scope, $rootScope, Tab, Pane) {
        var tab = new Tab($scope.panes);
        var vm = this;
        vm.tab = tab;

        $scope.$on('nap-filter-generate', function (event, data) {
            if (tab.panes.length === 0) {
                var mainPane = new Pane('product', data);
                tab.addPane(mainPane);
            } else {
                var activePane = tab.getActivePane();
                angular.extend(activePane.data, data);
                activePane.generate();
            }
        });

        $scope.$on('nap-filter-switch', function (event) {
            tab.panes = [];
        });
    }
})(angular);