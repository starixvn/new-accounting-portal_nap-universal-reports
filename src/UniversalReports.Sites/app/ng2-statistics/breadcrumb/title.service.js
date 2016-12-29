import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.ng2StatisticsApp')
        .factory('titleService', titleService);

    titleService.$inject = [];
    function titleService() {
        var gameStatisticReport = ' Game Statistics Report ';

        var service = {
            getTitleReport: getTitleReport,
            getGrandTotalTitle: getGrandTotalTitle
        };
        return service;

        function getTitleReport(model) {
            return model.data.isDrilldown === true ? getTitleDrilldown(model.data) : getReportMainTitle(model.data);
        }

        function getTitleDrilldown(data) {

            return data.drilldownType === "Currency" ? getReportbyCrurrencyTitle(data) : getGrandTotalTitle(data);
        }

        function getReportbyTitlle(data) {

            switch (data.reportType) {
                case "daily":
                    return "Daily";
                case "username":
                    return "Username";
                case "bettype":
                    return "Bet Type";
            }
        }

        function getReportMainTitle(data) {

            return getReportbyTitlle(data) + gameStatisticReport + "From " + data.startDate.format('ll') + " To " + data.endDate.format('ll') + " " + getCurrencyName(data);
        }

        function getReportbyCrurrencyTitle(data) {

            return getReportbyTitlle(data) + gameStatisticReport + "On " + data.startDate.format('ll') + " BY CURRENCY " + getCurrencyName(data);
        }

        function getGrandTotalTitle(data) {

            return "Grand Total By Currency From " + data.startDate.format('ll') + " To " + data.endDate.format('ll') + " " + getCurrencyName(data);
        }

        function getCurrencyName(data) {
            return data.currency === 0 || data.currencyName.toUpperCase() === 'ALL'
                ? "(Original currency)"
                : "(" + data.currencyName + ")";
        }
    }
})(angular);