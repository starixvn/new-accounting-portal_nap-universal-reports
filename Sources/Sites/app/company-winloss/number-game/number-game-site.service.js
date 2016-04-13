(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('numberGameSiteService', numberGameSiteService);

    numberGameSiteService.$inject = ['$http', 'httpResponseService'];
    function numberGameSiteService($http, httpResponseService) {
        var service = {
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate,
                sportType: 161,
                isLive: data.isLive,
                betType: data.betType,
                site: data.site
            };
            return $http.post('api/company-win-loss/number-game/site', httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                startDate: data.startDate,
                endDate: data.endDate,
                sportType: 161,
                isLive: data.isLive,
                betType: data.betType,
                site: data.site
            };
            return $http.post('api/company-win-loss/number-game/site/excel', httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);