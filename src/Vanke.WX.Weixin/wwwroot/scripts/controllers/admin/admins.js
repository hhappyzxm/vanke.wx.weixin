(function (angular, app) {
    'use strict';

    app.controller('AdminsCtrl', function ($scope, $compile, api, datatableSettings, sweetAlert, DTOptionsBuilder, DTColumnDefBuilder) {
        api.admin.query(function (result) {
            $scope.admins = result;
        });

        $scope.dtOptions = datatableSettings.getGeneralSettings(DTOptionsBuilder);

        $scope.dtMessageColumnDefs = [
            DTColumnDefBuilder.newColumnDef(2).notSortable()
        ];

        $scope.remove = function (id) {
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

})(angular, window.app);