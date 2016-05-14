(function (angular, app) {
    'use strict';

    app.controller('AdminEditCtrl', function ($scope, $state, $stateParams, api) {
        if (!angular.isUndefined($stateParams.id)) {
            api.admins.get({ id: $stateParams.id }, function(result) {
                $scope.data = result;
            });
        }

        $scope.save = function (form) {
            form.$setSubmitted(true);

            if (form.$valid) {
                api.admins.save($scope.data, function() {
                    $state.go('admin.admins');
                });
            }
        };
    });

})(angular, app);