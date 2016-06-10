(function (angular, app) {
    'use strict';

    app.controller('ItemStoragePlaceCtrl', function ($scope, $state, $stateParams, api) {
        api.itemStorageAreas.query(function (result) {
            $scope.itemStorageAreas = result;
        });

        if (!angular.isUndefined($stateParams.id)) {
            api.itemStoragePlaces.get({ id: $stateParams.id }, function (result) {
                $scope.data = result;
            });
        }

        $scope.save = function (form) {
            form.$setSubmitted(true);

            if (form.$valid) {
                api.itemStoragePlaces.save($scope.data, function () {
                    $state.go('settings.itemstorageplaces');
                });
            }
        };
    });

})(angular, app);