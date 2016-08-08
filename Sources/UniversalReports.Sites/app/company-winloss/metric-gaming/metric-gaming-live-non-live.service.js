(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('metricGamingLiveNonLiveService', metricGamingLiveNonLiveService);

    metricGamingLiveNonLiveService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function metricGamingLiveNonLiveService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getProductLiveNonLiveTitle,
            getData: getData,
            getBetTypeData: getBetTypeData,
            exportExcel: exportExcel
        }
        return service;

        function getData(data) {            
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/live-none-live';
            var httpData = {
                normalMode: data.normalMode
            };
            return $http.post(url, httpData)
                    .then(httpResponseService.getDataComplete)
                    .catch(httpResponseService.getDataFailed);
        }

        function getBetTypeData(data) {
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/bet-type';
            return $http.post(url, data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(betTypeTitle, liveNonLiveTitle, data, fileName) {
            var httpData = {
                betTypeTitle: betTypeTitle,
                liveNonLiveTitle: liveNonLiveTitle,
                startDate: data.startDate,
                endDate: data.endDate,
                normalMode: data.normalMode
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/live-none-live/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                        .then(function (response) {
                            httpResponseService.saveExcelFile(response.data, fileName);
                        })
                        .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);