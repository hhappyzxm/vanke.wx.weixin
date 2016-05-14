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
                "你是否确定?",
                "你将删除本条记录!",
                function() {
                    api.admins.remove({ id: id });
                },
                null,
                true,
                true);
        };
    });

})(angular, window.app);