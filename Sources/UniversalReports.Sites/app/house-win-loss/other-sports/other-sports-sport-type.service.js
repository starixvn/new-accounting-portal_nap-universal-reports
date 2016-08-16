(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('otherSportsSportTypeService', otherSportsSportTypeService);

    otherSportsSportTypeService.$inject = ['$http', 'liveTitleService', 'sportTypeService'];
    function otherSportsSportTypeService($http, liveTitleService, sportTypeService) {
        var service = {
            getTitle: liveTitleService.getProductTitle,
            getData: sportTypeService.getData,
            exportExcel: sportTypeService.exportExcel
        };

        return service;

    }
})(angular);