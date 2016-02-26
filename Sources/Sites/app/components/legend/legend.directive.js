(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .directive('napLegend', napLegend);

    function napLegend() {
        var directive = {
            restrict: 'EA',
            scope: {
                legend: '='
            },
            replace: true,
            controller: controller,
            controllerAs: 'vm',
            bindToController: true
        };
        return directive;

        controller.$inject = ['$element', 'legendService'];
        function controller($element, legendService) {
            var vm = this;
            legendService.getData(vm.legend).then(function (response) {
                $element.html(response);
            });
        }
    }
})();