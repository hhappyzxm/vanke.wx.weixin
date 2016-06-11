(function (angular, app) {
    'use strict';

    app.controller('DinnerPlaceEditCtrl', function ($scope, $state, $stateParams, api) {
        if (!angular.isUndefined($stateParams.id)) {
            api.dinnerPlaces.get({ id: $stateParams.id }, function(result) {
                $scope.data = result;
            });
        }

        $scope.save = function (form) {
            form.$setSubmitted(true);

            if (form.$valid) {
                api.dinnerPlaces.save($scope.data, function () {
                    $state.go('settings.dinnerplaces');
                });
            }
        };
    });

})(angular, app);