(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('casinoProductService', casinoProductService);

    casinoProductService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function casinoProductService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getProductTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate,
                casinoType: data.productName == 'Casino' ? 1 : 2
            };

            var url = 'api/company-win-loss/casino/product';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                startDate: data.startDate,
                endDate: data.endDate
            };

            var url = 'api/company-win-loss/casino/product/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);