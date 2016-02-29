(function () {
    'use strict';

    angular
        .module('app.core')
        .directive('napHeader', napHeader);

    function napHeader() {
        var directive = {
            restrict: 'EA',
            scope: {},
            templateUrl: 'app/components/header/header.directive.html',
            replace: true,
            controller: controller,
            controllerAs: 'vm',
            bindToController: true
        };
        return directive;

        controller.$inject = ['headerService'];
        function controller(headerService) {

            /*jshint validthis: true */
            var vm = this;
            headerService.getData().then(function (data) {
                vm.username = data.Username;
                vm.menus = headerService.getCompiledMenu(data.Menus);
            });
        }
    }
})();