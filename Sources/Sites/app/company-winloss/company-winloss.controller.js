(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('CompanyWinlossController', CompanyWinlossController);

    CompanyWinlossController.$inject = ['$scope', 'levels', 'companyWinlossService'];
    function CompanyWinlossController($scope, levels, companyWinlossService) {
        companyWinlossService.scope = $scope;
        companyWinlossService.gridModel = this;
        var vm = this;
        vm.level = levels.PRODUCT;
        vm.levels = levels;
    }
})();