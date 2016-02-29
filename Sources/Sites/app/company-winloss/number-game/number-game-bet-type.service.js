(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('numberGameBetTypeService', numberGameBetTypeService);

    numberGameBetTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService'];
    function numberGameBetTypeService($http, httpResponseService, companyWinlossService) {
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