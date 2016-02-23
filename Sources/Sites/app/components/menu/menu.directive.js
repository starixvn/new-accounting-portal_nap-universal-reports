(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .directive('napMenu', napMenu);

    function napMenu() {
        var directive = {
            restrict: 'EA',
            scope: {},
            templateUrl: 'app/components/menu/menu.directive.html',
            replace: true,
            controller: controller,
            controllerAs: 'vm',
            bindToController: true
        };
        return directive;

        controller.$inject = ['menuService'];
        function controller(menuService) {

            /*jshint validthis: true */
            var vm = this;
            menuService.getData().then(function (data) {
                vm.menus = data;
            });
        }
    }
})();