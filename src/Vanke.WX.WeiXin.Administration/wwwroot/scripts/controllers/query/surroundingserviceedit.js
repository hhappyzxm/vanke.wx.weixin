(function (angular, app) {
    'use strict';

    app.controller('SurroundingServiceEditCtrl', function ($scope, $state, $stateParams, api) {
        if (!angular.isUndefined($stateParams.id)) {
            api.surroundingServices.get({ id: $stateParams.id }, function (result) {
                $scope.data = result;
            });
        }

        $scope.save = function (form) {
            form.$setSubmitted(true);

            if (form.$valid) {
                api.surroundingServices.save($scope.data, function () {
                    $state.go('query.surroundingservices');
                });
            }
        };
    });

})(angular, app);