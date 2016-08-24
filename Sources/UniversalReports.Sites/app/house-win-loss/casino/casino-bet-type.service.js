(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('CasinoBetTypeService', CasinoBetTypeService);

    CasinoBetTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function CasinoBetTypeService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getCasinoProductTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                productId: data.casinoProductId,
                normalMode: data.normalMode
            };
            angular.extend(httpData, data);
            var url = 'api/house-win-loss-by-products/casino/bet-type';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                productId: data.casinoProductId,
                normalMode: data.normalMode
            };
            angular.extend(httpData, data);
            var url = 'api/house-win-loss-by-products/casino/bet-type/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);