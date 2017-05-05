import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.core')
        .directive('napHeader', napHeader);

    function napHeader() {
        var directive = {
            restrict: 'EA',
            scope: {},
            templateUrl: 'app/root/components/header/header.directive.html',
            replace: true,
            controller: controller,
            controllerAs: 'vm',
            bindToController: true
        };
        return directive;
    }

    controller.$inject = ['headerService', 'legacyService'];
    function controller(headerService, legacyService) {
        /*jshint validthis: true */
        var vm = this;
        vm.userProfileUrl = legacyService.resolveUrl('/UserControl/User/UserProfile');
        vm.changePasswordUrl = legacyService.resolveUrl('/UserControl/User/ChangePassword');
        vm.logOutUrl = legacyService.resolveUrl('/UserLogin/Login/LogOut');
        vm.legacyUrl = napConfig.LegacyPath;

        headerService.getData().then(function (data) {
            vm.username = data.Username;
            vm.menus = headerService.getCompiledMenu(data.Menus);
        });
    }
})(angular);