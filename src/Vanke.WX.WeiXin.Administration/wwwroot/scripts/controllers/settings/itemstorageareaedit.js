(function (angular, app) {
    'use strict';

    app.controller('ItemStorageAreaCtrl', function ($scope, $state, $stateParams, api) {
        if (!angular.isUndefined($stateParams.id)) {
            api.itemStorageAreas.get({ id: $stateParams.id }, function (result) {
                $scope.data = result;
            });
        }

        $scope.save = function (form) {
            form.$setSubmitted(true);

            if (form.$valid) {
                api.itemStorageAreas.save($scope.data, function () {
                    $state.go('settings.itemstorageareas');
                });
            }
        };
    });

})(angular, app);