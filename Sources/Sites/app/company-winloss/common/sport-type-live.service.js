(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('sportTypeLiveService', sportTypeLiveService);

    sportTypeLiveService.$inject = ['$http', 'httpResponseService'];
    function sportTypeLiveService($http, httpResponseService) {
        var service = {
            getData: getData,
            exportExcel: exportExcel
        };

        return service;

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate,
                isLive: data.isLive
            };
            var url = 'api/company-win-loss/' + data.productName.replace(/\s+/g, '-') + '/sport-type';
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
            var url = 'api/company-win-loss/' + data.productName.replace(/\s+/g, '-') + '/sport-type/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);