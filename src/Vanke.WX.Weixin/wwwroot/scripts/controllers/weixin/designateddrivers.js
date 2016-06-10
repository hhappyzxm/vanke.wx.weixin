(function (angular, app) {
    'use strict';

    app.controller('DesignatedDriversCtrl', function ($scope, api) {
        api.designatedDrivers.query(function (result) {
            $scope.designatedDrivers = result;
        });
    });

})(angular, window.app);