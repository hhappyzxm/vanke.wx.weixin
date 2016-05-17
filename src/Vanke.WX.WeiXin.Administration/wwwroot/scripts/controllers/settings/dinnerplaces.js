(function (angular, app) {
    'use strict';

    app.controller('DinnerPlacesCtrl', function ($scope, api, datatableSettings, sweetAlert, DTOptionsBuilder, DTColumnDefBuilder) {
        api.dinnerPlaces.query(function (result) {
            $scope.dinnerPlaces = result;
        });

        $scope.dtOptions = datatableSettings.getGeneralSettings(DTOptionsBuilder);

        $scope.dtMessageColumnDefs = [
            DTColumnDefBuilder.newColumnDef(1).notSortable()
        ];

        $scope.remove = function (id) {
            sweetAlert.confirm(
                "你将删除这条数据!",
                function(resover) {
                    api.dinnerPlaces.remove({ id: id }, function () {
                        for (var i = 0; i < $scope.dinnerPlaces.length; i++) {
                            if ($scope.dinnerPlaces[i].ID === id) {
                                $scope.dinnerPlaces.splice(i, 1);
                                break;
                            }
                        }

                        resover();
                    });
                });
        };
    });

})(angular, window.app);