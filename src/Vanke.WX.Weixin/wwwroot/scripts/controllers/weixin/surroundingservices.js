(function (angular, app) {
    'use strict';

    app.controller('SurroundingServicesCtrl', function ($scope, api) {
        api.surroundingServices.query(function (result) {
            $scope.surroundingServices = result;
        });
    });

})(angular, window.app);