(function (angular, app) {
    'use strict';

    app.controller('AdminsCtrl', function ($scope, $compile, api, datatableSettings, DTOptionsBuilder, DTColumnDefBuilder) {
        api.getAdmins(function (result) {
            $scope.admins = result;
        });

        $scope.dtOptions = datatableSettings.getGeneralSettings(DTOptionsBuilder);

        $scope.dtMessageColumnDefs = [
            DTColumnDefBuilder.newColumnDef(2).notSortable()
        ];
    });

})(angular, window.app);