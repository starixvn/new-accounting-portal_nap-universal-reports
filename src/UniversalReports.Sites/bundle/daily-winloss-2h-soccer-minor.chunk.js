webpackJsonp([2],{

/***/ 0:
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(170);
	__webpack_require__(171);
	__webpack_require__(172);
	__webpack_require__(173);
	__webpack_require__(174);
	__webpack_require__(175);
	__webpack_require__(176);
	__webpack_require__(177);
	__webpack_require__(178);
	__webpack_require__(179);
	__webpack_require__(180);
	__webpack_require__(181);
	__webpack_require__(182);
	__webpack_require__(183);
	__webpack_require__(184);
	__webpack_require__(185);
	__webpack_require__(186);
	__webpack_require__(187);
	__webpack_require__(188);
	__webpack_require__(189);
	__webpack_require__(190);
	__webpack_require__(191);
	__webpack_require__(192);
	__webpack_require__(193);
	__webpack_require__(194);
	__webpack_require__(195);
	__webpack_require__(196);
	__webpack_require__(197);
	__webpack_require__(198);
	__webpack_require__(199);
	__webpack_require__(200);
	module.exports = __webpack_require__(201);


/***/ },

/***/ 172:
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	var _moment = __webpack_require__(5);
	
	var _moment2 = _interopRequireDefault(_moment);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
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
	                serviceBaseUrl: function serviceBaseUrl(data) {
	                    return data.betType === 10 ? 'api/house-win-loss-by-products/sportsbook/outright-match-detail' : 'api/house-win-loss-by-products/sportsbook/match-detail';
	                },
	                mainParameters: { sportType: 1 },
	                getTitleFunction: "getMatchDetailTitleLive"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/sportsbook/site",
	                mainParameters: { sportType: 1 },
	                getTitleFunction: "getSiteTitleLive"
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
	        } };
	    angular.module("app.houseWinlossApp").constant("templateSetting", templateSetting);
	})(_angular2.default);

/***/ },

/***/ 200:
/***/ function(module, exports) {

	"use strict";

/***/ },

/***/ 201:
/***/ function(module, exports) {

	'use strict';
	
	//import angular from "angular";
	(function (angular) {
	    'use strict';
	
	    angular.module('app.houseWinlossApp').factory('soccerMinorBetTypeService', soccerMinorBetTypeService);
	
	    soccerMinorBetTypeService.$inject = ['$http', 'httpResponseService'];
	    function soccerMinorBetTypeService($http, httpResponseService) {
	        var service = {
	            getData: getData,
	            exportExcel: exportExcel
	        };
	
	        return service;
	
	        function getData(data, isLive) {
	            var url = "api/house-win-loss-by-products/soccer-minor/bet-type";
	            var httpData = {};
	            angular.extend(httpData, data);
	            httpData.isLive = isLive;
	            return $http.post(url, httpData).then(httpResponseService.getDataComplete).catch(httpResponseService.getDataFailed);
	        }
	
	        function exportExcel(viewSetting, data, fileName) {
	            var url = 'api/house-win-loss-by-products/soccer-minor/bet-type/excel';
	            var httpData = {};
	            angular.extend(httpData, data);
	            return $http.post(url, httpData, { responseType: "arraybuffer" }).then(function (response) {
	                httpResponseService.saveExcelFile(response.data, fileName);
	            }).catch(httpResponseService.getDataFailed);
	        }
	    }
	})(angular);

/***/ }

});
//# sourceMappingURL=daily-winloss-2h-soccer-minor.chunk.js.map