(function (angular, app) {
    'use strict';

    app.controller('MealTypesCtrl', function ($scope, api, datatableSettings, sweetAlert, DTOptionsBuilder, DTColumnDefBuilder) {
        api.mealTypes.query(function (result) {
            $scope.mealTypes = result;
        });

        $scope.dtOptions = datatableSettings.getGeneralSettings(DTOptionsBuilder);

        $scope.dtMessageColumnDefs = [
            DTColumnDefBuilder.newColumnDef(1).notSortable()
        ];

        $scope.remove = function (id) {
            sweetAlert.confirm(
                "你将删除这条数据!",
                function(resover) {
                    api.mealTypes.remove({ id: id }, function () {
                        for (var i = 0; i < $scope.mealTypes.length; i++) {
                            if ($scope.mealTypes[i].ID === id) {
                                $scope.mealTypes.splice(i, 1);
                                break;
                            }
                        }

                        resover();
                    });
                });
        };
    });

})(angular, window.app);