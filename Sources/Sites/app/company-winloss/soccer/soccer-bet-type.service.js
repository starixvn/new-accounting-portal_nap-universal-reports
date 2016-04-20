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
            if (isMajor && isLive == 2) {
                url = "api/company-win-loss/soccer/sum-bettype";
            }
            else if (isMajor && isLive == 0) {
                url = "api/company-win-loss/soccer/group-bettype";
            }

            return url;
        }
    }
})(angular);