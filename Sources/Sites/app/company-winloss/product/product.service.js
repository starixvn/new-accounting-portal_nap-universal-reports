(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('productService', productService);

    productService.$inject = ['$http', 'httpResponseService', 'companyWinlossService'];
    function productService($http, httpResponseService, companyWinlossService) {
        var service = {
            getData: getData
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };

            return $http.post('/api/company-win-loss/values', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }
    }
})();