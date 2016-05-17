(function (angular, app) {
    'use strict';

    app.controller('ItemsCtrl', function ($scope, $compile, api, datatableSettings, sweetAlert, DTOptionsBuilder, DTColumnDefBuilder) {
        api.items.query(function (result) {
            $scope.items = result;
        });

        $scope.dtOptions = datatableSettings.getGeneralSettings(DTOptionsBuilder);

        $scope.dtMessageColumnDefs = [
            DTColumnDefBuilder.newColumnDef(1).notSortable()
        ];

        $scope.remove = function (id) {
            sweetAlert.confirm(
                "你将删除这条数据!",
                function(resover) {
                    api.items.remove({ id: id }, function () {
                        for (var i = 0; i < $scope.items.length; i++) {
                            if ($scope.items[i].ID === id) {
                                $scope.items.splice(i, 1);
                                break;
                            }
                        }

                        resover();
                    });
                });
        };
    });

})(angular, window.app);