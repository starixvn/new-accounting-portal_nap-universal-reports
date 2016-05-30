(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('soccerMajorMinorService', soccerMajorMinorService);

    soccerMajorMinorService.$inject = ['$http', 'httpResponseService', 'soccerConstants'];
    function soccerMajorMinorService($http, httpResponseService, soccerConstants) {
        var service = {
            getTitle: getTitleWhenMajorMinor,
            getData: getData,
            exportExcel: exportExcel
        };

        return service;

        function getTitleWhenMajorMinor(data) {
            if (data.isLive == soccerConstants.LiveNonLive)
            {
                return data.productName;
            }
            else {
                var liveNonLive = (data.isLive == soccerConstants.Live) ? "LIVE" : "NON-LIVE";

                return data.productName + ' ' + liveNonLive;
            }
        }

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate,
                isLive: data.isLive
            };
            
            return $http.post('api/company-win-loss/soccer/major-minor', httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                startDate: data.startDate,
                endDate: data.endDate
            };
            return $http.post('api/company-win-loss/soccer/major-minor/excel', httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);