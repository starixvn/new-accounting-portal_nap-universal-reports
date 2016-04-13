(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('betTypeLiveService', betTypeLiveService);

    betTypeLiveService.$inject = ['$http', 'httpResponseService'];
    function betTypeLiveService($http, httpResponseService) {
        var service = {
            getData: getData,
            exportExcel: exportExcel
        };

        return service;

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate,
                sportType: data.sportType,
                isLive: data.isLive
            };
            var url = 'api/company-win-loss/' + data.productName.replace(/\s+/g, '-') + '/bet-type';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                startDate: data.startDate,
                endDate: data.endDate,
                sportType: data.sportType,
                isLive: data.isLive
            };
            var url = 'api/company-win-loss/' + data.productName.replace(/\s+/g, '-') + '/bet-type/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);