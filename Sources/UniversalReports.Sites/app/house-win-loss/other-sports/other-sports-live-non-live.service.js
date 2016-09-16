import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('otherSportsLiveNonLiveService', otherSportsLiveNonLiveService);

    otherSportsLiveNonLiveService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function otherSportsLiveNonLiveService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getProductLiveNonLiveTitle,
            getData: getData,
            exportExcel: exportExcel
        };

        return service;

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate,
                normalMode: data.normalMode
            };
            var url = 'api/house-win-loss-by-products/' + companyWinlossService.resolveProductPath(data.productName) + '/live-non-live';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(sportTypeTitle, liveNonLiveTitle, data, fileName) {
            var httpData = {
                sportTypeTitle: sportTypeTitle,
                liveNonLiveTitle: liveNonLiveTitle,
                startDate: data.startDate,
                endDate: data.endDate,
                normalMode: data.normalMode
            };
            var url = 'api/house-win-loss-by-products/' + companyWinlossService.resolveProductPath(data.productName) + '/live-non-live/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);