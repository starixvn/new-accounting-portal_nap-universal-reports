(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('soccerMajorMinorService', soccerMajorMinorService);

    soccerMajorMinorService.$inject = ['$http', 'httpResponseService'];
    function soccerMajorMinorService($http, httpResponseService) {
        var service = {
            getTitle: getTitleWhenMajorMinor,
            getData: getData,
            exportExcel: exportExcel
        };

        return service;

        function getTitleWhenMajorMinor(data, isLast) {
            if (data.isLive == 2)
            {
                return isLast ?
                    data.productName + ' MAJOR/MINOR BET TYPES' :
                    data.productName;
            }
            else {
                var liveNonLive = (data.isLive == 1) ? "LIVE" : "NON-LIVE";

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

        function exportExcel(liveTitle, nonLiveTitle, data, fileName) {
            var httpData = {
                liveTitle: liveTitle,
                nonLiveTitle: nonLiveTitle,
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