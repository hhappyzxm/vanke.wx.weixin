(function (angular, app) {
    'use strict';

    app.controller('IdleAssetEditCtrl', function ($scope, $state, $stateParams, api) {
        api.items.query(function (result) {
            $scope.items = result;
        });

        api.itemStorageAreas.query(function(result) {
            $scope.areas = result;
        });

        api.staffs.query(function (result) {
            $scope.staffs = result;
        });

        if (!angular.isUndefined($stateParams.id)) {
            api.idleAssets.get({ id: $stateParams.id }, function (result) {
                $scope.data = result;

                loadPlaces();
            });
        }

        var loadPlaces = function() {
            api.itemStoragePlaces.search({ areaId: $scope.data.AreaID }, function (result) {
                $scope.places = result;
            });
        };

        $scope.changeArea = function () {
            $scope.data.PlaceID = '';
            loadPlaces();
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