(function (angular, app) {
    'use strict';

    app.controller('DesignatedDriverEditCtrl', function ($scope, $state, $stateParams, api) {
        if (!angular.isUndefined($stateParams.id)) {
            api.designatedDrivers.get({ id: $stateParams.id }, function (result) {
                $scope.data = result;
            });
        }

        $scope.save = function (form) {
            form.$setSubmitted(true);

            if (form.$valid) {
                api.designatedDrivers.save($scope.data, function () {
                    $state.go('query.designateddrivers');
                });
            }
        };

        $scope.addPrice = function () {
            if (angular.isUndefined($scope.data)) {
                $scope.data = { Prices: [] };
            }
            $scope.data.Prices.push({});
        }

        $scope.removePrice = function(index) {
            $scope.data.Prices.splice(index, 1);
        }
    });

})(angular, app);