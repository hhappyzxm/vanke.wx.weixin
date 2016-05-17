(function (angular, app) {
    'use strict';

    app.controller('AdminsCtrl', function ($scope, $compile, api, datatableSettings, sweetAlert, DTOptionsBuilder, DTColumnDefBuilder) {
        api.admins.query(function (result) {
            $scope.admins = result;
        });

        $scope.dtOptions = datatableSettings.getGeneralSettings(DTOptionsBuilder);

        $scope.dtMessageColumnDefs = [
            DTColumnDefBuilder.newColumnDef(2).notSortable()
        ];

        $scope.remove = function (id) {
            sweetAlert.confirm(
                "你将删除这条数据!",
                function(resover) {
                    api.admins.remove({ id: id }, function () {
                        for (var i = 0; i < $scope.admins.length; i++) {
                            if ($scope.admins[i].ID === id) {
                                $scope.admins.splice(i, 1);
                                break;
                            }
                        }

                        resover();
                    });
                });
        };
    });

})(angular, window.app);