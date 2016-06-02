(function (angular, app) {
    'use strict';

    app.controller('SurroundingServicesCtrl', function ($scope, api, datatableSettings, sweetAlert, DTOptionsBuilder, DTColumnDefBuilder) {
        api.surroundingServices.query(function (result) {
            $scope.surroundingServices = result;
        });

        $scope.dtOptions = datatableSettings.getGeneralSettings(DTOptionsBuilder);

        $scope.dtMessageColumnDefs = [
            DTColumnDefBuilder.newColumnDef(2).notSortable()
        ];

        $scope.remove = function (id) {
            sweetAlert.confirm(
                "你将删除这条数据!",
                function(resover) {
                    api.surroundingServices.remove({ id: id }, function () {
                        for (var i = 0; i < $scope.surroundingServices.length; i++) {
                            if ($scope.surroundingServices[i].ID === id) {
                                $scope.surroundingServices.splice(i, 1);
                                break;
                            }
                        }

                        resover();
                    });
                });
        };
    });

})(angular, window.app);