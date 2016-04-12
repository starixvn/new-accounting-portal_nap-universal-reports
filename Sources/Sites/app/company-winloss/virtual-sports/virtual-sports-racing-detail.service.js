(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('virtualSportsRacingDetailService', virtualSportsRacingDetailService);

    virtualSportsRacingDetailService.$inject = ['$http', 'httpResponseService'];
    function virtualSportsRacingDetailService($http, httpResponseService) {
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

            return $http.post('/api/company-win-loss/virtual-sports/racing-match-detail', httpData)
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

            return $http.post('/api/company-win-loss/virtual-sports/racing-match-detail/excel', httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();