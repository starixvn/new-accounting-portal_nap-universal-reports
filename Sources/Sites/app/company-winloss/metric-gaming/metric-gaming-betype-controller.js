(function (angular, undefined) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('MetricGamingBetTypeController', MetricGamingBetTypeController);

    MetricGamingBetTypeController.$inject = ['$scope', '$element', 'fanexGridService', 'metricGamingBetTypeService'];

    function MetricGamingBetTypeController($scope, $element, $fanexGridService, metricGamingBetTypeService) {

    }

})();