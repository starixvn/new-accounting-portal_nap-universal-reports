(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('sportsbookSportTypeViewBetTypeService', sportsbookSportTypeViewBetTypeService);

    sportsbookSportTypeViewBetTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function sportsbookSportTypeViewBetTypeService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getSportTypeTitle,
            getData: getData,
            exportExcel: exportExcel
        };

        return service;

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate,
                sportType: data.sportType,
                isLive: data.isLive == undefined ? 2 : data.isLive
            };
            var url = getUrl(data);
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                startDate: data.startDate,
                endDate: data.endDate,
                sportType: data.sportType,
                isLive: data.isLive
            };
            var url = getUrl(data) + '/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
        
        function getUrl(data) {
            var url = null;
            if (data.sportType == 50) {
                url = 'api/company-win-loss/other-sports/new-cricket/bet-type';
            }
            else {
                url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/bet-type';
            }
            return url;
        }
    }
})(angular);