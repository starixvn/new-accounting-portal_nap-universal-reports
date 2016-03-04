(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('cockfightingDetailService', cockfightingDetailService);

    cockfightingDetailService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'breadcrumbHelper'];
    function cockfightingDetailService($http, httpResponseService, companyWinlossService, breadcrumbHelper) {
        var service = {
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };
            return $http.post('/api/company-win-loss/cock-fighting/match-detail', data)
                 .then(httpResponseService.getDataComplete)
                 .catch(httpResponseService.getDataFailed);
        }

        function exportExcel() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                title: breadcrumbHelper.generateText(),
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };
            return $http.post('/api/company-win-loss/cock-fighting/match-detail/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();