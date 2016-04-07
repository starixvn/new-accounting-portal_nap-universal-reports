(function (angular) {
    'use strict';

    angular
        .module('app.core')
        .directive('napLegend', napLegend);

    function napLegend() {
        var directive = {
            restrict: 'EA',
            scope: {
                menuId: '='
            },
            replace: true,
            controller: ['$element', 'legendService', controller],
            controllerAs: 'vm',
            bindToController: true
        };
        return directive;

        function controller($element, legendService) {
            var vm = this;
            legendService.getData(vm.menuId).then(function (data) {
                $element.html(data.Content);
            });
        }
    }
})(angular);