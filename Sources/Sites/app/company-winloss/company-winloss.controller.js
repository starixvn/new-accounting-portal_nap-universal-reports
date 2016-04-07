(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('CompanyWinlossController', CompanyWinlossController);

    CompanyWinlossController.$inject = [];
    function CompanyWinlossController() {
        var vm = this;
        vm.panes = [];
    }
})(angular);