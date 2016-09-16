import angular from "angular";
(function (angular) {
    'use strict';
    var cricketProductId = 50;
    angular
        .module('app.companyWinlossApp')
        .factory('sportsbookBetTypeService', sportsbookBetTypeService);

    sportsbookBetTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService', 'liveTitleService'];
    function sportsbookBetTypeService($http, httpResponseService, companyWinlossService, titleService, liveTitleService) {
        var service = {
            getTitle: getTitle,
            getData: getData,
            exportExcel: exportExcel
        };

        return service;

        function getData(data) {
            var url = getUrl(data);
            return $http.post(url, data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title
            };
            angular.extend(httpData, data);
            var url = getUrl(data) + '/excel';
            return $http.post(url, httpData, {
                responseType: "arraybuffer"
            })
            .then(function (response) {
                httpResponseService.saveExcelFile(response.data, fileName);
            })
            .catch(httpResponseService.getDataFailed);
        }

        function getUrl(data) {
            return data.sportType == cricketProductId
                ? 'api/house-win-loss-by-products/other-sports/new-cricket/bet-type'
                : 'api/house-win-loss-by-products/' + companyWinlossService.resolveProductPath(data.productName) + '/bet-type';
        }

        function getTitle(data) {
            var sportType = titleService.getSportTypeTitle(data);
            var liveTitle = liveTitleService.getProductTitle(data);
            var viewingFromSportType = sportType !== undefined;
            return viewingFromSportType
                        ? sportType
                        : liveTitle;
        }
    }
})(angular);