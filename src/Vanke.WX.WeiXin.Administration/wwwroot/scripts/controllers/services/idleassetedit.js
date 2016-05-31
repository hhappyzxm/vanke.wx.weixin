(function (angular, app) {
    'use strict';

    app.controller('IdleAssetEditCtrl', function ($scope, $state, $stateParams, api) {
        if (!angular.isUndefined($stateParams.id)) {
            api.idleAssets.get({ id: $stateParams.id }, function (result) {
                $scope.data = result;
            });
        }

        $scope.save = function (form) {
            form.$setSubmitted(true);

            if (form.$valid) {
                api.idleAssets.save($scope.data, function () {
                    $state.go('service.idleassets');
                });
            }
        };
    });

})(angular, app);