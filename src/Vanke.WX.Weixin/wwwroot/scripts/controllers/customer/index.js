(function (angular) {
    'use strict';

    angular
        .module('architecture')
        .controller('CustomerMainCtrl', function ($scope, api, DTOptionsBuilder, DTColumnDefBuilder) {

            // Pic
            $scope.pie = {
                colors: ['#34495E', '#9B59B6', '#3498DB', '#62CB31', '#FFB606', '#E67E22', '#C0392B'],
                chartOptions: {
                    series: {
                        pie: {
                            show: true
                        }
                    },
                    grid: {
                        hoverable: true,
                        clickable: true
                    },
                    tooltip: true,
                    tooltipOpts: {
                        content: "%p.0%, %s", // show percentages, rounding to 2 decimal places
                        shifts: {
                            x: 20,
                            y: 0
                        },
                        defaultTheme: false
                    }
                },
                vehicleData: [{}],
                tenderData: [{}],
                vehicleBookingData: [{}],
                infringementData: [{}]
            };

            // Datatables
            $scope.dtOptions = DTOptionsBuilder.newOptions()
                .withDOM(
                    "<'row'<'col-sm-12'tr>>" +
                    "<'row'<'col-sm-5'i><'col-sm-7'p>>")
                .withDisplayLength(10)
                .withOption('responsive', true);
            //.withButtons([
            //    'colvis',
            //    'copy',
            //    'print',
            //    'csv',
            //    'excelHtml5',
            //    {
            //        text: 'Some button',
            //        key: '1',
            //        action: function (e, dt, node, config) {
            //            alert('Button activated');
            //        }
            //    }
            //]);
            $scope.dtMessageColumnDefs = [
                DTColumnDefBuilder.newColumnDef(4).notSortable()
            ];

            // Get data from api
            api.getCustomerDashboard(function (result) {
                $scope.data = result;

                var vehicleData = [];
                angular.forEach(result.VehicleSummary, function (item, index) {
                    vehicleData.push({
                        label: item.Name + '(' + item.Value + ')',
                        data: item.Value,
                        color: $scope.pie.colors[index]
                    });
                });
                $scope.pie.vehicleData = vehicleData;

                var tenderData = vehicleBookingData = infringementData = [];
                angular.forEach(result.TenderSummary, function (item, index) {
                    tenderData.push({
                        label: item.Name + '(' + item.Value + ')',
                        data: item.Value,
                        color: $scope.pie.colors[index]
                    });
                });
                $scope.pie.tenderData = tenderData;

                var vehicleBookingData = infringementData = [];
                angular.forEach(result.VehicleBookingSummary, function (item, index) {
                    vehicleBookingData.push({
                        label: item.Name + '(' + item.Value + ')',
                        data: item.Value,
                        color: $scope.pie.colors[index]
                    });
                });
                $scope.pie.vehicleBookingData = vehicleBookingData;

                var infringementData = [];
                angular.forEach(result.InfringementReportSummary, function (item, index) {
                    infringementData.push({
                        label: item.Name + '(' + item.Value + ')',
                        data: item.Value,
                        color: $scope.pie.colors[index]
                    });
                });
                $scope.pie.infringementData = infringementData;
            });
        });

})(angular);