(function () {
    'use strict';

    angular
        .module('app.core')
        .directive('napLoading', napLoading);

    function napLoading() {
        var directive = {
            restrict: 'EA',
            scope: {},
            template: '<div class="loading-container" data-ng-show="vm.isLoading"><div class="block-overlay"></div><div class="block-loading"></div></div>',
            replace: true,
            controller: controller,
            controllerAs: 'vm',
            bindToController: true
        };
        return directive;

        controller.$inject = ['$scope'];
        function controller($scope) {
            var vm = this;
            vm.isLoading = false;

            $scope.$on('loading-started', function () {
                vm.isLoading = true;
            });

            $scope.$on('loading-complete', function () {
                vm.isLoading = false;
            });
        }
    }
})();