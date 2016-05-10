(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('CasinoProductViewBetTypeService', CasinoProductViewBetTypeService);

    CasinoProductViewBetTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function CasinoProductViewBetTypeService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getCasinoProductTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                productId: data.casinoProductId,
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
                productId: data.productId,
                startDate: data.startDate,
                endDate: data.endDate
            };

            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/product/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);