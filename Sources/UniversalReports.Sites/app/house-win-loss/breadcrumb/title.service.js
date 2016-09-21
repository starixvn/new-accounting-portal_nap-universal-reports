import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.houseWinlossApp')
        .factory('titleService', titleService);

    titleService.$inject = [];
    function titleService() {
        var productWinLossReport = 'Product Win/Loss Report' ;

        var service = {
            getMainTitle: getMainTitle,
            getProductTitle: getProductTitle,
            getProductLiveNonLiveTitle: getProductLiveNonLiveTitle,
            getCasinoProductTitle: getCasinoProductTitle,
            getSportTypeTitle: getSportTypeTitle,
            getSiteTitle: getSiteTitle,
            getMatchDetailTitle: getMatchDetailTitle
        };
        return service;

        function getSiteText(site) {
            return '| ' + (site == undefined ? "ALL" : site) + ' Site';
        }

        function getMainTitle(data) {
            return 'Main';
        }

        function getProductTitle(data) {
            return data.productName;
        }

        function getProductLiveNonLiveTitle(data, isLast) {
            return isLast ? data.productName + ' Live/Non-Live ' : data.productName;
        }

        function getCasinoProductTitle(data) {
            return data.casinoProductName;
        }

        function getSportTypeTitle(data) {
            return data.sportTypeName;
        }

        function getSiteTitle(data) {
            return data.betTypeName + ' ' + getSiteText(data.site);
        }

        function getMatchDetailTitle(data) {
            return data.betTypeName;
        }
    }
})(angular);