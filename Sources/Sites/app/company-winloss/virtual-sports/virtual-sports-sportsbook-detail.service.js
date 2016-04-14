(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('virtualSportsSportsbookDetailService', virtualSportsSportsbookDetailService);

    virtualSportsSportsbookDetailService.$inject = ['$http', 'httpResponseService', 'companyWinlossService'];
    function virtualSportsSportsbookDetailService($http, httpResponseService, companyWinlossService) {
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
                betType: data.betType
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/sportsbook-match-detail';
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
                betType: data.betType
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/sportsbook-match-detail/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();