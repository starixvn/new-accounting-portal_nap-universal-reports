(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('soccerBetTypeService', soccerBetTypeService);

    soccerBetTypeService.$inject = ['$http', 'httpResponseService', 'soccerConstants'];
    function soccerBetTypeService($http, httpResponseService, soccerConstants) {
        var service = {
            getTitle: getTitle,
            getData: getData,
            exportExcel: exportExcel
        };

        return service;

        function getTitle(data) {
            var majorMinor = buildMajorFlag(data) ? "-MAJOR" : "-MINOR";
            if (data.isLive == soccerConstants.LiveNonLive) {
                return data.productName + majorMinor + ' BET TYPES';
            }
            else {
                var liveNonLive = (data.isLive == soccerConstants.Live) ? '"LIVE"' : '"NON-LIVE"';
                return data.productName + majorMinor + " BET TYPES " + liveNonLive;
            }
        }

        function getData(data) {
            var isMajor = buildMajorFlag(data);
            var isLive = data.isLive;

            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate,
                isLive: isLive,
                isMajor: isMajor
            };
            var url = buildUrl(isLive, isMajor);
            
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var isMajor = buildMajorFlag(data);
            var isLive = data.isLive;

            var httpData = {
                title: title,
                startDate: data.startDate,
                endDate: data.endDate,
                isLive: isLive,
                isMajor: isMajor
            };
            var url = buildUrl(isLive, isMajor) + '/excel';

            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }

        function buildMajorFlag(data)
        {
            return data.betTypeNameMajorMinor == "Soccer-Major Bet Types" ? true : false;
        }

        function buildUrl(isLive, isMajor)
        {
            var url = "api/company-win-loss/soccer/bettype";
            if (isMajor && isLive == soccerConstants.LiveNonLive) {
                url = "api/company-win-loss/soccer/sum-bettype";
            }
            else if (isMajor && isLive == soccerConstants.NonLive) {
                url = "api/company-win-loss/soccer/group-bettype";
            }

            return url;
        }
    }
})(angular);