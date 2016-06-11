(function (angular, app) {
    'use strict';

    app.controller('ItemStorageAreasCtrl', function ($scope, api, datatableSettings, sweetAlert, DTOptionsBuilder, DTColumnDefBuilder) {
        api.itemStorageAreas.query(function (result) {
            $scope.itemStorageAreas = result;
        });

        $scope.dtOptions = datatableSettings.getGeneralSettings(DTOptionsBuilder);

        $scope.dtMessageColumnDefs = [
            DTColumnDefBuilder.newColumnDef(1).notSortable()
        ];

        $scope.remove = function (id) {
            sweetAlert.confirm(
                "你将删除这条数据!",
                function(resover) {
                    api.itemStorageAreas.remove({ id: id }, function () {
                        for (var i = 0; i < $scope.itemStorageAreas.length; i++) {
                            if ($scope.itemStorageAreas[i].ID === id) {
                                $scope.itemStorageAreas.splice(i, 1);
                                break;
                            }
                        }

                        resover();
                    });
                });
        };
    });

})(angular, window.app);