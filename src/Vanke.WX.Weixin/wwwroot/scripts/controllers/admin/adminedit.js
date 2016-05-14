(function (angular, app) {
    'use strict';

    app.controller('AdminEditCtrl', function($scope, $state, api) {
        $scope.data = {};

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