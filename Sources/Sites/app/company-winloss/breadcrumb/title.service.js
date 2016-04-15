(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('titleService', titleService);

    titleService.$inject = [];
    function titleService() {
        var productWinLossReport = 'Product Win/Loss Report';
        var productWinLossReport2 = ' ' + productWinLossReport;

        var service = {
            getMainTitle: getMainTitle,
            getProductTitle: getProductTitle,
            getThirdPartyProductTitle: getThirdPartyProductTitle,
            getSportTypeTitle: getSportTypeTitle,
            getSiteTitle: getSiteTitle,
            getMatchDetailTitle: getMatchDetailTitle
        };
        return service;

        function getSiteText(site) {
            return '| Product Win/Loss By ' + site + ' Site';
        }

        function getMainTitle(data, isLast) {
            return isLast ? productWinLossReport : 'Main';
        }

        function getProductTitle(data, isLast) {
            return isLast ? data.productName + productWinLossReport2 : data.productName;
        }

        function getThirdPartyProductTitle(data, isLast) {
            return isLast ? data.thirdPartyProductName + productWinLossReport2 : data.thirdPartyProductName;
        }

        function getSportTypeTitle(data, isLast) {
            return isLast ? data.sportTypeName + productWinLossReport2 : data.sportTypeName;
        }

        function getSiteTitle(data) {
            return data.betTypeName + ' ' + getSiteText(data.site);
        }

        function getMatchDetailTitle(data) {
            return data.betTypeName + productWinLossReport2;
        }
    }
})(angular);