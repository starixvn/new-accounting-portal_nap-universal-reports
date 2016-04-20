(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('sportsbookMatchDetailService', sportsbookMatchDetailService);

    sportsbookMatchDetailService.$inject = ['$http', 'httpResponseService', 'titleService', 'legacyService'];
    function sportsbookMatchDetailService($http, httpResponseService, titleService, legacyService) {
        var service = {
            getTitle: titleService.getMatchDetailTitle,
            getMatchInformation: getMatchInformation,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getMatchInformation(data) {
            var httpData = {
                matchId: data.matchId,
                betType: data.betType
            };

            var url = legacyService.resolveUrl('/ScoreInformation/GetScoreInformation');
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function getData(data) {
            var httpData = {
                isLive: data.isLive,
                isHedge: data.isHedge,
                sportType: data.sportType,
                betType: data.betType,
                startDate: data.startDate,
                endDate: data.endDate
            };

            var url = 'api/company-win-loss/sportsbook/match-detail';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                isLive: data.isLive,
                isHedge: data.isHedge,
                sportType: data.sportType,
                betType: data.betType,
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/sportsbook/match-detail/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);