(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('virtualSportsSportsbookDetailService', virtualSportsSportsbookDetailService);

    virtualSportsSportsbookDetailService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function virtualSportsSportsbookDetailService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getMatchDetailTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate,
                sportType: data.sportType,
                betType: data.betType,
                normalMode: data.normalMode
            };
            var url = 'api/house-win-loss-by-products/' + companyWinlossService.resolveProductPath(data.productName) + '/sportsbook-match-detail';
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
                betType: data.betType,
                normalMode: data.normalMode
            };
            var url = 'api/house-win-loss-by-products/' + companyWinlossService.resolveProductPath(data.productName) + '/sportsbook-match-detail/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();