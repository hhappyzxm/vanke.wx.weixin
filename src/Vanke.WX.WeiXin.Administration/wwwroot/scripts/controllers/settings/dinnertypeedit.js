(function (angular, app) {
    'use strict';

    app.controller('DinnerTypeEditCtrl', function ($scope, $state, $stateParams, api) {
        if (!angular.isUndefined($stateParams.id)) {
            api.dinnerTypes.get({ id: $stateParams.id }, function(result) {
                $scope.data = result;
            });
        }

        $scope.save = function (form) {
            form.$setSubmitted(true);

            if (form.$valid) {
                api.dinnerTypes.save($scope.data, function () {
                    $state.go('admin.dinnertypes');
                });
            }
        };
    });

})(angular, app);