(function (angular, app) {
    'use strict';

    app.controller('DesignatedDriversCtrl', function ($scope, api, datatableSettings, sweetAlert, DTOptionsBuilder, DTColumnDefBuilder) {
        api.designatedDrivers.query(function (result) {
            $scope.designatedDrivers = result;
        });

        $scope.dtOptions = datatableSettings.getGeneralSettings(DTOptionsBuilder);

        $scope.dtMessageColumnDefs = [
            DTColumnDefBuilder.newColumnDef(2).notSortable()
        ];

        $scope.remove = function (id) {
            sweetAlert.confirm(
                "你将删除这条数据!",
                function(resover) {
                    api.designatedDrivers.remove({ id: id }, function () {
                        for (var i = 0; i < $scope.designatedDrivers.length; i++) {
                            if ($scope.designatedDrivers[i].ID === id) {
                                $scope.designatedDrivers.splice(i, 1);
                                break;
                            }
                        }

                        resover();
                    });
                });
        };
    });

})(angular, window.app);