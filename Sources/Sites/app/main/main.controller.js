/**
 * @ngdoc function
 * @name companyWinlossApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the companyWinlossApp
 */
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('MainController', MainController);

    MainController.$inject = ['config', 'formatStrings', 'dataService'];

    function MainController(config, formatStrings, dataService) {
        /*jshint validthis: true */
        var reportData = {
            SportsbookDetail: createFakeSportBookDetail(),
            OtherProducts: createFakeOtherProducts(),
            GrandTotal: createFakeGrandTotal()
        };

        var vm = this;

        vm.normalMode = true;
        vm.today = config.today;
        vm.yesterday = config.yesterday;
        vm.date = config.today;
        vm.fromDate = moment.utc(config.today).startOf('month').toDate();
        vm.toDate = config.today;


        vm.generate = function () {
            getData().then(function (data) {
                renderMainReport(vm.data);
            });
        };

        vm.todayClicked = function () {
            vm.date = vm.today;
            vm.generate();
        };

        vm.yesterdayClicked = function () {
            vm.date = vm.yesterday;
            vm.generate();
        };

        vm.viewHistoryMode = function () {
            vm.normalMode = false;
        };

        vm.viewNormalMode = function () {
            vm.normalMode = true;
        };

        function getData() {
            var promise = vm.normalMode ? dataService.getDataNormal() : dataService.getDataHistory();
            return promise.then(function (data) {
                vm.data = data;
                vm.data = reportData;
            });
        }

        function createFakeSportBookDetail() {
            var sportbookDetail = [
                { Title: "Sportsbook Live", MemberWinLoss: 100, SMAWinLoss: 200, Commission: 10, RealIncome: 300, VirtualIncome: 400, VarianceIncome: -100, RealTurnover: 1000, VirtualTurnover: 1200, RealMargin: 0.3, VirtualMargin: 0.3 },
                { Title: "Sportsbook Non-Live", MemberWinLoss: 110, SMAWinLoss: 210, Commission: 20, RealIncome: 310, VirtualIncome: 410, VarianceIncome: -100, RealTurnover: 1100, VirtualTurnover: 1300, RealMargin: 0.281818, VirtualMargin: 0.315384 },
                { Title: "Parlay", MemberWinLoss: 120, SMAWinLoss: 220, Commission: 30, RealIncome: 320, VirtualIncome: 420, VarianceIncome: -100, RealTurnover: 1200, VirtualTurnover: 1400, RealMargin: 0.266666, VirtualMargin: 0.3 },
                { Title: "Outright", MemberWinLoss: 130, SMAWinLoss: 230, Commission: 40, RealIncome: 330, VirtualIncome: 430, VarianceIncome: -100, RealTurnover: 1300, VirtualTurnover: 1500, RealMargin: 0.253846, VirtualMargin: 0.286666 }
            ];

            return sportbookDetail;
        }

        function createFakeSportBook() {
            return createFakeProductWinLoss("Sportbook Total");
        }

        function createFakeOtherProducts() {
            var otherProducts = [];
            var sportbooksTotal = createFakeProductWinLoss("Sportsbook Total");
            var numberGame = createFakeProductWinLoss("Number Game");
            var casino = createFakeProductWinLoss("Casino");
            otherProducts.push(sportbooksTotal);
            otherProducts.push(numberGame);
            otherProducts.push(casino);

            return otherProducts;
        }

        function createFakeGrandTotal() {
            return createFakeProductWinLoss("Grand Total");
        }

        function createFakeProductWinLoss(productName) {
            var winLoss = {
                Total: { Title: productName, MemberWinLoss: 210, SMAWinLoss: 410, Commission: 30, RealIncome: 610, VirtualIncome: 810, VarianceIncome: -200, RealTurnover: 2100, VirtualTurnover: 2500, RealMargin: 0.290476, VirtualMargin: 0.324 },
                Credit: { Title: "Credit", MemberWinLoss: 100, SMAWinLoss: 200, Commission: 10, RealIncome: 300, VirtualIncome: 400, VarianceIncome: -100, RealTurnover: 1000, VirtualTurnover: 1200, RealMargin: 0.3, VirtualMargin: 0.3 },
                Deposit: { Title: "Deposit", MemberWinLoss: 110, SMAWinLoss: 210, Commission: 20, RealIncome: 310, VirtualIncome: 410, VarianceIncome: -100, RealTurnover: 1100, VirtualTurnover: 1300, RealMargin: 0.281818, VirtualMargin: 0.315384 }
            };

            return winLoss;
        }

        function createProductWinLossDataRow(productWinLossItem) {
            var productDataRow = {
                Columns: createWinLossDataRow(productWinLossItem.Total),
                SubRows: []
            };

            productDataRow.SubRows.push({ Columns: createWinLossDataRow(productWinLossItem.Credit), CssClass: 'align-right' });
            productDataRow.SubRows.push({ Columns: createWinLossDataRow(productWinLossItem.Deposit), CssClass: 'align-right' });

            return productDataRow;
        }

        function createWinLossDataRow(winLoss) {
            var winLossDataRow = [
                { Name: "Product", Value: winLoss.Title },
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "VirtualIncome", Value: winLoss.VirtualIncome },
                { Name: "Variance", Value: winLoss.VarianceIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "VirtualTurnover", Value: winLoss.VirtualTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin },
                { Name: "VirtualMargin", Value: winLoss.VirtualMargin }
            ];

            return winLossDataRow;
        }

        function createSportsbookTotalRow(sportsbookTotal) {
            var totalDataRow = {
                Columns: createWinLossDataRow(sportsbookTotal.Total),
                SubRows: [],
                CssClass: 'sub-total'
            };

            totalDataRow.SubRows.push({ Columns: createWinLossDataRow(sportsbookTotal.Credit), CssClass: 'sub-total' });
            totalDataRow.SubRows.push({ Columns: createWinLossDataRow(sportsbookTotal.Deposit), CssClass: 'sub-total' });

            return totalDataRow;
        }

        function createMainReportBodyData(mainReportData) {
            var bodyData = [];
            var sportbookDetail = mainReportData.SportsbookDetail;
            var otherProducts = mainReportData.OtherProducts;
            var sportbookTotal = otherProducts[0];

            for (var i = 0; i < sportbookDetail.length; i++) {
                var sportbookItem = sportbookDetail[i];
                bodyData.push({
                    Columns: createWinLossDataRow(sportbookItem)
                });
            }

            bodyData.push(createSportsbookTotalRow(otherProducts[0]));

            for (var i = 1; i < otherProducts.length; i++) {
                var productItem = otherProducts[i];
                bodyData.push(createProductWinLossDataRow(productItem));
            }

            return bodyData;
        }

        function createMainReportFooterData(mainReportData) {
            var footerRow = [];
            var grandTotal = mainReportData.GrandTotal;
            footerRow.push({ Columns: createWinLossDataRow(grandTotal.Total) });
            footerRow.push({ Columns: createWinLossDataRow(grandTotal.Credit) });
            footerRow.push({ Columns: createWinLossDataRow(grandTotal.Deposit) });

            return footerRow;
        }

        function createMainReportGridOptions(mainReportData) {
            var columns = [
                 { HeaderText: "Product", Width: 150, Name: "Product", HeaderAlign: "center", CellAlign: "left", ShowCollapseExpand: true },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Real", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Virtual", Width: 120, Name: "VirtualIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Variance", Width: 120, Name: "Variance", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Real", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Virtual", Width: 120, Name: "VirtualTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Real", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER },
                 { HeaderText: "Virtual", Width: 120, Name: "VirtualMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var groupHeaderRowsColumns = [
                { HeaderText: "Product", Name: "Product", MergeRowNumber: 2 },
                { HeaderText: "Member Win Loss", Name: "MemberWinLoss", MergeRowNumber: 2 },
                { HeaderText: "SMA Win Loss", Name: "SMAWinLoss", MergeRowNumber: 2 },
                { HeaderText: "Commission", Name: "Commission", MergeRowNumber: 2 },
                { HeaderText: "Company Income", Name: "RealIncome", MergeColNumber: 2 },
                { HeaderText: "Variance", Name: "Variance", MergeRowNumber: 2 },
                { HeaderText: "Company Turnover", Name: "RealTurnover", MergeColNumber: 2 },
                { HeaderText: "Margin", Name: "RealMargin", MergeColNumber: 2 }
            ];

            var gridOptions = {
                customizeHeader: true,
                groupHeaderRows: [
                    { Columns: groupHeaderRowsColumns }
                ],
                columns: columns,
                bodyRows: createMainReportBodyData(mainReportData),
                showTree: true,
                defaultCollapseAllGroups: true,
                showTitle: true,
                titleInfo:
                {
                    text: "PRODUCT WIN/LOSS REPORT",
                    showCollapseExpandButton: true,
                    showExcelButton: true,
                    exportExcelFunction: function () {
                    }
                },
                showFooter: true,
                footerRows: createMainReportFooterData(mainReportData)
            };

            return gridOptions;
        }

        function renderMainReport(mainReportData) {
            var gridOptions = createMainReportGridOptions(mainReportData);
            $(".freegrid").fanexGrid(gridOptions);
        }
    }
})();