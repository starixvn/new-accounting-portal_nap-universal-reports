(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('numberGameMatchDetailService', numberGameMatchDetailService);

    numberGameMatchDetailService.$inject = ['$http', 'httpResponseService', 'companyWinlossService'];
    function numberGameMatchDetailService($http, httpResponseService, companyWinlossService) {
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
                betType: data.betType
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/match-detail';
            return $http.post(url, httpData)
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
                betType: data.betType
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/match-detail/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);