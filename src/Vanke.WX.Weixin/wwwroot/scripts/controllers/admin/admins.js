(function (angular) {
    'use strict';

    angular
        .module('architecture')
        .controller('AdminsCtrl', function ($scope, $compile, api, sweetAlert, DTOptionsBuilder, DTColumnBuilder) {
            // Datatables
            $scope.dtOptions = DTOptionsBuilder.newOptions()
                .withDOM(
                    "<'row'<'col-sm-12'tr>>" +
                    "<'row'<'col-sm-5'i><'col-sm-7'p>>")
                .withDisplayLength(10)
                .withOption('responsive', true)
                .withOption('ajax', {
                    url: 'http://localhost:56286/api/vehicles',
                    type: 'GET'
                })
                .withDataProp('data')
                //.withOption('processing', true)
                .withOption('serverSide', true)
                .withOption('createdRow', function (row, data, dataIndex) {
                    $compile(angular.element(row).contents())($scope);
                });

            $scope.dtColumns = [
                DTColumnBuilder.newColumn('Registration').withTitle('Registration').withOption('responsivePriority', 1),
                DTColumnBuilder.newColumn('Vehicles').withTitle('Vehicles').withOption('responsivePriority', 8),
                DTColumnBuilder.newColumn('Method').withTitle('Method').withOption('responsivePriority', 4),
                DTColumnBuilder.newColumn('VehicleBusinessUnit').withTitle('Vehicle Business Unit').withOption('responsivePriority', 5),
                DTColumnBuilder.newColumn('Driver').withTitle('Driver').withOption('responsivePriority', 6),
                DTColumnBuilder.newColumn('VehicleSite').withTitle('Vehicle Site').withOption('responsivePriority', 7),
                DTColumnBuilder.newColumn('Status').withTitle('Status').withOption('responsivePriority', 3),
                DTColumnBuilder.newColumn(null).withTitle('Actions').withOption('responsivePriority', 2).notSortable().renderWith(
                    function (data, type, full, meta) {
                        return '<button ui-sref="customer.vehicleedit" class="btn btn-success btn-xs"><i class="fa fa-edit"></i>&nbsp;Edit</button>' +
                            '&nbsp;<button class="btn btn-danger btn-xs" ng-click="removeVehicle()"><i class="fa fa-archive"></i>&nbsp;Archive</button>';
                    })
            ];

            $scope.removeVehicle = function () {
                sweetAlert.swal({
                    title: "Are you sure?",
                    text: "Your will not be able to recover this imaginary file!",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonColor: "#DD6B55",
                    confirmButtonText: "Yes, delete it!",
                    cancelButtonText: "No, cancel plx!",
                    closeOnConfirm: false,
                    closeOnCancel: false
                },
                    function (isConfirm) {
                        if (isConfirm) {
                            sweetAlert.swal("Deleted!", "Your imaginary file has been deleted.", "success");
                        } else {
                            sweetAlert.swal("Cancelled", "Your imaginary file is safe :)", "error");
                        }
                    });
            };
        });

})(angular);