(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('thirdPartyBetTypeService', thirdPartyBetTypeService);

    thirdPartyBetTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService'];
    function thirdPartyBetTypeService($http, httpResponseService, companyWinlossService) {
        var service = {
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                productId: data.thirdPartyProduct,
                startDate: data.startDate,
                endDate: data.endDate
            };

            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/bet-type';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                productId: data.thirdPartyProduct,
                startDate: data.startDate,
                endDate: data.endDate
            };

            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/third-party-product/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);