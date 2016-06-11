(function (angular, app) {
    'use strict';

    app.controller('StaffsCtrl', function ($scope, api, datatableSettings, sweetAlert, DTOptionsBuilder, DTColumnDefBuilder) {
        api.staffs.query(function (result) {
            $scope.staffs = result;
        });

        $scope.dtOptions = datatableSettings.getGeneralSettings(DTOptionsBuilder);

        $scope.dtMessageColumnDefs = [
            DTColumnDefBuilder.newColumnDef(3).notSortable()
        ];

        $scope.remove = function (id) {
            sweetAlert.confirm(
                "你将删除这条数据!",
                function(resover) {
                    api.staffs.remove({ id: id }, function () {
                        for (var i = 0; i < $scope.staffs.length; i++) {
                            if ($scope.staffs[i].ID === id) {
                                $scope.staffs.splice(i, 1);
                                break;
                            }
                        }

                        resover();
                    });
                });
        };
    });

})(angular, window.app);