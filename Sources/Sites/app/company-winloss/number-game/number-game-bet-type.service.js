(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('numberGameService', numberGameService);

    numberGameService.$inject = ['$http', 'httpResponseService', 'companyWinlossService'];
    function numberGameService($http, httpResponseService, companyWinlossService) {
        var service = {
            getData: getData
        };

        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = { startDate: gridModel.startDate, endDate: gridModel.endDate };
            return $http.post('/api/company-win-loss/number-game/bet-type', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }
    }
})();