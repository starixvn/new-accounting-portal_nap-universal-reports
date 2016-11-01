import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.numberGame2StatisticApp')
        .directive('napTab', napTab);

    napTab.$inject = ['napPane'];
    function napTab(Pane) {
        var directive = {
            restrict: 'EA',
            scope: {
                panes: '='
            },
            templateUrl: 'app/ng2-statistic/tab/tab.directive.html',
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
            tab.panes = [];
            var mainPane = new Pane(data);
            tab.addPane(mainPane);
                        
        });

        $scope.$on('nap-filter-switch', function (event) {
            tab.panes = [];
        });
    }
})(angular);