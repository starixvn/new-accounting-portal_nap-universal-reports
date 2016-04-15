(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('liveTitleService', liveTitleService);

    liveTitleService.$inject = [];
    function liveTitleService() {
        var productWinLossReport = 'Product Win/Loss Report';
        var productWinLossReport2 = ' ' + productWinLossReport;
        var productWinLossBy = '| Product Win/Loss By ';
        var site = ' Site';

        var service = {
            getProductTitle: getProductTitle,
            getSiteTitle: getSiteTitle,
            getMatchDetailTitle: getMatchDetailTitle
        };
        return service;

        function getLiveText(isLive) {
            return ' "' + (isLive ? 'Live' : 'Non-Live') + '" ';
        }

        function getSiteText(site) {
            return '| Product Win/Loss By ' + site + ' Site';
        }

        function getProductTitle(data, isLast) {
            return isLast
                ? data.productName + getLiveText(data.isLive) + productWinLossReport
                : data.productName;
        }

        function getSiteTitle(data) {
            return data.betTypeName + getLiveText(data.isLive) + getSiteText(data.site);
        }

        function getMatchDetailTitle(data) {
            return data.betTypeName + getLiveText(data.isLive) + productWinLossReport;
        }
    }
})(angular);