(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('titleService', titleService);

    titleService.$inject = [];
    function titleService() {
        var winLossReport = 'Win/Loss Report';
        var productWinLossReport = 'Product ' + winLossReport;

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
            return '| Product Win/Loss By ' + (site == undefined ? "ALL" : site) + ' Site';
        }

        function getMainTitle(data, isLast) {
            return isLast ? productWinLossReport : 'Main';
        }

        function getProductTitle(data, isLast) {
            return isLast ? data.productName + ' ' + productWinLossReport : data.productName;
        }

        function getProductLiveNonLiveTitle(data, isLast) {
            return isLast ? data.productName + ' Live/Non-Live ' + winLossReport : data.productName;
        }

        function getCasinoProductTitle(data, isLast) {
            return isLast ? data.casinoProductName : data.productName + ' ' + productWinLossReport;
        }

        function getSportTypeTitle(data, isLast) {
            return isLast ? data.sportTypeName + ' ' + productWinLossReport : data.sportTypeName;
        }

        function getSiteTitle(data) {
            return data.betTypeName + ' ' + getSiteText(data.site);
        }

        function getMatchDetailTitle(data) {
            return data.betTypeName + ' ' + productWinLossReport;
        }
    }
})(angular);