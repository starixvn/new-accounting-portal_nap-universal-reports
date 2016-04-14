(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('soccerLiveNonLiveService', soccerLiveNonLiveService);

    soccerLiveNonLiveService.$inject = ['$http', 'httpResponseService'];
    function soccerLiveNonLiveService($http, httpResponseService) {
        var service = {
            getData: getData,
            exportExcel: exportExcel
        };

        return service;

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate
            };
            return $http.post('api/company-win-loss/soccer/live-nonlive', httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(liveTitle, nonLiveTitle, data, fileName) {
            var httpData = {
                liveTitle: liveTitle,
                nonLiveTitle: nonLiveTitle,
                startDate: data.startDate,
                endDate: data.endDate
            };
            return $http.post('api/company-win-loss/soccer/live-nonlive/excel', httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);