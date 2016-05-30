(function (angular, app) {
    'use strict';

    app.controller('ItemStoragePlacesCtrl', function ($scope, api, datatableSettings, sweetAlert, DTOptionsBuilder, DTColumnDefBuilder) {
        api.itemStoragePlaces.query(function (result) {
            $scope.itemStoragePlaces = result;
        });

        $scope.dtOptions = datatableSettings.getGeneralSettings(DTOptionsBuilder);

        $scope.dtMessageColumnDefs = [
            DTColumnDefBuilder.newColumnDef(2).notSortable()
        ];

        $scope.remove = function (id) {
            sweetAlert.confirm(
                "你将删除这条数据!",
                function(resover) {
                    api.itemStoragePlaces.remove({ id: id }, function () {
                        for (var i = 0; i < $scope.itemStoragePlaces.length; i++) {
                            if ($scope.itemStoragePlaces[i].ID === id) {
                                $scope.itemStoragePlaces.splice(i, 1);
                                break;
                            }
                        }

                        resover();
                    });
                });
        };
    });

})(angular, window.app);