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
            controller: ['headerService', 'config', controller],
            controllerAs: 'vm',
            bindToController: true
        };
        return directive;

        function controller(headerService, config) {
            /*jshint validthis: true */
            var vm = this;
            vm.userProfileUrl = resolveUrl('/UserControl/User/UserProfile');
            vm.changePasswordUrl = resolveUrl('/UserControl/User/ChangePassword');
            vm.logOutUrl = resolveUrl('/UserLogin/Login/LogOut');

            headerService.getData().then(function (data) {
                vm.username = data.Username;
                vm.menus = headerService.getCompiledMenu(data.Menus);
            });

            function resolveUrl(url) {
                return config.legacyPath + url;
            }
        }
    }
})();