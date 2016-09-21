import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.houseWinlossApp')
        .factory('liveTitleService', liveTitleService);

    liveTitleService.$inject = [];
    function liveTitleService() {

        var service = {
            getProductTitle: getProductTitle,
            getSportTypeTitle: getSportTypeTitle,
            getSiteTitle: getSiteTitle,
            getProductNumberGameTitle: getProductNumberGameTitle,
            getMatchDetailTitle: getMatchDetailTitle
        };
        return service;

        function getLiveText(isLive) {
            return ' "' + (isLive ? 'Live' : 'Non-Live') + '" ';
        }

        function getSiteText(site) {
            return '| ' + site + ' Site';
        }

        function getProductTitle(data) {
            return data.productName + getLiveText(data.isLive);
        }

        function getProductNumberGameTitle(data) {
            return data.isLive == undefined ? data.productName : data.productName + getLiveText(data.isLive);
        }

        function getSportTypeTitle(data) {
            return data.sportTypeName + getLiveText(data.isLive);
        }

        function getSiteTitle(data) {
            return data.betTypeName + getLiveText(data.isLive) + getSiteText(data.site);
        }

        function getMatchDetailTitle(data) {
            return data.betTypeName + getLiveText(data.isLive);
        }
    }
})(angular);