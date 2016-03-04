(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('numberGameDetailService', numberGameDetailService);

    numberGameDetailService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'breadcrumbHelper'];
    function numberGameDetailService($http, httpResponseService, companyWinlossService, breadcrumbHelper) {
        var service = {
            getData: getData,
            exportExcel: exportExcel
        };

        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                sportType: 161,
                isLive: gridModel.isLive,
                betType: gridModel.betType
            };
            return $http.post('/api/company-win-loss/number-game/match-detail', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                title: breadcrumbHelper.generateText(),
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                sportType: 161,
                isLive: gridModel.isLive,
                betType: gridModel.betType
            };

            return $http.post('/api/company-win-loss/number-game/match-detail/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, 'test.xls');
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();