import angular from "angular";
import moment from "moment";
(function (angular) {
    "use strict";

    var templateSetting = {
        "Main": {
            mainView: "product",
            product: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SportTypeController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/soccer-minor/sport-type",
                mainParameters: {},
                getTitleFunction: "getMainTitle"
            },
            betType: {
                templateUrl: "app/house-win-loss/shared/three-fanex-grid-with-title.html",
                controller: "SoccerBetTypeFullController",
                service: "soccerMinorBetTypeService",
                serviceBaseUrl: "api/house-win-loss-by-products/soccer-minor/bet-type",
                mainParameters: {},
                getTitleFunction: "getSoccerMinorBetTypeTitle"
            },
            matchDetail: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SportsbookMatchDetailController",
                service: "sportsbookMatchDetailService",
                serviceBaseUrl: function (data) {
                    return data.betType === 10
                        ? 'api/house-win-loss-by-products/soccer-minor/outright-match-detail'
                        : 'api/house-win-loss-by-products/soccer-minor/match-detail';
                },
                mainParameters: { sportType: 1 },
                getTitleFunction: "getMatchDetailTitleLive"
            },
            site: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SiteController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/soccer-minor/site",
                mainParameters: { sportType: 1 },
                getTitleFunction: "getSiteTitleLive"
            }
        }
        //"Soccer-Minor Bet Types": {
        //    mainView: "bettype",
        //    bettype: {
        //        templateUrl: "app/house-win-loss/shared/three-fanex-grid-with-title.html",
        //        controller: "SoccerBetTypeFullController",
        //        service: "soccerBetTypeFullService",
        //        serviceBaseUrl: "api/house-win-loss-by-products/soccer-minor/bet-type",
        //        mainParameters: {},
        //        getTitleFunction: "getSoccerBetTypeTitle"
        //    },
        //    matchDetail: {
        //        templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
        //        controller: "SportsbookMatchDetailController",
        //        service: "sportsbookMatchDetailService",
        //        serviceBaseUrl: function (data) {
        //            return data.betType === 10
        //                ? 'api/house-win-loss-by-products/sportsbook/outright-match-detail'
        //                : 'api/house-win-loss-by-products/sportsbook/match-detail';
        //        },
        //        mainParameters: {},
        //        getTitleFunction: "getMatchDetailTitleLive"
        //    },
        //    site: {
        //        templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
        //        controller: "SiteController",
        //        service: "remoteDataService",
        //        serviceBaseUrl: "api/house-win-loss-by-products/sportsbook/site",
        //        mainParameters: {},
        //        getTitleFunction: "getSiteTitleLive"
        //    }
        //}
    };
    angular
        .module("app.houseWinlossApp")
        .constant("templateSetting", templateSetting);
})(angular);