import angular from "angular";
import moment from "moment";
(function (angular) {
    'use strict';

    angular
        .module('app.numberGame2StatisticApp')
        .directive('napFilter', napFilter);

    function napFilter() {
        var directive = {
            restrict: 'EA',
            scope: {
                ngModel: '='
            },
            templateUrl: 'app/ng2-statistic/filter/filter.directive.html',
            replace: true,
            controller: controller,
            controllerAs: 'vm',
            bindToController: true
        };
        return directive;
    }

    controller.$inject = ['$scope', '$rootScope', 'config', 'filterService', 'ngDialog'];
    function controller($scope, $rootScope, config, filterService, ngDialog) {
        /*jshint validthis: true */
        var vm = this;
        vm.minDate = moment("20130101", "YYYYMMDD");
        vm.reportType = "daily";
        vm.currentLevel = 0;
        vm.normalMode = true;

        vm.today = config.today;
        vm.yesterday = config.yesterday;
        vm.date = config.today;
        vm.startDate = moment.utc(config.yesterday);
        vm.endDate = moment.utc(config.yesterday);   
        vm.balanceUpDate = config.balanceUpDate;
               
        vm.sportItems = [];
        filterService.getSports().then(function(data){
            generateDropdown(data);
        });       

        vm.sportTextSettings = {
            CheckAll: "ALL",
            CollapseExpanse: "Collapse/Expanse",
            CollapseBranch: "Collapse/Expanse this branch",
            NoItemChecked: "Select options",
            ItemsSelected: "# selected",
            NoData: "Select options",
            AllItemsSelected: "All"
        }; 
        
        vm.currencies = [];
        filterService.getCurrencies().then(function (data) {
            generateCurrency(data);
        });

        vm.generate = generate;
        vm.todayClicked = todayClicked;
        vm.yesterdayClicked = yesterdayClicked;
        vm.viewNormalMode = viewNormalMode;
        vm.viewHistoryMode = viewHistoryMode;
        vm.getReportCriteria = getReportCriteria;
        vm.updateDateRange = updateDateRange;
     

        function showErrorMsg(){ 
            ngDialog.open({
                template:'<div class="errorMsg"><p>Please select at least one bet type!</p></div>',
                plain: true,
                closeByDocument: true,
                width: 285,
                overlay: false,
                className: 'ngdialog-theme-plain'
            });
        }

        function generateCurrency(data){
            vm.currencies = data;
            vm.currency = 2;
        }

        function generateDropdown(data){
            vm.sportSettings = {
                hasFilter: false,
                collapsedAll: true,
                checkedAll: true,
                idMember: "Id",
                nameMember: "Name",
                selectedMember: null,
                dataMember: null,
                childrenMember: "Children",
                sourceData: data,
                templateUrl: 'app/root/components/fanex-dropdowntree/fanex.dropdowntree.directive.template.html'
            };
        }

        vm.reportCriteria = {};

        function generate() {
            $('.ngdialog-close').click();
            vm.reportCriteria = vm.getReportCriteria();
            if(vm.reportCriteria.betType === ""){
                showErrorMsg();
            }
            else{
                $rootScope.$broadcast('nap-filter-generate', vm.reportCriteria);
            }
        }

        function todayClicked() {
            vm.date = vm.today;
            vm.generate();
        }

        function yesterdayClicked() {
            vm.date = vm.yesterday;
            vm.generate();
        }

        function viewNormalMode() {
            vm.normalMode = true;
            vm.startDate = vm.yesterday;
            vm.endDate = vm.yesterday;
            $('.filter-note').css('display', 'block');
            resetFilter();
        }

        function viewHistoryMode() {
            vm.normalMode = false;
            $('.filter-note').css('display', 'none');
            resetFilter();
        }

        function resetFilter(){
            generateCurrency(vm.currencies);
            generateDropdown(vm.sportSettings.sourceData);
            vm.reportType = "daily";
            if(vm.user !== undefined){
                vm.user.title = "";
            }
            $('.ngdialog-close').click();
            $rootScope.$broadcast('nap-filter-switch');
            $scope.$broadcast('angucomplete-alt:clearInput');
        }

        function getReportCriteria() {
            var dateRange = getDateRange();
            return {
                reportType: vm.reportType,
                isDrilldown: false,
                normalMode: dateRange.normalMode,
                startDate: dateRange.startDate,
                endDate: dateRange.endDate,
                username: vm.user !== undefined ? vm.user.title : "",
                currency: vm.currency,
                balanceUpDate: vm.balanceUpDate,
                betType: getBetType(vm.sportItems)
            };
        }

        function getBetType(sportItems){
            var betTypes = "";
            for(var i = 0; i < sportItems.length; i++){
                betTypes = betTypes + sportItems[i].Id + ",";
            }
            return betTypes;
        }

        function getDateRange() {
            if (vm.normalMode) {
                return {
                    normalMode: vm.normalMode,
                    startDate: vm.date,
                    endDate: vm.date
                };
            } else {
                return {
                    normalMode: vm.normalMode,
                    startDate: vm.startDate,
                    endDate: vm.endDate
                };
            }
        }

        function updateDateRange(dateRange) {
            vm.normalMode = dateRange.normalMode;
            vm.reportType = dateRange.reportType;
            if (vm.normalMode) {
                vm.date = dateRange.startDate;
            } else {
                vm.startDate = dateRange.startDate;
                vm.endDate = dateRange.endDate;     
            }
        }
    }
})(angular);