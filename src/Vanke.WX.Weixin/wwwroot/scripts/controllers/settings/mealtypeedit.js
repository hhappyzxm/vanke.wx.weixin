(function (angular, app) {
    'use strict';

    app.controller('MealTypeEditCtrl', function ($scope, $state, $stateParams, api) {
        if (!angular.isUndefined($stateParams.id)) {
            api.mealTypes.get({ id: $stateParams.id }, function(result) {
                $scope.data = result;
            });
        }

        $scope.save = function (form) {
            form.$setSubmitted(true);

            if (form.$valid) {
                api.mealTypes.save($scope.data, function () {
                    $state.go('settings.mealtypes');
                });
            }
        };
    });

})(angular, app);