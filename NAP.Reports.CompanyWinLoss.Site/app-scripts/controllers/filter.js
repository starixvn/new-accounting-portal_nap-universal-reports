'use strict';

/**
 * @ngdoc function
 * @name companyWinlossApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the companyWinlossApp
 */
angular.module('companyWinlossApp')
  .controller('FilterCtrl', function ($scope) {
      $scope.disableExport = true;
      $scope.disableExpand = true;
      $scope.generate = function () {
          $scope.disableExport = false;
          $scope.disableExpand = false;
      };
  });
