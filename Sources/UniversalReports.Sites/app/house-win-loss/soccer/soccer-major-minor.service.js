import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.houseWinlossApp')
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
                return data.productName + ' ' + "MAJOR/MINOR";
            }
            else {
                var liveNonLive = (data.isLive == soccerConstants.Live) ? "LIVE" : "NON-LIVE";

                return data.productName + ' ' + liveNonLive;
            }
        }

        function getData(data) {            
            return $http.post('api/house-win-loss-by-products/soccer/major-minor', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title
            };
            angular.extend(httpData, data);
            return $http.post('api/house-win-loss-by-products/soccer/major-minor/excel', httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);