(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('CompanyWinlossController', CompanyWinlossController);

    CompanyWinlossController.$inject = ['$scope', 'levels', 'companyWinlossService'];
    function CompanyWinlossController($scope, levels, companyWinlossService) {
        companyWinlossService.scope = $scope;
        companyWinlossService.gridModel = this;
        var vm = this;
        vm.level = levels.MAIN;
        vm.levels = levels;
        vm.generate = generate;

        function generate() {
            companyWinlossService.generate({});
        }
    }
})();