(function (angular, app) {
    'use strict';

    app.controller('DinnerTypesCtrl', function ($scope, $compile, api, datatableSettings, sweetAlert, DTOptionsBuilder, DTColumnDefBuilder) {
        api.dinnerTypes.query(function (result) {
            $scope.dinnerTypes = result;
        });

        $scope.dtOptions = datatableSettings.getGeneralSettings(DTOptionsBuilder);

        $scope.dtMessageColumnDefs = [
            DTColumnDefBuilder.newColumnDef(1).notSortable()
        ];

        $scope.remove = function (id) {
            sweetAlert.confirm(
                "你将删除这条数据!",
                function(resover) {
                    api.dinnerTypes.remove({ id: id }, function () {
                        for (var i = 0; i < $scope.dinnerTypes.length; i++) {
                            if ($scope.dinnerTypes[i].ID === id) {
                                $scope.dinnerTypes.splice(i, 1);
                                break;
                            }
                        }

                        resover();
                    });
                });
        };
    });

})(angular, window.app);