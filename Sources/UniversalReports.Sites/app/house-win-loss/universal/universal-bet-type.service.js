import angular from "angular";
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

        function getData(data) {
            var httpData = {                
                productId: universalSettings.getProductId(data.productName)
            };
            angular.extend(httpData, data);
            var url = 'api/house-win-loss-by-products/universal/bet-type';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,                
                productId: universalSettings.getProductId(data.productName)
            };
            angular.extend(httpData, data);
            var url = 'api/house-win-loss-by-products/universal/bet-type/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);