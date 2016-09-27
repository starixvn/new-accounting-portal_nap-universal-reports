import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.numberGame2StatisticApp')
        .factory('titleService', titleService);

    titleService.$inject = [];
    function titleService() {
        var gameStatisticReport = ' Game Statistic Report ';

        var service = {
            getTitleDrilldown: getTitleDrilldown,
            getReportMainTitle: getReportMainTitle
        };
        return service;
        
        function getTitleDrilldown(data){
            
            return data.drilldownType === "Currency" ? getReportbyCrurrencyTitle(data) : getGrandTotalTitle(data);
        }

        function getReportbyTitlle(data){

            switch(data.reportType){
                case "daily":
                    return "Daily";
                case "username":
                    return "Username";
                case "bettype":
                    return "Bet Type";
            }
        }

        function getReportMainTitle(data){

            return getReportbyTitlle(data) + gameStatisticReport + "From " + data.startDate.format('ll') + " To " + data.endDate.format('ll');
        }

        function getReportbyCrurrencyTitle(data){

            return data.reportType + gameStatisticReport + "On " + data.startDate.format('ll');
        }

        function  getGrandTotalTitle(){

            return "GRAND TOTAL BY CURRENCY";
        }
    }
})(angular);