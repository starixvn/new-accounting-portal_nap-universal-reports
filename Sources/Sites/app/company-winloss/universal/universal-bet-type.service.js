(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('universalBetTypeService', universalBetTypeService);

    universalBetTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService', 'universalSettings'];
    function universalBetTypeService($http, httpResponseService, companyWinlossService, titleService, universalSettings) {
        var products = new Array();
        products["Bingo"] = 7;
        products["Keno"] = 8;
        products["Colossus Bets"] = 15;

        var service = {
            getTitle: titleService.getProductTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;


        function getServiceUrl(data) {
            return data.productName == 'Bettrade'
                ? 'api/company-win-loss/bettrade'
                : 'api/company-win-loss/universal';
        }

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate,
                productId: universalSettings.getProductId(data.productName)
            };
            var url = getServiceUrl(data) + '/bet-type';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                startDate: data.startDate,
                endDate: data.endDate,
                productId: universalSettings.getProductId(data.productName)
            };
            var url = getServiceUrl(data) + '/bet-type/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);