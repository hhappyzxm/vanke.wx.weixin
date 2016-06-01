(function (angular, app) {
    'use strict';

    app.controller('DesignatedDriverEditCtrl', function ($scope, $state, $stateParams, api) {
        if (!angular.isUndefined($stateParams.id)) {
            api.items.get({ id: $stateParams.id }, function(result) {
                $scope.data = result;
            });
        }

        $scope.save = function (form) {
            form.$setSubmitted(true);

            if (form.$valid) {
                api.items.save($scope.data, function () {
                    $state.go('settings.items');
                });
            }
        };
    });

})(angular, app);