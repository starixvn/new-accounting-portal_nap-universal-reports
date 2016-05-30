(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('soccerLiveNonLiveService', soccerLiveNonLiveService);

    soccerLiveNonLiveService.$inject = ['$http', 'httpResponseService'];
    function soccerLiveNonLiveService($http, httpResponseService) {
        var service = {
            getTitle: getTitleWhenLiveNonLive,
            getData: getData,
            exportExcel: exportExcel
        };

        return service;


        function getTitleWhenLiveNonLive(data, isLast) {
            return isLast ?
                data.productName + ' LIVE/NON-LIVE' :
                data.productName;
        }


        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate
            };
            return $http.post('api/company-win-loss/soccer/live-nonlive', httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
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