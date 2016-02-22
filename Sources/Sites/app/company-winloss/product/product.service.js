(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('productService', productService);

    productService.$inject = ['$http', 'httpResponseService'];
    function productService($http, httpResponseService) {
        var service = {
            getData: getData
        };
        return service;

        function getData(startDate, endDate) {
            var data = { startDate: startDate, endDate: endDate };
            return $http.post('/api/company-win-loss/values', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }
    }
})();