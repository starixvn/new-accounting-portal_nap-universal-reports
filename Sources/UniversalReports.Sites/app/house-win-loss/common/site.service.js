import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.houseWinlossApp')
        .factory('siteService', siteService);

    siteService.$inject = ['$http', 'httpResponseService', 'houseWinlossService', 'titleService'];
    function siteService($http, httpResponseService, houseWinlossService, titleService) {
        var service = {
            getTitle: titleService.getSiteTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                sportType: data.sportType,
                betType: data.betType,
                site: data.site,
                startDate: data.startDate,
                endDate: data.endDate,
                normalMode: data.normalMode
            };
            var url = 'api/house-win-loss-by-products/' + houseWinlossService.resolveProductPath(data.productName) + '/site';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                sportType: data.sportType,
                betType: data.betType,
                site: data.site,
                startDate: data.startDate,
                endDate: data.endDate,
                normalMode: data.normalMode
            };
            var url = 'api/house-win-loss-by-products/' + houseWinlossService.resolveProductPath(data.productName) + '/site/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);