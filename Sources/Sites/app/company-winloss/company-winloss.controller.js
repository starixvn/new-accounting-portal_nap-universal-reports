(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('CompanyWinlossController', CompanyWinlossController);

    CompanyWinlossController.$inject = ['$scope'];
    function CompanyWinlossController($scope) {
        var vm = this;
        vm.generate = generate;

        function generate(startDate, endDate) {
            $scope.$broadcast('main', {
                startDate: startDate,
                endDate: endDate
            });
        }
    }
})();