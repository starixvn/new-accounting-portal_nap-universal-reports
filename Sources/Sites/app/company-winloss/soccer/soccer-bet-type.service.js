(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('soccerBetTypeService', soccerBetTypeService);

    soccerBetTypeService.$inject = ['$http', 'httpResponseService'];
    function soccerBetTypeService($http, httpResponseService) {
        var service = {
            getTitle: getTitle,
            getData: getData,
            exportExcel: exportExcel
        };

        return service;

        function getTitle(data, isLast) {
            var majorMinor = (data.isMajor) ? "-MAJOR" : "-MINOR";
            if (data.isLive == 2) {
                return data.productName + majorMinor + ' BET TYPES PRODUCT WIN/LOSS REPORT';
            }
            else {
                var liveNonLive = (data.isLive == 1) ? '"LIVE"' : '"NON-LIVE"';
                return data.productName + majorMinor + " BET TYPES " + liveNonLive + " PRODUCT WIN/LOSS REPORT";
            }
        }

        function getData(data) {
            var isMajor = data.betTypeNameMajorMinor == "Soccer-Major Bet Types" ? true : false;
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate,
                isLive: data.isLive,
                isMajor: data.isMajor
            };

            var url = "api/company-win-loss/soccer/bettype";
            if (data.isMajor && data.isLive == 2) {
                url = "api/company-win-loss/soccer/sum-bettype";
            }
            else if (data.isMajor && data.isLive == 0) {
                url = "api/company-win-loss/soccer/group-bettype";
            }

            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(liveTitle, nonLiveTitle, data, fileName) {
            var httpData = {
                liveTitle: liveTitle,
                nonLiveTitle: nonLiveTitle,
                startDate: data.startDate,
                endDate: data.endDate,
                isLive: data.isLive,
                isMajor: data.isMajor
            };
            return $http.post('api/company-win-loss/soccer/sum-bettype/excel', httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);