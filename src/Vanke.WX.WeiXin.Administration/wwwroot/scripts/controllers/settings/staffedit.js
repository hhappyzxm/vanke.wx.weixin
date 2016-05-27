(function (angular, app) {
    'use strict';

    app.controller('StaffEditCtrl', function ($scope, $state, $stateParams, api) {
        if (!angular.isUndefined($stateParams.id)) {
            api.staffs.get({ id: $stateParams.id }, function(result) {
                $scope.data = result;
            });
        }

        $scope.save = function (form) {
            form.$setSubmitted(true);

            if (form.$valid) {
                api.staffs.save($scope.data, function () {
                    $state.go('settings.staffs');
                });
            }
        };
    });

})(angular, app);